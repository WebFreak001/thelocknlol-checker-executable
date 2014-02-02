﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Forms
{
	public partial class AddChecker : Form
	{
		public string TagName { get { return tbTagName.Text; } }
		public string YouTube { get { return tbYouTube.Text; } }
		public string Twitch { get { return tbTwitch.Text; } }
		public string Facebook { get { return tbFacebook.Text; } }
		public string Twitter { get { return tbTwitter.Text; } }
		public bool Success { get; protected set; }

		public AddChecker()
		{
			InitializeComponent();
		}

		private void cbYouTube_CheckedChanged(object sender, EventArgs e)
		{
			tbYouTube.Enabled = cbYouTube.Checked;
		}

		private void cbTwitch_CheckedChanged(object sender, EventArgs e)
		{
			tbTwitch.Enabled = cbTwitch.Checked;
		}

		private void cbFacebook_CheckedChanged(object sender, EventArgs e)
		{
			tbFacebook.Enabled = cbFacebook.Checked;
		}

		private void cbTwitter_CheckedChanged(object sender, EventArgs e)
		{
			tbTwitter.Enabled = cbTwitter.Checked;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if(tbTagName.Text.Trim() == "")
			{
				MessageBox.Show("Bitte benennen Sie diese Person!", "Fehler");
				return;
			}
			Success = true;
			Close();
		}

		private void btnRem_Click(object sender, EventArgs e)
		{
			Success = false;
			Close();
		}
	}
}
