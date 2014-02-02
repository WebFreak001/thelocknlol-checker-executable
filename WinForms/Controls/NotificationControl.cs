using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WinForms.Controls
{
	public partial class NotificationControl : UserControl
	{
		string title, desc, link;
		Image image;

		public NotificationControl(string image, string title, string desc, string link)
		{
			InitializeComponent();
			WebClient wc = new WebClient();
			byte[] bytes = wc.DownloadData(image);
			MemoryStream ms = new MemoryStream(bytes);
			this.image = Image.FromStream(ms);
			this.title = title;
			this.desc = desc;
			this.link = link;
		}

		public NotificationControl(Image image, string title, string desc, string link)
		{
			InitializeComponent();
			this.image = image;
			this.title = title;
			this.desc = desc;
			this.link = link;
		}

		private void NotificationControl_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.DrawImage(Image.FromFile("Image/Notification.png"), 0, 0, Width, Height);
			g.DrawImage(image, 20, 20, 61, 61);
			g.DrawString(title, new Font("Arial", 10.0f, FontStyle.Bold), new SolidBrush(Color.Black), new RectangleF(96, 16, 256, 20));
			g.DrawString(desc, new Font("Arial", 10.0f, FontStyle.Regular), new SolidBrush(Color.Black), new RectangleF(96, 36, 256, 50));
			g.DrawString("X", new Font("Arial", 9.0f, FontStyle.Regular), new SolidBrush(Color.Black), new RectangleF(346, 12, 12, 12));
		}
	}
}
