using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace WinForms
{
	public struct NotificationType
	{
		public ImagedMessageControl Control;
		public string Link;
		public string Tag;
		public bool ShowInWindow;
	}

	public class Notifications
	{
		public static int Count = 0;
		public static event EventHandler<Notification> OnMessage;
		protected static Queue<NotificationType> Queued = new Queue<NotificationType>(64);

		public static int GetTaskbarHeight()
		{
			return Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height;
		}

		public static void FetchNotification(MainForm f)
		{
			if (Count < 0) Count = 0;
			if(Queued.Count != 0)
			{
				NotificationType n = Queued.Dequeue();
				Notification notification = new Notification(f, n.Tag, n.Control.Image, n.Control.Title, n.Control.Desc, n.Link, !n.ShowInWindow);
				if(n.ShowInWindow)
				{
					notification.ShowInTaskbar = false;
					notification.Show();
					notification.Left = Screen.PrimaryScreen.Bounds.Width - 375;
					if (SystemInformation.WorkingArea.Top > 0) notification.Top = Screen.PrimaryScreen.Bounds.Height - 100 * Count - 105;
					else notification.Top = Screen.PrimaryScreen.Bounds.Height - 100 * Count - 105 - GetTaskbarHeight();
					Count++;
					notification.Opacity = 1;
				}
				if (OnMessage != null) OnMessage(n.Tag, notification);
			}
		}

		public static void Notify(ImagedMessageControl c, string link, string tag, bool showInWindow)
		{
			QueueNotification(c, link, tag, showInWindow);
		}

		protected static void QueueNotification(ImagedMessageControl c, string link, string tag, bool showInWindow)
		{
			Queued.Enqueue(new NotificationType() { Control = c, Link = link, Tag = tag, ShowInWindow = showInWindow });
		}
	}
}
