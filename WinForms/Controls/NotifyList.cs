using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace WinForms.Controls
{
	public struct YtFb
	{
		public int YouTubeCount { get; set; }
		public string LastFacebookDate { get; set; }
		public bool Hidden { get; set; }
		public bool Reverse { get; set; }
	}

	public partial class NotifyList : UserControl
	{
		public event EventHandler<YtFb> RequestMore;
		public List<FacebookData> Facebooks = new List<FacebookData>();
		public List<string> Youtubes = new List<string>();
		public string NameTag { get { return lbName.Text; } set { lbName.Text = value; } }
		public Color Back;

		public NotifyList()
		{
			InitializeComponent();
		}

		public NotifyList(string tag)
		{
			InitializeComponent();
			Bitmap b = new Bitmap(Image.FromStream(new MemoryStream(File.ReadAllBytes("Image/Palette.png"))));
			Back = b.GetPixel(Config.Settings.NotifyColor, 2);
			lbName.ForeColor = b.GetPixel(Config.Settings.NotifyColor, 1);
			footer.BackColor = Color.FromArgb((int)(Back.R * 0.7f), (int)(Back.G * 0.7f), (int)(Back.B * 0.7f));
			header.BackColor = Color.FromArgb((int)(Back.R * 0.7f), (int)(Back.G * 0.7f), (int)(Back.B * 0.7f));
			layout.BackColor = Color.FromArgb((int)(Back.R * 0.8f), (int)(Back.G * 0.8f), (int)(Back.B * 0.8f));
			Change(tag);
			Request();
		}

		public ControlCollection GetControls()
		{
			return layout.Controls;
		}

		public void AddGenericNotification(Notification n)
		{
			//n.Parent = layout;
			if (n != null)
			{
				NotificationControl c = n.ToControl();
				c.Refresh();
				c.Visible = true;
				c.Parent = layout;
				c.Location = new Point(0, 0);
				c.Size = new Size(c.Width, n.Height);
				layout.SuspendLayout();
				layout.Controls.Add(c);
				layout.ResumeLayout();
			}
			List<Control> l = new List<Control>();
			foreach (Control c2 in layout.Controls) l.Add(c2);
			Height = Math.Min(1000, header.Height + l.Sum(e => e.Height) + footer.Height + 50);
		}

		public void AddFacebookNotification(Notification n, FacebookData d)
		{
			Facebooks.Add(d);
			AddGenericNotification(n);
		}

		public void AddYouTubeNotification(Notification n, string id)
		{
			Youtubes.Add(id);
			AddGenericNotification(n);
		}

		public FacebookData GetFacebook()
		{
			if (Facebooks.Count == 0) return null;
			return Facebooks[Facebooks.Count - 1];
		}

		public int GetYoutube()
		{
			return Youtubes.Count;
		}

		private void btnLoadMore_Click(object sender, EventArgs e)
		{
			Request(true, false);
		}

		public void Change(string tag)
		{
			lbName.Text = tag;
			Request();
		}

		protected void Request(bool hidden = false, bool reverse = true)
		{
			if (RequestMore != null && lbName.Text != "<None>")
			{
				if (GetFacebook() == null)
				{
					int yt = GetYoutube();
					RequestMore(lbName.Text, new YtFb() { LastFacebookDate = "", YouTubeCount = yt, Hidden = hidden, Reverse = reverse });
				}
				else
				{
					int yt = GetYoutube();
					string fb = GetFacebook().created_time;
					RequestMore(lbName.Text, new YtFb() { LastFacebookDate = fb, YouTubeCount = yt, Hidden = hidden, Reverse = reverse });
				}
			}
		}

		private void cbNamePicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			Request();
		}
	}
}
