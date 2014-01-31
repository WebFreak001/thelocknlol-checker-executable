using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WinForms
{
	public class Checker
	{
		string twitch, youtube, facebook;

		public Checker(string twitch, string youtube, string facebook)
		{
			this.twitch = twitch;
			this.youtube = youtube;
			this.facebook = facebook;
		}

		public void checkTwitch()
		{
			if (Config.Settings.CheckLivestream)
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
								Config.LastTwitchOnline = false;
							}
							else
							{
								if (!Config.LastTwitchOnline)
								{
									Notifications.Notify(new ImagedMessageControl("Image/koala256.png", "TheLockNLol streamt nun!", "Klicke mich und gelange direkt zum stream!"), "http://www.twitch.tv/TheLockNLol");
								}
								Config.LastTwitchOnline = true;
							}
						}
					};
				}
			}
		}

		public void checkYoutube()
		{
			if (Config.Settings.CheckVideo)
			{
				using (WebClient c = new WebClient())
				{
					c.DownloadStringAsync(new Uri("http://gdata.youtube.com/feeds/api/users/" + youtube + "/uploads?max-results=5"));
					bool first = true;
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
											if (Config.Settings.LastVideo == id) goto ReadDone;
											if (first)
											{
												MessageManager.Clear();
												first = false;
											}
											MessageManager.Notify("http://www.youtube.com/watch?v=" + id.Substring(42), thumbnail, "TheLockNLol hat ein neues Video hochgeladen!", title, "http://www.youtube.com/watch?v=" + id.Substring(42));
										}
										catch { }
										break;
								}
							}
							reader.Close();
							reader.Dispose();
						ReadDone:
							if (lastID != "")
							{
								Config.Settings.LastVideo = lastID;
								Config.Save();
							}
						}
					};
				}
			}
		}

		public void checkFacebook()
		{
			if (Config.Settings.CheckSocial)
			{
				//https://graph.facebook.com/TheLockNLol/feed?limit=5&access_token=678452665531590|x3qFGSCtknwuL6CRSk8zAztx69Y

			}
		}

		public void checkTwitter()
		{
			if (Config.Settings.CheckSocial)
			{
				//https://graph.facebook.com/TheLockNLol/feed?limit=5&access_token=678452665531590|x3qFGSCtknwuL6CRSk8zAztx69Y

			}
		}
	}
}
