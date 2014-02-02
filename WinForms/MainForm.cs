using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
	public partial class MainForm : Form
	{
		List<Checker> checkers;

		public MainForm()
		{
			InitializeComponent();
			checkers = new List<Checker>();
			Notifications.OnMessage += OnMessage;
			Config.Load();
			if (Config.Settings.Checkers.Count(i => (i.Facebook == i.Name && i.Name == i.Twitch && i.Twitch == i.Twitter && i.Twitter == i.YouTube && i.YouTube == "TheLockNLol")) == 0)
			{
				ListViewItem i = new ListViewItem("TheLockNLol");
				i.Checked = Config.Settings.Filter.Contains("TheLockNLol");
			}
			Config.Settings.Checkers.ForEach(e =>
			{
				ListViewItem i = new ListViewItem(e.Name);
				i.Checked = Config.Settings.Filter.Contains(e.Name);
			});
			if (DateTime.Now.Day == 4 && DateTime.Now.Month == 11)
			{
				Notifications.Notify(new ImagedMessageControl("Image/koala256.png", "TheLockNLol hat heute geburtstag!", "Gratuliere ihm doch auf Facebook :)"), "http://www.facebook.de/TheLockNLol", "TheLockNLol");
			}
			CheckForUpdate();
			if (Config.Settings.Checkers.Count(i => (i.Facebook == i.Name && i.Name == i.Twitch && i.Twitch == i.Twitter && i.Twitter == i.YouTube && i.YouTube == "TheLockNLol")) == 0)
			{
				Config.Settings.Checkers.Add(new CheckerFormat() { Name = "TheLockNLol", Enabled = true, Facebook = "TheLockNLol", Twitch = "TheLockNLol", Twitter = "TheLockNLol", YouTube = "TheLockNLol"});
			}
			int row = 0;
			foreach (CheckerFormat f in Config.Settings.Checkers)
			{
				if (f.Enabled) checkers.Add(new Checker(f.Name, f.Twitch, f.YouTube, f.Facebook, f.Twitter));
				if (row == 0)
				{
					notificationPanel1.Controls.Add(new Controls.NotifyList(f.Name));
				}
				if (row == 1)
				{
					notificationPanel2.Controls.Add(new Controls.NotifyList(f.Name));
				}
				if (row == 2)
				{
					notificationPanel3.Controls.Add(new Controls.NotifyList(f.Name));
				}
				row++;
				row %= 3;
			}
			UpdateLayout();
		}

		void OnClear(object sender, EventArgs e)
		{
			notifications.Controls.Clear();
		}

		public Controls.NotifyList GetList(string tag)
		{
			foreach (Control c in notificationPanel1.Controls)
			{
				if (c is Controls.NotifyList)
				{
					Controls.NotifyList l = (Controls.NotifyList)c;
					if (l.NameTag == tag) return l;
				}
			}
			foreach (Control c in notificationPanel2.Controls)
			{
				if (c is Controls.NotifyList)
				{
					Controls.NotifyList l = (Controls.NotifyList)c;
					if (l.NameTag == tag) return l;
				}
			}
			foreach (Control c in notificationPanel3.Controls)
			{
				if (c is Controls.NotifyList)
				{
					Controls.NotifyList l = (Controls.NotifyList)c;
					if (l.NameTag == tag) return l;
				}
			}
			return null;
		}

		public void CheckForUpdate()
		{
			try
			{
				using (WebClient c = new WebClient())
				{
					string s = c.DownloadString("https://raw.github.com/WebFreak001/thelocknlol-checker-executable/master/WinForms/Version.cs");
					string[] lines = s.Split('\n');
					string vRaw = lines[2].Trim().Substring("public static int VersionNumber = ".Length).Replace(";", "");
					string link = lines[3].Trim().Substring("public static string Download = ".Length).Replace("\"", "").Replace(";", "");
					int version = int.Parse(vRaw);
					if (Version.VersionNumber < version)
					{
						if (Config.Settings.AutoUpdate)
						{
							c.DownloadFileAsync(new Uri(link), Path.Combine(Directory.GetCurrentDirectory(), "update.zip"));
							c.DownloadFileCompleted += (a, b) =>
							{
								ProcessStartInfo pfi = new ProcessStartInfo("Explorer.exe", string.Format("/Select, \"{0}\"", Path.Combine(Directory.GetCurrentDirectory(), "update.zip")));
								Process.Start(pfi);
							};
						}
						else
						{
							Notifications.Notify(new ImagedMessageControl("", "Update verfügbar!", "Es ist ein Update verfügbar! Drücke mich um es zu Downloaden."), link, "Update");
						}
					}
				}
			}
			catch
			{
				Console.WriteLine("Couldnt Check for updates!");
			}
		}

		void OnMessage(object sender, Notification e)
		{
			string s = sender.ToString();
			GetList(s).AddNotification(e);
			UpdateLayout();
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			RefreshThings();
		}

		private void refreshTimer_Tick(object sender, EventArgs e)
		{
			RefreshThings();
		}

		public void RefreshThings()
		{
			checkers.ForEach(e => { e.checkYoutube(); e.checkTwitch(); e.checkFacebook(); e.checkTwitter(); });
		}

		private void btnOptions_Click(object sender, EventArgs e)
		{
			new Forms.OptionsForm().ShowDialog();
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			ResizeThings();
		}

		public void ResizeThings()
		{
			notificationPanel1.Width = Width / 3;
			notificationPanel2.Width = Width / 3;
			notificationPanel3.Width = Width / 3;
			List<Control> controls1 = new List<Control>();
			foreach (Control c in notificationPanel1.Controls) controls1.Add(c);
			List<Control> controls2 = new List<Control>();
			foreach (Control c in notificationPanel2.Controls) controls2.Add(c);
			List<Control> controls3 = new List<Control>();
			foreach (Control c in notificationPanel3.Controls) controls3.Add(c);
			notificationPanel1.Height = controls1.Sum(f => f.Height + 20);
			notificationPanel2.Height = controls2.Sum(f => f.Height + 20);
			notificationPanel3.Height = controls3.Sum(f => f.Height + 20);
			controls1.ForEach(f => f.Width = notificationPanel1.Width);
			controls2.ForEach(f => f.Width = notificationPanel2.Width);
			controls3.ForEach(f => f.Width = notificationPanel3.Width);
		}

		private void lvFilter_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (Config.Settings.Filter.Contains(e.Item.Text) && !e.Item.Checked) Config.Settings.Filter.Remove(e.Item.Text);
			if (e.Item.Checked && !Config.Settings.Filter.Contains(e.Item.Text)) Config.Settings.Filter.Add(e.Item.Text);
			Config.Save();
		}

		private void tsbAbout_Click(object sender, EventArgs e)
		{

		}

		private void btnUnread_Click(object sender, EventArgs e)
		{
			UpdateLayout();
		}

		private void btnHistory_Click(object sender, EventArgs e)
		{
			UpdateLayout();
		}

		public void UpdateLayout()
		{
			ResizeThings();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			ResizeThings();
		}
	}
}
