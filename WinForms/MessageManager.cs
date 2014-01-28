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
		public event EventHandler<Control> OnMessage;

		public MessageManager()
		{
			
		}

		public void Notify(string icon, string title, string data, bool video = false)
		{
			if(video)
			{
				VideoMessageControl c = new VideoMessageControl(icon, title, data);
				OnMessage(null, c);
				Notifications.Notify(new ImagedMessageControl(icon, "Neues Video", title));
			}
			else
			{
				ImagedMessageControl c = new ImagedMessageControl(icon, title, data);
				OnMessage(null, c);
				Notifications.Notify(c);
			}
		}
	}
}
