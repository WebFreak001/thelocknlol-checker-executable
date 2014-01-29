using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
			tryFile(tbSoundFile.Text.Trim());
		}

		public void tryFile(string f)
		{
			bool searchForFile = false;
			if (f == "")
			{
				searchForFile = true;
			}
			else if (!File.Exists(f)) searchForFile = true;
			if (searchForFile)
			{
				OpenFileDialog d = new OpenFileDialog();
				d.Filter = "Sound File (*.wav)|*.wav";
				DialogResult r = d.ShowDialog();
				if(r == DialogResult.OK)
				{
					 string file = d.FileName;
					 tbSoundFile.Text = file;
					 tryFile(file.Trim());
				}
			}
			else
			{
				lvSounds.Items.Add(new ListViewItem(f));
			}
		}

		private void OptionsForm_Load(object sender, EventArgs e)
		{
			for(int i = 0; i < lvSounds.Items.Count; i++) cbSound.Items.Add(lvSounds.Items[i].Text);
			cbSound.SelectedIndex = 0;
		}
	}
}
