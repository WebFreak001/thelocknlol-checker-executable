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
			Notifications.OnMessage += OnMessage;
			try
			{
				InitializeComponent();
				checkers = new List<Checker>();
				Config.Load();
				if (DateTime.Now.Day == 4 && DateTime.Now.Month == 11)
				{
					Notifications.Notify(new ImagedMessageControl("Image/koala256.png", "TheLockNLol hat heute geburtstag!", "Gratuliere ihm doch auf Facebook :)"), "http://www.facebook.de/TheLockNLol", "TheLockNLol", true);
				}
				if (Config.Settings.Checkers.Count(i => (i.Facebook == i.Name && i.Name == i.Twitch && i.Twitch == i.YouTube && i.YouTube == "TheLockNLol")) == 0)
				{
					Config.Settings.Checkers.Add(new CheckerFormat() { Name = "TheLockNLol", Enabled = true, Facebook = "TheLockNLol", Twitch = "TheLockNLol", YouTube = "TheLockNLol" });
				}
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
		}

		void OnClear(object sender, EventArgs ev)
		{
			try
			{
				notifications.Controls.Clear();
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
		}

		public Controls.NotifyList GetList(string tag)
		{
			try
			{
				foreach (Control c in notifications.Controls)
				{
					if (c is Controls.NotifyList)
					{
						Controls.NotifyList l = (Controls.NotifyList)c;
						if (l.NameTag == tag) return l;
					}
				}
			}
			catch (Exception e)
			{
				ThrowError(e);
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
							Notifications.Notify(new ImagedMessageControl("Image/koala256.png", "Update verfügbar!", "Es ist ein Update verfügbar! Drücke mich um es zu Downloaden."), link, "Update", true);
						}
					}
				}
				return true;
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
			return false;
		}

		void OnMessage(object sender, Notification ev)
		{
			try
			{
				string s = sender.ToString();
				GetList(s).AddNotification(ev);
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
		}

		private void btnRefresh_Click(object sender, EventArgs ev)
		{
			try
			{
				RefreshThings();
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
		}

		public void RefreshThings()
		{
			try
			{
				checkers.ForEach(e => { e.Check(); });
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
		}

		private void btnOptions_Click(object sender, EventArgs ev)
		{
			try
			{
				new Forms.OptionsForm().ShowDialog();
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
		}

		private void tsbAbout_Click(object sender, EventArgs ev)
		{
			try
			{
				new Forms.About().ShowDialog();
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
		}

		private void MainForm_Load(object sender, EventArgs ev)
		{
			try
			{
				if (!CheckForUpdate()) MessageBox.Show("Es konnte nicht nach neuen Updates geprüft werden!");
				foreach (CheckerFormat f in Config.Settings.Checkers)
				{
					if (f.Enabled)
					{
						Checker c = new Checker(f.Name, f.Twitch, f.YouTube, f.Facebook);
						checkers.Add(c);
						Controls.NotifyList l = new Controls.NotifyList(f.Name);
						l.RequestMore += (s, eve) => { c.Check(); };
						notifications.Controls.Add(l);
					}
				}
				refresher.RunWorkerAsync();
			}
			catch (Exception e)
			{
				ThrowError(e);
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
			try
			{
				if (WindowState == FormWindowState.Minimized)
				{
					WindowState = lastState;
				}
				bool top = TopMost;
				TopMost = true;
				TopMost = top;
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
		}

		private void trayClose_Click(object sender, EventArgs ev)
		{
			try
			{
				mayClose = true;
				Close();
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
		}

		private void trayOptions_Click(object sender, EventArgs ev)
		{
			try
			{
				new Forms.OptionsForm().ShowDialog();
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
		}

		private void trayAbout_Click(object sender, EventArgs ev)
		{
			try
			{
				new Forms.About().ShowDialog();
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs ev)
		{
			try
			{
				if (!mayClose)
				{
					ev.Cancel = true;
					lastState = WindowState;
					WindowState = FormWindowState.Minimized;
					Hide();
				}
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
		}

		private void trayIcon_DoubleClick(object sender, EventArgs ev)
		{
			try
			{
				Show();
				WindowState = lastState;
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
		}

		private void notificationTimer_Tick(object sender, EventArgs ev)
		{
			try
			{
				Notifications.FetchNotification();
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
		}

		private void refresher_DoWork(object sender, DoWorkEventArgs ev)
		{
			while (true)
			{
				try
				{
					RefreshThings();
					Thread.Sleep(10000);
				}
				catch (Exception e)
				{
					ThrowError(e);
				}
			}
		}

		public void ThrowError(Exception e)
		{
			new Forms.ErrorForm(e).Show();
		}
	}
}
