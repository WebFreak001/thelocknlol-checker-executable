using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms.Forms
{
	public partial class About : Form
	{
		public About()
		{
			InitializeComponent();
			text.ReadOnly = true;
			text.SelectionAlignment = HorizontalAlignment.Center;
			text.SelectionFont = new System.Drawing.Font(text.SelectionFont.FontFamily, 12f, FontStyle.Bold);
			text.AppendText("TheLockNLol Checker ");
			text.SelectionColor = Color.Gray;
			text.SelectionFont = new System.Drawing.Font(text.SelectionFont.FontFamily, 12f, FontStyle.Regular);
			text.AppendText("v" + (Version.VersionNumber * 0.1f).ToString().Replace(',', '.') + "\n");
			text.SelectionColor = Color.Black;
			text.SelectionFont = new System.Drawing.Font(text.SelectionFont.FontFamily, 4f);
			text.AppendText("\n");
			text.SelectionFont = new System.Drawing.Font(text.SelectionFont.FontFamily, 10f);
			text.AppendText("Code: WebFreak001\n");
			text.SelectionFont = new System.Drawing.Font(text.SelectionFont.FontFamily, 10f);
			text.AppendText("Design: TheLockNLol, WebFreak001\n");
			text.SelectionFont = new System.Drawing.Font(text.SelectionFont.FontFamily, 4f);
			text.AppendText("\n");
			text.SelectionFont = new System.Drawing.Font(text.SelectionFont.FontFamily, 11f);
			text.AppendText("http://www.github.com/WebFreak001/thelocknlol-checker-executable");
			text.SelectionProtected = true;
		}

		private void text_KeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
		}

		private void text_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void text_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			Process.Start(e.LinkText);
		}
	}
}
