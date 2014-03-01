using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WinForms
{
	public struct NotifyStruct
	{
		public ImagedMessageControl control { get; set; }
		public string link { get; set; }
		public string tab { get; set; }
		public bool showInWindow { get; set; }
		public string id { get; set; }
	}

	public class Checker
	{
		string name, twitch, youtube, facebook, defaultImage;

		string lastYoutube, lastFacebook;
		bool initialCheck = true;
		bool streaming;

		public Checker(string name, string twitch, string youtube, string facebook)
		{
			this.name = name;
			this.twitch = twitch;
			this.youtube = youtube;
			this.facebook = facebook;
			defaultImage = "Image/unknown.png";
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.DownloadStringCompleted += (a, b) =>
					{
						if (!b.Cancelled)
						{
							string xmlString = b.Result;
							XmlReader reader = XmlReader.Create(new StringReader(xmlString));
							reader.ReadToFollowing("media:thumbnail");
							defaultImage = reader["url"];
						};
					};
					webClient.DownloadStringAsync(new Uri("http://gdata.youtube.com/feeds/api/users/" + youtube));
				}
			}
			catch
			{
				defaultImage = "Image/unknown.png";
			}
			Check(0, "", true);
		}

		public void Check(int youtube, string facebook, bool hidden = false, bool reverse = true)
		{
			initialCheck = hidden;
			checkTwitch();
			checkYoutube(youtube + 1, reverse);
			checkFacebook(facebook);
			initialCheck = false;
		}

		public void checkTwitch()
		{
			bool ini = !initialCheck;
			new Thread(() =>
			{
				if (Config.Settings.CheckLivestream && twitch.Trim() != "")
				{
					using (WebClient webClient = new WebClient())
					{
						webClient.DownloadStringCompleted += (a, b) =>
						{
							if (!b.Cancelled && b.Error == null)
							{
								string api = b.Result;
								if (api.Trim().Replace(" ", "") == "[]")
								{
									streaming = false;
								}
								else
								{
									if (!streaming)
									{
										Notifications.NotifyGeneric(new ImagedMessageControl(defaultImage, name + " streamt nun!", "Klicke mich und gelange direkt zum stream!"), "http://www.twitch.tv/" + twitch, name, ini);
										if (Config.Settings.Sounds.OnLivestream) PlaySound(Config.Settings.CurrentSound);
									}
									streaming = true;
								}
							}
						};
						webClient.DownloadStringAsync(new Uri("http://api.justin.tv/api/stream/list.json?channel=" + twitch));
					}
				}
			}).Start();
		}

		public void checkYoutube(int id_, bool reverse = true)
		{
			bool ini = !initialCheck;
			new Thread(() =>
			{
				if (Config.Settings.CheckVideo && youtube.Trim() != "")
				{
					using (WebClient webClient = new WebClient())
					{
						webClient.DownloadStringCompleted += (a, b) =>
						{
							if (!b.Cancelled && b.Error == null)
							{
								string xmlString = b.Result;
								string lastID = "";
								List<NotifyStruct> notifys = new List<NotifyStruct>();
								XmlReader reader = XmlReader.Create(new StringReader(xmlString));
								while (reader.Read())
								{
									switch (reader.Name)
									{
										case "feed":
											break;
										case "entry":
											try
											{
												reader.ReadToFollowing("id");
												string id = reader.ReadElementContentAsString();
												reader.ReadToFollowing("title");
												string title = reader.ReadElementContentAsString();
												reader.ReadToFollowing("media:thumbnail");
												string thumbnail = reader["url"];
												string s = lastYoutube;
												if (s == id.Substring(42)) goto ReadDone;
												NotifyStruct sn = new NotifyStruct()
												{
													control = new ImagedMessageControl(thumbnail, name + " hat ein neues Video hochgeladen!", title),
													link = "http://www.youtube.com/watch?v=" + id.Substring(42),
													showInWindow = ini,
													tab = name,
													id = id.Substring(42)
												};
												notifys.Add(sn);
												if (Config.Settings.Sounds.OnVideo) PlaySound(Config.Settings.CurrentSound);
												if (lastID == "") lastID = id.Substring(42);
											}
											catch
											{
											}
											break;
									}
								}
							ReadDone:
								reader.Close();
								reader.Dispose();
								if (lastID != "")
								{
									lastYoutube = lastID;
								}
								if (reverse)
									for (int i = notifys.Count - 1; i >= 0; i--)
									{
										Notifications.NotifyYouTube(notifys[i].control, notifys[i].link, notifys[i].tab, notifys[i].showInWindow, notifys[i].id);
									}
								else
									for (int i = 0; i < notifys.Count; i++)
									{
										Notifications.NotifyYouTube(notifys[i].control, notifys[i].link, notifys[i].tab, notifys[i].showInWindow, notifys[i].id);
									}
							}
						};
						webClient.DownloadStringAsync(new Uri("http://gdata.youtube.com/feeds/api/users/" + youtube + "/uploads?start-index=" + id_ + "&max-results=" + Config.Settings.LoadMoreNotifications));
					}
				}
			}).Start();
		}

		public void checkFacebook(string last)
		{
			bool ini = !initialCheck;
			new Thread(() =>
			{
				if (Config.Settings.CheckSocial && facebook.Trim() != "")
				{
					using (WebClient webClient = new WebClient())
					{
						webClient.DownloadStringCompleted += (a, b) =>
						{
							if (!b.Cancelled && b.Error == null)
							{
								Facebook fb = JsonConvert.DeserializeObject<Facebook>(b.Result);
								string lastID = "";
								foreach (FacebookData d in fb.data)
								{

									if (d.id == lastFacebook) goto ReadDone;
									if (lastID == "") lastID = d.id;
									if (d.message != null && d.id != null)
									{
										d.link = d.link ?? "";
										d.name = d.name ?? name;
										d.picture = d.picture ?? defaultImage;
										if (Config.Settings.MergeSocialVideo && !d.link.Contains("youtube") || !Config.Settings.MergeSocialVideo)
										{
											if (d.picture == null) Notifications.NotifyFacebook(new ImagedMessageControl(defaultImage, d.name, d.message), d.link, name, ini, d);
											else Notifications.NotifyFacebook(new ImagedMessageControl(d.picture, d.name, d.message), d.link, name, ini, d);
											if (Config.Settings.Sounds.OnFacebook) PlaySound(Config.Settings.CurrentSound);
										}
									}
								}
							ReadDone:
								if (lastID != "")
								{
									lastFacebook = lastID;
								}
							}
						};
						if (last == "") webClient.DownloadStringAsync(new Uri("https://graph.facebook.com/" + facebook + "/feed?limit=" + Config.Settings.LoadMoreNotifications + "&access_token=678452665531590|x3qFGSCtknwuL6CRSk8zAztx69Y"));
						else webClient.DownloadStringAsync(new Uri("https://graph.facebook.com/" + facebook + "/feed?limit="  + Config.Settings.LoadMoreNotifications + "&access_token=678452665531590|x3qFGSCtknwuL6CRSk8zAztx69Y&since=" + GetUnix(last)));
					}
				}
			}).Start();
		}

		public double GetUnix(DateTime dateTime)
		{
			return (dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
		}

		public double GetUnix(string s)
		{
			string time = s.Substring(0, s.IndexOf("+"));
			int year = int.Parse(time.Split('-')[0]);
			int month = int.Parse(time.Split('-')[1]);
			int day = int.Parse(time.Split('-')[2].Split('T')[0]);
			int hour = int.Parse(time.Split('T')[1].Split(':')[0]);
			int minute = int.Parse(time.Split('T')[1].Split(':')[1]);
			int second = int.Parse(time.Split('T')[1].Split(':')[2]);
			return GetUnix(new DateTime(year, month, day, hour, minute, second));
		}

		public void PlaySound(string s)
		{
			if (s.ToLower().StartsWith("system:"))
			{
				string sound = s.Split(':')[1].ToLower().Trim();
				if (sound == "asterisk") SystemSounds.Asterisk.Play();
				if (sound == "beep") SystemSounds.Beep.Play();
				if (sound == "exclamation") SystemSounds.Exclamation.Play();
				if (sound == "hand") SystemSounds.Hand.Play();
				if (sound == "question") SystemSounds.Question.Play();
			}
			else
			{
				SoundPlayer p = new SoundPlayer(s);
				p.LoadCompleted += (a, b) =>
				{
					p.Play();
				};
				p.LoadAsync();
			}
		}
	}
}
