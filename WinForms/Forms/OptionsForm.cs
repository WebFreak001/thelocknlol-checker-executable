﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Forms
{
	public partial class OptionsForm : Form
	{
		ConfigFormat tempConfig;
		Bitmap palette;
		public bool ChangedCheckers = false;

		public OptionsForm()
		{
			InitializeComponent();
			ResetChanges();
		}

		private void btnAddSound_Click(object sender, EventArgs e)
		{
			tryFile(tbSoundFile.Text.Trim(), true);
		}

		public void tryFile(string f, bool mayPick)
		{
			List<ListViewItem> items = new List<ListViewItem>();
			foreach (ListViewItem i in lvSounds.Items) items.Add(i);
			if (items.Count(l => l.Text.ToLower().Trim() == f.ToLower().Trim()) > 0) return;

			bool searchForFile = false;
			if (f == "")
			{
				searchForFile = true;
			}
			else if (!File.Exists(f)) searchForFile = true;
			if (searchForFile)
			{
				if (mayPick)
				{
					OpenFileDialog d = new OpenFileDialog();
					string dir = "";
					if (f.Trim() != "" && (f.Contains("/") || f.Contains("\\"))) dir = Path.GetFullPath(Path.GetDirectoryName(f));
					if (Directory.Exists(dir)) d.InitialDirectory = dir;
					d.Filter = "Sound File (*.wav)|*.wav";
					DialogResult r = d.ShowDialog();
					if (r == DialogResult.OK)
					{
						string file = d.FileName;
						Uri root = new Uri(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
						Uri target = new Uri(file);
						string relative = root.MakeRelativeUri(target).ToString();
						if (!relative.Contains("..")) file = relative;
						tbSoundFile.Text = file.Replace('\\', '/');
						tryFile(tbSoundFile.Text.Trim(), false);
					}
				}
			}
			else
			{
				if (f.Trim().ToLower().EndsWith(".wav"))
				{
					tbSoundFile.Text = "";
					lvSounds.Items.Add(new ListViewItem(f) { Group = lvSounds.Groups[2] });
				}
			}
			tbSoundFile_TextChanged(null, null);
		}

		public void RefreshAnnoyance()
		{
			cbNotifyLivestream.Enabled = Notifications.ShowNow;
			cbNotifyVideo.Enabled = Notifications.ShowNow;
			cbNotifySocial.Enabled = Notifications.ShowNow;
			cbCombineVidSocial.Enabled = Notifications.ShowNow;
			cbSoundVidup.Enabled = Notifications.ShowNow;
			cbSoundFBook.Enabled = Notifications.ShowNow;
			cbSoundLivestream.Enabled = Notifications.ShowNow;
		}

		private void OptionsForm_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < lvSounds.Items.Count; i++) cbSound.Items.Add(lvSounds.Items[i].Text);
			cbSound.SelectedIndex = 0;
			RefreshAnnoyance();
		}

		private void tbSoundFile_TextChanged(object sender, EventArgs e)
		{
			List<ListViewItem> items = new List<ListViewItem>();
			foreach (ListViewItem i in lvSounds.Items) items.Add(i);
			if (items.Count(l => l.Text.ToLower().Trim() == tbSoundFile.Text.ToLower().Trim()) > 0) btnAddSound.Enabled = false;
			else btnAddSound.Enabled = true;
			if (tbSoundFile.Text.Trim() == "") btnAddSound.Text = "Durchsuchen";
			else
			{
				if (!File.Exists(tbSoundFile.Text.Trim()) || !tbSoundFile.Text.Trim().ToLower().EndsWith(".wav")) btnAddSound.Text = "Durchsuchen";
				else btnAddSound.Text = "Hinzufügen";
			}
		}

		private void btnPreviewSound_Click(object sender, EventArgs e)
		{
			if (File.Exists(cbSound.Items[cbSound.SelectedIndex].ToString()) || cbSound.Items[cbSound.SelectedIndex].ToString().Trim().ToLower().StartsWith("system:"))
			{
				btnPreviewSound.Enabled = false;
				PlaySound(cbSound.Items[cbSound.SelectedIndex].ToString(), () => { btnPreviewSound.Enabled = true; });
			}
			else
			{
				List<ListViewItem> items = new List<ListViewItem>();
				foreach (ListViewItem i in lvSounds.Items) items.Add(i);
				if (items.Count(l => l.Text.ToLower().Trim() == cbSound.Items[cbSound.SelectedIndex].ToString().ToLower().Trim()) > 0)
				{
					ListViewItem i = items.Where(l => l.Text.ToLower().Trim() == cbSound.Items[cbSound.SelectedIndex].ToString().ToLower().Trim()).FirstOrDefault();

					DialogResult r = MessageBox.Show(cbSound.Items[cbSound.SelectedIndex] + " konnte nicht gefunden werden!\nDatei aus der Liste entfernen?", "Fehler", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
					if (r == DialogResult.Yes)
					{
						if (lvSounds.Items.Contains(i)) lvSounds.Items.Remove(i);
						else MessageBox.Show("...");
					}
				}
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			Forms.AddChecker c = new Forms.AddChecker();
			c.ShowDialog();
			if(c.Success)
			{
				ListViewItem i = new ListViewItem(c.TagName);
				i.SubItems.Add(new ListViewItem.ListViewSubItem(i, "" + c.YouTube));
				i.SubItems.Add(new ListViewItem.ListViewSubItem(i, "" + c.Twitch));
				i.SubItems.Add(new ListViewItem.ListViewSubItem(i, "" + c.Facebook));
				lvCheckers.Items.Add(i);
			}
			UpdateCheckers();
		}

		private void btnRem_Click(object sender, EventArgs ev)
		{
			List<ListViewItem> items = new List<ListViewItem>();
			foreach (ListViewItem i in lvCheckers.SelectedItems) items.Add(i);
			items.Where(e => e.Text.ToLower().Trim() != "thelocknlol").ToList().ForEach(e => lvCheckers.Items.Remove(e));
			UpdateCheckers();
		}

		public void UpdateCheckers()
		{
			List<CheckerFormat> checks = new List<CheckerFormat>();
			foreach (ListViewItem i in lvCheckers.Items)
			{
				checks.Add(new CheckerFormat() { Name = i.Text, YouTube = i.SubItems[1].Text, Twitch = i.SubItems[2].Text, Facebook = i.SubItems[3].Text, Enabled = i.Checked });
			}
			tempConfig.Checkers = checks;
		}

		private void btnResetChanges_Click(object sender, EventArgs e)
		{
			DialogResult r = MessageBox.Show("Wollen Sie ihre Änderungen wirklich verwerfen?", "Warnung!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (r == DialogResult.Yes) ResetChanges();
		}

		public void ResetChanges()
		{
			tempConfig = Config.Settings.Copy();
			lvCheckers.Items.Clear();
			if(tempConfig.Checkers.Count(i => (i.Facebook == i.Name && i.Name == i.Twitch && i.Twitch == i.YouTube && i.YouTube == "TheLockNLol")) == 0)
			{
				ListViewItem i = new ListViewItem("TheLockNLol");
				i.SubItems.Add("TheLockNLol");
				i.SubItems.Add("TheLockNLol");
				i.SubItems.Add("TheLockNLol");
				i.Checked = true;
				lvCheckers.Items.Add(i);
			}
			foreach(CheckerFormat c in tempConfig.Checkers)
			{
				ListViewItem i = new ListViewItem(c.Name);
				i.SubItems.Add("" + c.YouTube);
				i.SubItems.Add("" + c.Twitch);
				i.SubItems.Add("" + c.Facebook);
				i.Checked = c.Enabled;
				lvCheckers.Items.Add(i);
			}
			cbSoundVidup.Checked = tempConfig.Sounds.OnVideo;
			cbSoundLivestream.Checked = tempConfig.Sounds.OnLivestream;
			cbSoundFBook.Checked = tempConfig.Sounds.OnFacebook;
			cbSound.SelectedItem = tempConfig.CurrentSound;

			cbNotifyVideo.Checked = tempConfig.CheckVideo;
			cbNotifySocial.Checked = tempConfig.CheckSocial;
			cbNotifyLivestream.Checked = tempConfig.CheckLivestream;

			tbDuration.Value = Math.Max(tbDuration.Minimum, Math.Min(tbDuration.Maximum, tempConfig.NotifyDelay));
			tbDuration_Scroll(null, EventArgs.Empty);
			palette = new Bitmap(Image.FromStream(new MemoryStream(File.ReadAllBytes("Image/Palette.png"))));
			pictureBox0.BackColor = palette.GetPixel(0, 0);
			pictureBox1.BackColor = palette.GetPixel(1, 0);
			pictureBox2.BackColor = palette.GetPixel(2, 0);
			pictureBox3.BackColor = palette.GetPixel(3, 0);
			pictureBox4.BackColor = palette.GetPixel(4, 0);
			pictureBox5.BackColor = palette.GetPixel(5, 0);
			pictureBox6.BackColor = palette.GetPixel(6, 0);
			pictureBox7.BackColor = palette.GetPixel(7, 0);
			pictureBox8.BackColor = palette.GetPixel(8, 0);
			pictureBox9.BackColor = palette.GetPixel(9, 0);
			
			List<Control> cons = new List<Control>();
			foreach(Control ci in groupBox2.Controls) cons.Add(ci);
			foreach(Control b in cons.Where(e => e.Name.StartsWith("pictureBox")))
			{
				if(b.Name == "pictureBox" + tempConfig.NotifyColor) ((PictureBox)b).BorderStyle = BorderStyle.Fixed3D;
			}

			tbReloadLength.Value = Math.Max(tbReloadLength.Minimum, Math.Min(tbReloadLength.Maximum, tempConfig.LoadMoreNotifications));
			tbMaxNotify.Value = Math.Max(tbMaxNotify.Minimum, Math.Min(tbMaxNotify.Maximum, tempConfig.MaxNotifications));
			lbReload.Text = tbReloadLength.Value + "";
			lbMaxNotify.Text = tbMaxNotify.Value + "";

			cbAutostart.Checked = tempConfig.AutoStart;
		}

		private void btnSaveAndClose_Click(object sender, EventArgs e)
		{
			SaveChanges();
			Close();
		}

		public void SaveChanges()
		{
			if (Config.Settings.Checkers != tempConfig.Checkers) ChangedCheckers = true;
			Config.Settings = tempConfig.Copy();
			Config.Save();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveChanges();
		}

		public void PlaySound(string s, Action done)
		{
			if (s.ToLower().StartsWith("system:"))
			{
				string sound = s.Split(':')[1].ToLower().Trim();
				if (sound == "asterisk") SystemSounds.Asterisk.Play();
				if (sound == "beep") SystemSounds.Beep.Play();
				if (sound == "exclamation") SystemSounds.Exclamation.Play();
				if (sound == "hand") SystemSounds.Hand.Play();
				if (sound == "question") SystemSounds.Question.Play();
				done();
			}
			else
			{
				SoundPlayer p = new SoundPlayer(s);
				p.LoadCompleted += (a, b) =>
				{
					p.Play();
					done();
				};
				p.LoadAsync();
			}
		}

		private void cbSoundVidup_CheckedChanged(object sender, EventArgs e)
		{
			tempConfig.Sounds.OnVideo = cbSoundVidup.Checked;
		}

		private void cbSoundLivestream_CheckedChanged(object sender, EventArgs e)
		{
			tempConfig.Sounds.OnLivestream = cbSoundLivestream.Checked;
		}

		private void cbSoundFBook_CheckedChanged(object sender, EventArgs e)
		{
			tempConfig.Sounds.OnFacebook = cbSoundFBook.Checked;
		}

		private void cbNotifyVideo_CheckedChanged(object sender, EventArgs e)
		{
			tempConfig.CheckVideo = cbNotifyVideo.Checked;
		}

		private void cbNotifySocial_CheckedChanged(object sender, EventArgs e)
		{
			tempConfig.CheckSocial = cbNotifySocial.Checked;
		}

		private void cbNotifyLivestream_CheckedChanged(object sender, EventArgs e)
		{
			tempConfig.CheckLivestream = cbNotifyLivestream.Checked;
		}

		private void cbCombineVidSocial_CheckedChanged(object sender, EventArgs e)
		{
			tempConfig.MergeSocialVideo = cbCombineVidSocial.Checked;
		}

		private void cbSound_SelectedIndexChanged(object sender, EventArgs e)
		{
			tempConfig.CurrentSound = cbSound.SelectedItem.ToString();
		}

		private void tbDuration_Scroll(object sender, EventArgs e)
		{
			if (tbDuration.Value == tbDuration.Maximum)
			{
				lbNotifyDura.Text = "Unendlich";
			}
			else
			{
				lbNotifyDura.Text = Math.Round(tbDuration.Value * 0.1f, 1) + " Sek.";
			}
			tempConfig.NotifyDelay = tbDuration.Value;
		}

		private void lvCheckers_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			List<CheckerFormat> x = tempConfig.Checkers.Where(i => i.Name == e.Item.Text).ToList();
			if(x.Count != 0) x.First().Enabled = e.Item.Checked;
		}

		public void ResetBorder()
		{
			pictureBox0.BorderStyle = BorderStyle.None;
			pictureBox1.BorderStyle = BorderStyle.None;
			pictureBox2.BorderStyle = BorderStyle.None;
			pictureBox3.BorderStyle = BorderStyle.None;
			pictureBox4.BorderStyle = BorderStyle.None;
			pictureBox5.BorderStyle = BorderStyle.None;
			pictureBox6.BorderStyle = BorderStyle.None;
			pictureBox7.BorderStyle = BorderStyle.None;
			pictureBox8.BorderStyle = BorderStyle.None;
			pictureBox9.BorderStyle = BorderStyle.None;
		}

		private void pictureBox0_Click(object sender, EventArgs e)
		{
			tempConfig.NotifyColor = 0;
			ResetBorder();
			pictureBox0.BorderStyle = BorderStyle.Fixed3D;
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			tempConfig.NotifyColor = 1;
			ResetBorder();
			pictureBox1.BorderStyle = BorderStyle.Fixed3D;
		}

		private void pictureBox2_Click(object sender, EventArgs e)
		{
			tempConfig.NotifyColor = 2;
			ResetBorder();
			pictureBox2.BorderStyle = BorderStyle.Fixed3D;
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			tempConfig.NotifyColor = 3;
			ResetBorder();
			pictureBox3.BorderStyle = BorderStyle.Fixed3D;
		}

		private void pictureBox4_Click(object sender, EventArgs e)
		{
			tempConfig.NotifyColor = 4;
			ResetBorder();
			pictureBox4.BorderStyle = BorderStyle.Fixed3D;
		}

		private void pictureBox5_Click(object sender, EventArgs e)
		{
			tempConfig.NotifyColor = 5;
			ResetBorder();
			pictureBox5.BorderStyle = BorderStyle.Fixed3D;
		}

		private void pictureBox6_Click(object sender, EventArgs e)
		{
			tempConfig.NotifyColor = 6;
			ResetBorder();
			pictureBox6.BorderStyle = BorderStyle.Fixed3D;
		}

		private void pictureBox7_Click(object sender, EventArgs e)
		{
			tempConfig.NotifyColor = 7;
			ResetBorder();
			pictureBox7.BorderStyle = BorderStyle.Fixed3D;
		}

		private void pictureBox8_Click(object sender, EventArgs e)
		{
			tempConfig.NotifyColor = 8;
			ResetBorder();
			pictureBox8.BorderStyle = BorderStyle.Fixed3D;
		}

		private void pictureBox9_Click(object sender, EventArgs e)
		{
			tempConfig.NotifyColor = 9;
			ResetBorder();
			pictureBox9.BorderStyle = BorderStyle.Fixed3D;
		}

		private void btnMvDown_Click(object sender, EventArgs e)
		{
			try
			{
				if (lvCheckers.SelectedItems.Count > 0)
				{
					ListViewItem selected = lvCheckers.SelectedItems[0];
					int indx = selected.Index;
					int totl = lvCheckers.Items.Count;

					if (indx == totl - 1)
					{
						lvCheckers.Items.Remove(selected);
						lvCheckers.Items.Insert(0, selected);
					}
					else
					{
						lvCheckers.Items.Remove(selected);
						lvCheckers.Items.Insert(indx + 1, selected);
					}
				}
			}
			catch
			{
			}
			UpdateCheckers();
		}

		private void btnMvUp_Click(object sender, EventArgs e)
		{
			try
			{
				if (lvCheckers.SelectedItems.Count > 0)
				{
					ListViewItem selected = lvCheckers.SelectedItems[0];
					int indx = selected.Index;
					int totl = lvCheckers.Items.Count;

					if (indx == 0)
					{
						lvCheckers.Items.Remove(selected);
						lvCheckers.Items.Insert(totl - 1, selected);
					}
					else
					{
						lvCheckers.Items.Remove(selected);
						lvCheckers.Items.Insert(indx - 1, selected);
					}
				}
			}
			catch
			{
			}
			UpdateCheckers();
		}

		private void cbAutostart_CheckedChanged(object sender, EventArgs e)
		{
			tempConfig.AutoStart = cbAutostart.Checked;
		}

		private void tbReloadLength_Scroll(object sender, EventArgs e)
		{
			lbReload.Text = tbReloadLength.Value + "";
			tempConfig.LoadMoreNotifications = tbReloadLength.Value;
		}

		private void tbMaxNotify_Scroll(object sender, EventArgs e)
		{
			lbMaxNotify.Text = tbMaxNotify.Value + "";
			tempConfig.MaxNotifications = tbMaxNotify.Value;
		}

		private void btnSleepHour_Click(object sender, EventArgs e)
		{
			Notifications.Allow = DateTime.Now + new TimeSpan(1, 0, 0);
		}

		private void btnSleep2Hour_Click(object sender, EventArgs e)
		{
			Notifications.Allow = DateTime.Now + new TimeSpan(2, 0, 0);
		}

		private void cbDoNotAnnoyMe_CheckedChanged(object sender, EventArgs e)
		{
			Notifications.ShowNow = !cbDoNotAnnoyMe.Checked;
			RefreshAnnoyance();
		}
	}
}
