using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms.Controls;

namespace WinForms
{
	public partial class Notification : Form
	{
		string title, desc, link;
		float proportion;
		float imgScale;
		Bitmap image;
		Rectangle clipRegion;
		int step = 0;

		public Notification(string image, string title, string desc, string link)
		{
			InitializeComponent();
			if(image == null || title == null || desc == null || link == null) return;
			WebClient wc = new WebClient();
			byte[] bytes = wc.DownloadData(image);
			MemoryStream ms = new MemoryStream(bytes);
			this.image = new Bitmap(ms);
			int y0 = 0, y1 = this.image.Height;
			for (int y = 0; y < this.image.Height; y++)
			{
				bool isBlack = true;
				for (int x = 0; x < this.image.Width; x++)
				{
					Color c = this.image.GetPixel(x, y);
					if (c.R + c.G + c.B > 30) isBlack = false;
				}
				if(isBlack)
				{
					if (y < this.image.Height / 2) y0 = y;
					else y1 = y;
				}
				isBlack = true;
			}
			clipRegion = new Rectangle(0, y0, this.image.Width, y1 - y0 * 2);
			this.title = title;
			this.desc = desc;
			this.link = link;
			timer1.Interval = Config.Settings.NotifyDelay * 10;
			if(Config.Settings.NotifyDelay != 300) timer1.Enabled = true;
			proportion = clipRegion.Height / (float)this.image.Height;
			imgScale = 61.0f / this.image.Height;
		}

		private void Notification_Load(object sender, EventArgs e)
		{
			TransparencyKey = Color.Magenta;
			BackColor = Color.Magenta;
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x80;
				return cp;
			}
		}

		private void Notification_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.DrawImage(Image.FromFile("Image/Notification.png"), new Rectangle(0, 0, Width, Height));
			g.DrawImage(image, new Rectangle(20, (int)(20 + clipRegion.Y * imgScale), 61, (int)(61 * proportion)), clipRegion, GraphicsUnit.Pixel);
			g.DrawString(title, new Font("Arial", 10.0f, FontStyle.Bold), new SolidBrush(Color.Black), new RectangleF(96, 16, 256, 20));
			g.DrawString(desc, new Font("Arial", 10.0f, FontStyle.Regular), new SolidBrush(Color.Black), new RectangleF(96, 36, 256, 50));
			g.DrawString("X", new Font("Arial", 9.0f, FontStyle.Regular), new SolidBrush(Color.Black), new RectangleF(346, 12, 12, 12));
		}

		private void Notification_Click(object sender, EventArgs e)
		{
			Point p = PointToClient(Cursor.Position);
			if (p.X >= 343 && p.X <= 361 && p.Y >= 10 && p.Y <= 28)
			{
				//TODO: Remove from history
			}
			else
			{
				Process.Start(link);
			}
			Close();
			Notifications.Count--;
		}

		public void Dismiss()
		{
			Notifications.Count--;
			timer2.Enabled = true;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			Dismiss();
			timer1.Enabled = false;
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			if (step > 100)
			{
				Close();
			}
			else
			{
				Opacity = (100 - step) * 0.01;
			}
			step++;
		}

		public NotificationControl ToControl()
		{
			return new NotificationControl(image, title, desc, link, clipRegion);
		}
	}
}
