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
			MessageManager.OnMessage += OnMessage;
			MessageManager.OnClear += OnClear;
			Config.Load();
			if (DateTime.Now.Day == 4 && DateTime.Now.Month == 11)
			{
				MessageManager.Notify("TheLockNLol", "http://www.facebook.de/TheLockNLol", "Image/koala256.png", "TheLockNLol hat heute geburtstag!", "Gratuliere ihm doch auf Facebook :)");
			}
			CheckForUpdate();
			if (Config.Settings.Checkers.Count(i => (i.Facebook == i.Name && i.Name == i.Twitch && i.Twitch == i.Twitter && i.Twitter == i.YouTube && i.YouTube == "TheLockNLol")) == 0)
			{
				checkers.Add(new Checker("TheLockNLol", "TheLockNLol", "TheLockNLol", "TheLockNLol", "TheLockNLol"));
			}
			foreach(CheckerFormat f in Config.Settings.Checkers)
			{
				if(f.Enabled) checkers.Add(new Checker(f.Name, f.Twitch, f.YouTube, f.Facebook, f.Twitter));
			}
		}

		void OnClear(object sender, EventArgs e)
		{
			layout.Controls.Clear();
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
							Notifications.Notify(new ImagedMessageControl("", "Update verfügbar!", "Es ist ein Update verfügbar! Drücke mich um es zu Downloaden."), link);
						}
					}
				}
			}
			catch
			{
				Console.WriteLine("Couldnt Check for updates!");
			}
		}

		void OnMessage(object sender, Control e)
		{
			string s = sender.ToString();
			layout.SuspendLayout();
			layout.Controls.Add(e);
			ResizeThings();
			layout.ResumeLayout();
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
			if (layout.Controls.Count != 0)
			{
				List<Control> c = new List<Control>();
				foreach (Control co in layout.Controls) c.Add(co);
				c.ForEach(i =>
				{
					i.Width = Math.Max(1, Width - 100) / 2;
					i.Height = (int)((i.Width) / 16.0f * 9.0f + i.Height * 0.3f);
					i.Refresh();
				});
			}
		}

		private void lvFilter_ItemChecked(object sender, ItemCheckedEventArgs e)
		{

		}
	}
}
