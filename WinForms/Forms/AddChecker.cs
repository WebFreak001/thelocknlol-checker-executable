using System;
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

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (tbTagName.Text.Trim() == "")
			{
				MessageBox.Show("Bitte benennen Sie diese Person!", "Fehler");
				return;
			}
			if (tbYouTube.Text.Contains("/") && !tbYouTube.Text.ToLower().Contains("youtube"))
			{
				MessageBox.Show("Bitte geben sie einen richtigen YouTube namen ein!", "Fehler");
				return;
			}
			if (tbYouTube.Text.Contains("/"))
			{
				if (YouTube.EndsWith("/")) tbYouTube.Text = YouTube.Remove(YouTube.LastIndexOf('/'));
				tbYouTube.Text = YouTube.Remove(0, YouTube.LastIndexOf('/') + 1);
			}
			if (tbFacebook.Text.Contains("/") && !tbFacebook.Text.ToLower().Contains("facebook"))
			{
				MessageBox.Show("Bitte geben sie einen richtigen Facebook namen ein!", "Fehler");
				return;
			}
			if (tbFacebook.Text.Contains("/"))
			{
				if (Facebook.EndsWith("/")) tbFacebook.Text = Facebook.Remove(Facebook.LastIndexOf('/'));
				tbFacebook.Text = Facebook.Remove(0, Facebook.LastIndexOf('/') + 1);
			}
			if (tbTwitch.Text.Contains("/") && !tbTwitch.Text.ToLower().Contains("twitch"))
			{
				MessageBox.Show("Bitte geben sie einen richtigen Twitch namen ein!", "Fehler");
				return;
			}
			if (tbTwitch.Text.Contains("/"))
			{
				if (Twitch.EndsWith("/")) tbTwitch.Text = Twitch.Remove(Twitch.LastIndexOf('/'));
				tbTwitch.Text = Twitch.Remove(0, Twitch.LastIndexOf('/') + 1);
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
