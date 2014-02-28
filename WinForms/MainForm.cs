#if !DEBUG
#define R
#endif

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
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
		int value;

		public MainForm()
		{
#if R
			try
			{
#endif
				InitializeComponent();
				checkers = new List<Checker>();
				Config.Load();
				if (Config.Settings.Checkers.Count(i => (i.Facebook == i.Name && i.Name == i.Twitch && i.Twitch == i.YouTube && i.YouTube == "TheLockNLol")) == 0)
				{
					Config.Settings.Checkers.Add(new CheckerFormat() { Name = "TheLockNLol", Enabled = true, Facebook = "TheLockNLol", Twitch = "TheLockNLol", YouTube = "TheLockNLol" });
				}
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
		}

		void OnClear(object sender, EventArgs ev)
		{
#if R
			try
			{
#endif
				notifications.Controls.Clear();
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
		}

		public Controls.NotifyList GetList(string tag)
		{
#if R
			try
			{
#endif
				foreach (Control c in notifications.Controls)
				{
					if (c is Controls.NotifyList)
					{
						Controls.NotifyList l = (Controls.NotifyList)c;
						if (l.NameTag == tag) return l;
					}
				}
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
			return null;
		}

		public bool CheckForUpdate()
		{
#if R
			try
			{
#endif
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
							Notifications.NotifyGeneric(new ImagedMessageControl("Image/koala256.png", "Update verfügbar!", "Es ist ein Update verfügbar! Drücke mich um es zu Downloaden."), link, "Update", true);
						}
					}
				}
				return true;
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
			return false;
		}

		void OnGenericMessage(object sender, Notification ev)
		{
#if R
			try
			{
#endif
				string s = sender.ToString();
				Controls.NotifyList n = GetList(s);
				if (n != null)
				{
					List<Control> cs = new List<Control>();
					foreach (Control c in n.GetControls())
					{
						if (c is Controls.NotificationControl)
						{
							Controls.NotificationControl con = ev.ToControl();
							if (con.title == ((Controls.NotificationControl)c).title && con.desc == ((Controls.NotificationControl)c).desc) return;
						}
						cs.Add(c);
					}
					n.GetControls().Clear();
					n.AddGenericNotification(ev);
					n.GetControls().AddRange(cs.ToArray());
					n.AddGenericNotification(null);
				}
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
		}

		void OnYoutubeMessage(object sender, NotificationYoutube ev)
		{
#if R
			try
			{
#endif
				string s = sender.ToString();
				Controls.NotifyList n = GetList(s);
				if (n != null)
				{
					Controls.NotificationControl con = ev.N.ToControl();
					List<Control> cs = new List<Control>();
					foreach (Control c in n.GetControls())
					{
						if (c is Controls.NotificationControl)
						{
							if (con.title == ((Controls.NotificationControl)c).title && con.desc == ((Controls.NotificationControl)c).desc) return;
						}
						cs.Add(c);
					}
					n.GetControls().Clear();
					n.AddYouTubeNotification(ev.N, ev.Yt);
					n.GetControls().AddRange(cs.ToArray());
					n.AddGenericNotification(null);
				}
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
		}

		void OnFacebookMessage(object sender, NotificationFacebook ev)
		{
#if R
			try
			{
#endif
				string s = sender.ToString();
				Controls.NotifyList n = GetList(s);
				if (n != null)
				{
					List<Control> cs = new List<Control>();
					foreach (Control c in n.GetControls())
					{
						if (c is Controls.NotificationControl)
						{
							Controls.NotificationControl con = ev.N.ToControl();
							if (con.title == ((Controls.NotificationControl)c).title && con.desc == ((Controls.NotificationControl)c).desc) return;
						}
						cs.Add(c);
					}
					n.GetControls().Clear();
					n.AddFacebookNotification(ev.N, ev.Fb);
					n.GetControls().AddRange(cs.ToArray());
					n.AddGenericNotification(null);
				}
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
		}

		private void btnRefresh_Click(object sender, EventArgs ev)
		{
#if R
			try
			{
#endif
				RefreshThings();
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
		}

		public void RefreshThings()
		{
#if R
			try
			{
#endif
				int i = 0;
				checkers.ForEach(e => { e.Check(0, "", true); i++; value = (int)((i / (float)checkers.Count) * 100); });
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
		}

		private void btnOptions_Click(object sender, EventArgs ev)
		{
#if R
			try
			{
#endif
				new Forms.OptionsForm().ShowDialog();
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
		}

		private void tsbAbout_Click(object sender, EventArgs ev)
		{
#if R
			try
			{
#endif
				new Forms.About().ShowDialog();
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
		}

		private void RegisterInStartup(bool isChecked)
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			if (isChecked)
			{
				registryKey.SetValue("TheLockNLolChecker", Application.ExecutablePath + " -a");
			}
			else
			{
				registryKey.DeleteValue("TheLockNLolChecker");
			}
		}

		void RefreshPeople()
		{
			notifications.Controls.Clear();
			foreach (CheckerFormat f in Config.Settings.Checkers)
			{
				if (f.Enabled)
				{
					Checker c = new Checker(f.Name, f.Twitch, f.YouTube, f.Facebook);
					checkers.Add(c);
					Controls.NotifyList l = new Controls.NotifyList(f.Name);
					l.RequestMore += (s, eve) => { updateStatus.Value = 10; c.Check(eve.YouTubeCount, eve.LastFacebookDate, eve.Hidden, eve.Reverse); updateStatus.Value = 100; };
					notifications.Controls.Add(l);
				}
			}
		}

		private void MainForm_Load(object sender, EventArgs ev)
		{
#if R
			try
			{
#endif
				Notifications.OnGenericMessage += OnGenericMessage;
				Notifications.OnYouTubeMessage += OnYoutubeMessage;
				Notifications.OnFacebookMessage += OnFacebookMessage;
				if (!CheckForUpdate()) MessageBox.Show("Es konnte nicht nach neuen Updates geprüft werden!");
				RefreshPeople();
				refresher.RunWorkerAsync();

				if (Properties.Settings.Default.FirstStart)
				{
					DialogResult r = MessageBox.Show("Möchten Sie dieses Programm im AutoStart haben?\nSie können diese Einstellung jeder Zeit in den Einstellungen ändern!", "Willkommen zum TheLockNLol-Checker!", MessageBoxButtons.YesNo);
					if (r == DialogResult.Yes)
					{
						Config.Settings.AutoStart = true;
						Config.Save();
						RegisterInStartup(true);
					}
					Properties.Settings.Default.FirstStart = false;
					Properties.Settings.Default.Save();
				}
				if (DateTime.Now.Day == 4 && DateTime.Now.Month == 11)
				{
					Notifications.NotifyGeneric(new ImagedMessageControl("Image/koala256.png", "TheLockNLol hat heute geburtstag!", "Gratuliere ihm doch auf Facebook :)"), "http://www.facebook.de/TheLockNLol", "TheLockNLol", true);
				}
				RegisterInStartup(Config.Settings.AutoStart);
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
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
#if R
			try
			{
#endif
				if (WindowState == FormWindowState.Minimized)
				{
					WindowState = lastState;
				}
				bool top = TopMost;
				TopMost = true;
				TopMost = top;
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
		}

		private void trayClose_Click(object sender, EventArgs ev)
		{
#if R
			try
			{
#endif
				mayClose = true;
				Close();
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
		}

		private void trayOptions_Click(object sender, EventArgs ev)
		{
#if R
			try
			{
#endif
				new Forms.OptionsForm().ShowDialog();
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
		}

		private void trayAbout_Click(object sender, EventArgs ev)
		{
#if R
			try
			{
#endif
				new Forms.About().ShowDialog();
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs ev)
		{
#if R
			try
			{
#endif
				if (!mayClose)
				{
					ev.Cancel = true;
					lastState = WindowState;
					WindowState = FormWindowState.Minimized;
					Hide();
					if (Properties.Settings.Default.FirstHide)
					{
						trayIcon.ShowBalloonTip(8000, "TheLockNLol Checker läuft noch!", "TheLockNLol Checker läuft im Hintergrund weiter. Rechtsklicken Sie und beenden Sie dann das Programm um es zu Beenden", ToolTipIcon.Info);
						Properties.Settings.Default.FirstHide = false;
						Properties.Settings.Default.Save();
					}
				}
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
		}

		private void trayIcon_DoubleClick(object sender, EventArgs ev)
		{
#if R
			try
			{
#endif
				Show();
				WindowState = lastState;
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
		}

		private void notificationTimer_Tick(object sender, EventArgs ev)
		{
#if R
			try
			{
#endif
				Notifications.FetchNotification(this);
				updateStatus.Value = value;
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
		}

		private void refresher_DoWork(object sender, DoWorkEventArgs ev)
		{
#if R
			try
			{
#endif
				RefreshThings();
#if R
			}
			catch (Exception e)
			{
				ThrowError(e);
			}
#endif
		}

		public void MarkRead(string hint, Controls.NotificationControl n)
		{
			List<Controls.NotificationControl> controls = new List<Controls.NotificationControl>();
			foreach (Control c in GetList(hint).Controls)
			{
				if (c is Controls.NotificationControl) controls.Add((Controls.NotificationControl)c);
			}
			if (controls.Count != 0) controls.Where(i => i.title == n.title && i.desc == n.desc).First().MarkRead();
		}

		public void ThrowError(Exception e)
		{
			new Forms.ErrorForm(e).ShowDialog();
		}

		private void btnSendProps_Click(object sender, EventArgs e)
		{
			Process.Start("https://github.com/WebFreak001/thelocknlol-checker-executable/issues?state=open");
		}

		private void refreshTimer_Tick(object sender, EventArgs e)
		{
			refresher.RunWorkerAsync();
		}
	}
}
