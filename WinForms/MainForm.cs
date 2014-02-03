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
		bool mayClose;
		FormWindowState lastState = FormWindowState.Maximized;

		public MainForm()
		{
			InitializeComponent();
			checkers = new List<Checker>();
			Notifications.OnMessage += OnMessage;
			Config.Load();
			if (DateTime.Now.Day == 4 && DateTime.Now.Month == 11)
			{
				Notifications.Notify(new ImagedMessageControl("Image/koala256.png", "TheLockNLol hat heute geburtstag!", "Gratuliere ihm doch auf Facebook :)"), "http://www.facebook.de/TheLockNLol", "TheLockNLol");
			}
			if (Config.Settings.Checkers.Count(i => (i.Facebook == i.Name && i.Name == i.Twitch && i.Twitch == i.YouTube && i.YouTube == "TheLockNLol")) == 0)
			{
				Config.Settings.Checkers.Add(new CheckerFormat() { Name = "TheLockNLol", Enabled = true, Facebook = "TheLockNLol", Twitch = "TheLockNLol", YouTube = "TheLockNLol" });
			}
			UpdateLayout();
		}

		void OnClear(object sender, EventArgs e)
		{
			notifications.Controls.Clear();
		}

		public Controls.NotifyList GetList(string tag)
		{
			foreach (Control c in notifications.Controls)
			{
				if (c is Controls.NotifyList)
				{
					Controls.NotifyList l = (Controls.NotifyList)c;
					if (l.NameTag == tag) return l;
				}
			}
			return null;
		}

		public bool CheckForUpdate()
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
							Notifications.Notify(new ImagedMessageControl("Image/koala256.png", "Update verfügbar!", "Es ist ein Update verfügbar! Drücke mich um es zu Downloaden."), link, "Update");
						}
					}
				}
			}
			catch
			{
				return false;
			}
			return true;
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
			checkers.ForEach(e => { e.checkYoutube(); e.checkTwitch(); e.checkFacebook(); });
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

		}

		private void tsbAbout_Click(object sender, EventArgs e)
		{
			new Forms.About().ShowDialog();
		}

		public void UpdateLayout()
		{
			ResizeThings();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			ResizeThings();
			if (!CheckForUpdate()) MessageBox.Show("Es konnte nicht nach neuen Updates geprüft werden!");
			foreach (CheckerFormat f in Config.Settings.Checkers)
			{
				if (f.Enabled)
				{
					Checker c = new Checker(f.Name, f.Twitch, f.YouTube, f.Facebook);
					checkers.Add(c);
					Controls.NotifyList l = new Controls.NotifyList(f.Name);
					l.RequestMore += (s, ev) => { c.checkYoutube(); c.checkTwitch(); c.checkFacebook(); };
					notifications.Controls.Add(l);
				}
			}
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == NativeMethods.WM_SHOWME)
			{
				ShowMe();
			}
			base.WndProc(ref m);
		}

		private void ShowMe()
		{
			if (WindowState == FormWindowState.Minimized)
			{
				WindowState = lastState;
			}
			bool top = TopMost;
			TopMost = true;
			TopMost = top;
		}

		private void trayClose_Click(object sender, EventArgs e)
		{
			mayClose = true;
			Close();
		}

		private void trayOptions_Click(object sender, EventArgs e)
		{
			new Forms.OptionsForm().ShowDialog();
		}

		private void trayAbout_Click(object sender, EventArgs e)
		{
			new Forms.About().ShowDialog();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!mayClose)
			{
				e.Cancel = true;
				lastState = WindowState;
				WindowState = FormWindowState.Minimized;
				Hide();
			}
		}

		private void trayIcon_DoubleClick(object sender, EventArgs e)
		{
			Show();
			WindowState = lastState;
		}
	}
}
