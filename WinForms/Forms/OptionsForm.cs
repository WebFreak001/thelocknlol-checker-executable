using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Forms
{
	public partial class OptionsForm : Form
	{
		public OptionsForm()
		{
			InitializeComponent();
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
					lvSounds.Items.Add(new ListViewItem(f));
				}
			}
			tbSoundFile_TextChanged(null, null);
		}

		private void OptionsForm_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < lvSounds.Items.Count; i++) cbSound.Items.Add(lvSounds.Items[i].Text);
			cbSound.SelectedIndex = 0;
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
			if (File.Exists(cbSound.Items[cbSound.SelectedIndex].ToString()))
			{
				btnPreviewSound.Enabled = false;
				SoundPlayer p = new SoundPlayer(cbSound.Items[cbSound.SelectedIndex].ToString());
				p.LoadCompleted += (a, b) =>
				{
					p.Play();
					btnPreviewSound.Enabled = true;
				};
				p.LoadAsync();
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
	}
}
