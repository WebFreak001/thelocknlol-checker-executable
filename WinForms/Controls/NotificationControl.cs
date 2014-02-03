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
		Rectangle clipRegion;
		float proportion;
		float imgScale;

		public NotificationControl(string image, string title, string desc, string link, Rectangle clipRegion)
		{
			InitializeComponent();
			WebClient wc = new WebClient();
			byte[] bytes = wc.DownloadData(image);
			MemoryStream ms = new MemoryStream(bytes);
			this.image = Image.FromStream(ms);
			this.title = title;
			this.desc = desc;
			this.link = link;
			this.clipRegion = clipRegion;
			proportion = clipRegion.Height / (float)this.image.Height;
			imgScale = 61.0f / this.image.Height;
		}

		public NotificationControl(Image image, string title, string desc, string link, Rectangle clipRegion)
		{
			InitializeComponent();
			this.image = image;
			this.title = title;
			this.desc = desc;
			this.link = link;
			this.clipRegion = clipRegion;
			proportion = clipRegion.Height / (float)this.image.Height;
			imgScale = 61.0f / this.image.Height;
		}

		private void NotificationControl_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.DrawImage(Image.FromFile("Image/Notification.png"), 0, 0, Width, Height);
			g.DrawImage(image, new Rectangle(20, (int)(20 + clipRegion.Y * imgScale), 61, (int)(61 * proportion)), clipRegion, GraphicsUnit.Pixel);
			g.DrawString(title, new Font("Arial", 10.0f, FontStyle.Bold), new SolidBrush(Color.Black), new RectangleF(96, 16, 256, 20));
			g.DrawString(desc, new Font("Arial", 10.0f, FontStyle.Regular), new SolidBrush(Color.Black), new RectangleF(96, 36, 256, 50));
			g.DrawString("X", new Font("Arial", 9.0f, FontStyle.Regular), new SolidBrush(Color.Black), new RectangleF(346, 12, 12, 12));
		}
	}
}
