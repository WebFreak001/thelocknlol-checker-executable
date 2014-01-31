﻿using System;
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
		public static event EventHandler OnClear;

		public static void Notify(string link, string icon, string title, string desc, string data = "")
		{
			if (data != "")
			{
				VideoMessageControl c = new VideoMessageControl(icon, title, desc, data);
				if (OnMessage != null) OnMessage(null, c);
				Notifications.Notify(new ImagedMessageControl(icon, title, desc), link);
			}
			else
			{
				ImagedMessageControl c = new ImagedMessageControl(icon, title, desc);
				if (OnMessage != null) OnMessage(null, c);
				Notifications.Notify(c, link);
			}
		}

		public static void Clear()
		{
			if (OnClear != null) OnClear(null, EventArgs.Empty);
		}
	}
}
