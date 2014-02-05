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
	public class Checker
	{
		string name, twitch, youtube, facebook, defaultImage;
		WebClient webClient;

		public Checker(string name, string twitch, string youtube, string facebook)
		{
			this.name = name;
			this.twitch = twitch;
			this.youtube = youtube;
			this.facebook = facebook;
			defaultImage = "Image/koala256.png";
			webClient = new WebClient();
			try
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
			catch
			{
				defaultImage = "Image/koala256.png";
			}
		}

		public void checkTwitch()
		{
			new Thread(() =>
			{
				if (Config.Settings.CheckLivestream && twitch.Trim() != "")
				{
					webClient.DownloadStringAsync(new Uri("http://api.justin.tv/api/stream/list.json?channel=" + twitch));
					webClient.DownloadStringCompleted += (a, b) =>
					{
						if (!b.Cancelled)
						{
							string api = b.Result;
							if (api.Trim().Replace(" ", "") == "[]")
							{
								Config.Settings.Checkers.Where(i => i.Name == name).First().Livestreaming = false;
							}
							else
							{
								if (!Config.Settings.Checkers.Where(i => i.Name == name).First().Livestreaming)
								{
									Notifications.Notify(new ImagedMessageControl(defaultImage, name + " streamt nun!", "Klicke mich und gelange direkt zum stream!"), "http://www.twitch.tv/" + twitch, name);
									if (Config.Settings.Sounds.OnLivestream) PlaySound(Config.Settings.CurrentSound);
								}
								Config.Settings.Checkers.Where(i => i.Name == name).First().Livestreaming = true;
							}
						}
					};
				}
			}).Start();
		}

		public void checkYoutube()
		{
			new Thread(() =>
			{
				if (Config.Settings.CheckVideo && youtube.Trim() != "")
				{
					webClient.DownloadStringCompleted += (a, b) =>
					{
						if (!b.Cancelled)
						{
							string xmlString = b.Result;
							string lastID = "";
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
											string s = Config.Settings.Checkers.Where(i => i.Name == name).First().LastVideo;
											if (s == id.Substring(42)) goto ReadDone;
											Notifications.Notify(new ImagedMessageControl(thumbnail, name + " hat ein neues Video hochgeladen!", title), "http://www.youtube.com/watch?v=" + id.Substring(42), name);
											if (Config.Settings.Sounds.OnVideo) PlaySound(Config.Settings.CurrentSound);
											if (lastID == "") lastID = id.Substring(42);
										}
										catch (Exception e)
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
								Config.Settings.Checkers.Where(i => i.Name == name).First().LastVideo = lastID;
								Config.Save();
							}
						}
					};
					webClient.DownloadStringAsync(new Uri("http://gdata.youtube.com/feeds/api/users/" + youtube + "/uploads?max-results=5"));
				}
			}).Start();
		}

		public void checkFacebook()
		{
			new Thread(() =>
			{
				if (Config.Settings.CheckSocial && facebook.Trim() != "")
				{
					webClient.DownloadStringCompleted += (a, b) =>
					{
						if (!b.Cancelled)
						{
							Facebook fb = JsonConvert.DeserializeObject<Facebook>(b.Result);
							string lastID = "";
							foreach (FacebookData d in fb.data)
							{

								if (d.id == Config.Settings.Checkers.Where(i => i.Name == name).First().LastFacebook) goto ReadDone;
								if (lastID == "") lastID = d.id;
								if (d.name != null && d.message != null)
								{
									if (Config.Settings.MergeSocialVideo && !d.link.Contains("youtube") || !Config.Settings.MergeSocialVideo)
									{
										if (d.picture == null) Notifications.Notify(new ImagedMessageControl(defaultImage, d.name, d.message), d.link, name);
										else Notifications.Notify(new ImagedMessageControl(d.picture, d.name, d.message), d.link, name);
										if (Config.Settings.Sounds.OnFacebook) PlaySound(Config.Settings.CurrentSound);
									}
								}
							}
						ReadDone:
							if (lastID != "")
							{
								Config.Settings.Checkers.Where(i => i.Name == name).First().LastFacebook = lastID;
								Config.Save();
							}
						}
					};
					webClient.DownloadStringAsync(new Uri("https://graph.facebook.com/" + facebook + "/feed?limit=5&access_token=678452665531590|x3qFGSCtknwuL6CRSk8zAztx69Y"));

				}
			}).Start();
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
