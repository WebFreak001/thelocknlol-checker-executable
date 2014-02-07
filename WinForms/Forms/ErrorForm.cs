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
	public partial class ErrorForm : Form
	{
		public ErrorForm(Exception e)
		{
			InitializeComponent();
			textBox1.Text = "TheLockNLol Checker wurde unerwartet beendet\n\nBitte senden Sie diesen Fehler an uns!\n\n\n=============================\n\n" + e.Message + "\n" + e.Source + "\n" + e.InnerException + "\n" + e.StackTrace;
		}
	}
}
