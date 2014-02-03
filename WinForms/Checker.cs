using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

		public Checker(string name, string twitch, string youtube, string facebook)
		{
			this.name = name;
			this.twitch = twitch;
			this.youtube = youtube;
			this.facebook = facebook;
			defaultImage = "Image/koala256.png";
			try
			{
				using (WebClient c = new WebClient())
				{
					c.DownloadStringCompleted += (a, b) =>
					{
						if (!b.Cancelled)
						{
							string xmlString = b.Result;
							XmlReader reader = XmlReader.Create(new StringReader(xmlString));
							reader.ReadToFollowing("media:thumbnail");
							defaultImage = reader["url"];
						};
					};
					c.DownloadStringAsync(new Uri("http://gdata.youtube.com/feeds/api/users/" + youtube));
				}
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
					using (WebClient c = new WebClient())
					{
						c.DownloadStringAsync(new Uri("http://api.justin.tv/api/stream/list.json?channel=" + twitch));
						c.DownloadStringCompleted += (a, b) =>
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
									}
									Config.Settings.Checkers.Where(i => i.Name == name).First().Livestreaming = true;
								}
							}
						};
					}
				}
			}).Start();
		}

		public void checkYoutube()
		{
			new Thread(() =>
			{
				if (Config.Settings.CheckVideo && youtube.Trim() != "")
				{
					using (WebClient c = new WebClient())
					{
						c.DownloadStringCompleted += (a, b) =>
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
												//lastID = id.Substring(42);
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
						c.DownloadStringAsync(new Uri("http://gdata.youtube.com/feeds/api/users/" + youtube + "/uploads?max-results=5"));
					}
				}
			}).Start();
		}

		public void checkFacebook()
		{
			new Thread(() =>
			{
				if (Config.Settings.CheckSocial && facebook.Trim() != "")
				{
					using (WebClient c = new WebClient())
					{
						c.DownloadStringCompleted += (a, b) =>
						{
							if (!b.Cancelled)
							{
								Facebook fb = JsonConvert.DeserializeObject<Facebook>(b.Result);
								string lastID = "";
								foreach (FacebookData d in fb.data)
								{
									if (d.id == Config.Settings.Checkers.Where(i => i.Name == name).First().LastFacebook) goto ReadDone;
									if (d.name != null && d.message != null)
									{
										if (!d.link.Contains("youtube"))
										{
											if (d.picture == null) Notifications.Notify(new ImagedMessageControl(defaultImage, d.name, d.message), d.link, name);
											else Notifications.Notify(new ImagedMessageControl(d.picture, d.name, d.message), d.link, name);
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
						c.DownloadStringAsync(new Uri("https://graph.facebook.com/" + facebook + "/feed?limit=5&access_token=678452665531590|x3qFGSCtknwuL6CRSk8zAztx69Y"));
					}
				}
			}).Start();
		}
	}
}
