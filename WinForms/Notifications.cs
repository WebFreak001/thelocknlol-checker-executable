using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace WinForms
{
	public class NotificationType
	{
		public ImagedMessageControl Control { get; set; }
		[DefaultValue("")]
		public string Link { get; set; }
		[DefaultValue("<None>")]
		public string Tag { get; set; }
		[DefaultValue(true)]
		public bool ShowInWindow { get; set; }
		[DefaultValue(0)]
		public int Type { get; set; }
	}

	public class YoutubeNotificationType : NotificationType
	{
		public string ID { get; set; }
	}

	public class FacebookNotificationType : NotificationType
	{
		public FacebookData Data { get; set; }
	}

	public class NotificationFacebook
	{
		public Notification N { get; set; }
		public FacebookData Fb { get; set; }
	}

	public class NotificationYoutube
	{
		public Notification N { get; set; }
		public string Yt { get; set; }
	}

	public class Notifications
	{
		public static int Count = 0;
		public static event EventHandler<Notification> OnGenericMessage;
		public static event EventHandler<NotificationFacebook> OnFacebookMessage;
		public static event EventHandler<NotificationYoutube> OnYouTubeMessage;
		protected static Queue<NotificationType> Queued = new Queue<NotificationType>(64);
		public static DateTime Allow = new DateTime(0);

		public static int GetTaskbarHeight()
		{
			return Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height;
		}

		public static void FetchNotification(MainForm f)
		{
			if (Count < 0) Count = 0;
			if (Queued.Count != 0)
			{
				NotificationType n = Queued.Dequeue();
				byte[] bytes = Encoding.Default.GetBytes(n.Control.Title);
				n.Control.Title = Encoding.UTF8.GetString(bytes);
				bytes = Encoding.Default.GetBytes(n.Control.Desc);
				n.Control.Desc = Encoding.UTF8.GetString(bytes);
				Notification notification = new Notification(f, n.Tag, n.Control.Image, n.Control.Title, n.Control.Desc, n.Link, !n.ShowInWindow);
				if (n.Type == 0)
				{
					if (OnGenericMessage != null) OnGenericMessage(n.Tag, notification);
				}
				else if (n.Type == 1)
				{
					if (OnYouTubeMessage != null) OnYouTubeMessage(n.Tag, new NotificationYoutube() { N = notification, Yt = ((YoutubeNotificationType)n).ID });
				}
				else if (n.Type == 2)
				{
					if (OnFacebookMessage != null) OnFacebookMessage(n.Tag, new NotificationFacebook() { N = notification, Fb = ((FacebookNotificationType)n).Data });
				}

				if (n.ShowInWindow)
				{
					if (DateTime.Now > Allow && Count <= Config.Settings.MaxNotifications)
					{
						notification.ShowInTaskbar = false;
						notification.Show();
						notification.Left = Screen.PrimaryScreen.Bounds.Width - 375;
						if (SystemInformation.WorkingArea.Top > 0) notification.Top = Screen.PrimaryScreen.Bounds.Height - 100 * Count - 105;
						else notification.Top = Screen.PrimaryScreen.Bounds.Height - 100 * Count - 105 - GetTaskbarHeight();
						Count++;
						notification.Opacity = 1;
					}
				}
			}
		}

		public static void NotifyGeneric(ImagedMessageControl c, string link, string tag, bool showInWindow)
		{
			QueueNotification(c, link, tag, showInWindow);
		}

		public static void NotifyFacebook(ImagedMessageControl c, string link, string tag, bool showInWindow, FacebookData fb)
		{
			QueueFacebook(c, link, tag, showInWindow, fb);
		}

		public static void NotifyYouTube(ImagedMessageControl c, string link, string tag, bool showInWindow, string id)
		{
			QueueYoutube(c, link, tag, showInWindow, id);
		}

		protected static void QueueNotification(ImagedMessageControl c, string link, string tag, bool showInWindow)
		{
			Queued.Enqueue(new NotificationType() { Control = c, Link = link, Tag = tag, ShowInWindow = showInWindow, Type = 0 });
		}

		protected static void QueueYoutube(ImagedMessageControl c, string link, string tag, bool showInWindow, string id)
		{
			Queued.Enqueue(new YoutubeNotificationType() { Control = c, Link = link, Tag = tag, ShowInWindow = showInWindow, ID = id, Type = 1 });
		}

		protected static void QueueFacebook(ImagedMessageControl c, string link, string tag, bool showInWindow, FacebookData fb)
		{
			Queued.Enqueue(new FacebookNotificationType() { Control = c, Link = link, Tag = tag, ShowInWindow = showInWindow, Data = fb, Type = 2 });
		}
	}
}
