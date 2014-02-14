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
	public partial class ErrorForm : Form
	{
		public ErrorForm(Exception e)
		{
			InitializeComponent();
			textBox1.Text = "TheLockNLol Checker wurde unerwartet beendet\n\nBitte senden Sie diesen Fehler an uns!\n\n\n=============================\n\n" + e.Message + "\n" + e.Source + "\n" + e.InnerException + "\n" + e.StackTrace;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Process.Start("https://github.com/WebFreak001/thelocknlol-checker-executable/issues?state=open");
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
			{
				Application.OpenForms[i].Close();
			}
		}
	}
}
