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
	public class Notifications
	{
		public static int Count = 0;
		public static event EventHandler<Notification> OnMessage;

		public static int GetTaskbarHeight()
		{
			return Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height;
		}

		public static void Notify(ImagedMessageControl c, string link, string tag)
		{
			if (Count < 0) Count = 0;
			Notification notification = new Notification(c.Image, c.Title, c.Desc, link);
			notification.ShowInTaskbar = false;
			notification.Show();
			notification.Left = Screen.PrimaryScreen.Bounds.Width - 375;
			if (SystemInformation.WorkingArea.Top > 0) notification.Top = Screen.PrimaryScreen.Bounds.Height - 100 * Count - 105;
			else notification.Top = Screen.PrimaryScreen.Bounds.Height - 100 * Count - 105 - GetTaskbarHeight();
			Count++;
			notification.Opacity = 1;
			if (OnMessage != null) OnMessage(tag, notification);
		}
	}
}
