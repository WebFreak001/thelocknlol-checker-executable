using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
	public class MessageManager
	{
		public static event EventHandler<Control> OnMessage;

		public static void Notify(string icon, string title, string desc, string data = "")
		{
			if(data != "")
			{
				VideoMessageControl c = new VideoMessageControl(icon, title, desc, data);
				if (OnMessage != null) OnMessage(null, c);
				Notifications.Notify(new ImagedMessageControl(icon, title, desc));
			}
			else
			{
				ImagedMessageControl c = new ImagedMessageControl(icon, title, desc);
				if (OnMessage != null) OnMessage(null, c);
				Notifications.Notify(c);
			}
		}
	}
}
