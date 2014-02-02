using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WinForms
{
	public class Checker
	{
		string name, twitch, youtube, facebook, twitter;

		public Checker(string name, string twitch, string youtube, string facebook, string twitter)
		{
			this.name = name;
			this.twitch = twitch;
			this.youtube = youtube;
			this.facebook = facebook;
			this.twitter = twitter;
		}

		public void checkTwitch()
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
									Notifications.Notify(new ImagedMessageControl("Image/koala256.png", name + " streamt nun!", "Klicke mich und gelange direkt zum stream!"), "http://www.twitch.tv/" + twitch, name);
								}
								Config.Settings.Checkers.Where(i => i.Name == name).First().Livestreaming = true;
							}
						}
					};
				}
			}
		}

		public void checkYoutube()
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
											MessageBox.Show(e.Message + "\n" + e.StackTrace, "DU PRO HIER IST NE EXCEPTION -.-");
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
		}

		public void checkFacebook()
		{
			if (Config.Settings.CheckSocial && facebook.Trim() != "")
			{
				//https://graph.facebook.com/TheLockNLol/feed?limit=5&access_token=678452665531590|x3qFGSCtknwuL6CRSk8zAztx69Y

			}
		}

		public void checkTwitter()
		{
			if (Config.Settings.CheckSocial && twitter.Trim() != "")
			{

			}
		}
	}
}
