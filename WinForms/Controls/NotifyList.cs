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

namespace WinForms.Controls
{
	public struct YtFb
	{
		public int YouTubeCount { get; set; }
		public string LastFacebookDate { get; set; }
	}

	public partial class NotifyList : UserControl
	{
		public event EventHandler<YtFb> RequestMore;
		public List<FacebookData> Facebooks = new List<FacebookData>();
		public List<string> Youtubes = new List<string>();
		public string NameTag { get { return lbName.Text; } set { lbName.Text = value; } }

		public NotifyList()
		{
			InitializeComponent();
		}

		public NotifyList(string tag)
		{
			InitializeComponent();
			Change(tag);
			Request();
		}

		public ControlCollection GetControls()
		{
			return layout.Controls;
		}

		public void AddGenericNotification(Notification n)
		{
			layout.SuspendLayout();
			//n.Parent = layout;
			if (n != null)
			{
				NotificationControl c = n.ToControl();
				c.Refresh();
				c.Visible = true;
				c.Parent = layout;
				c.Location = new Point(0, 0);
				c.Size = new Size(c.Width, n.Height);
				layout.Controls.Add(c);
			}
			layout.ResumeLayout();
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
			Request();
		}

		public void Change(string tag)
		{
			lbName.Text = tag;
			Request();
		}

		protected void Request()
		{
			if (RequestMore != null && lbName.Text != "<None>")
			{
				if (GetFacebook() == null)
				{
					int yt = GetYoutube();
					RequestMore(null, new YtFb() { LastFacebookDate = "", YouTubeCount = yt });
				}
				else
				{
					int yt = GetYoutube();
					string fb = GetFacebook().created_time;
					RequestMore(null, new YtFb() { LastFacebookDate = fb, YouTubeCount = GetYoutube() });
				}
			}
		}

		private void cbNamePicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			Request();
		}
	}
}
