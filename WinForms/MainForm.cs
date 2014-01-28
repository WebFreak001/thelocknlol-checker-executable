using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
	public partial class MainForm : Form
	{
		Checker tllChecker;

		public MainForm()
		{
			InitializeComponent();
			tllChecker = new Checker("TheLockNLol", "TheLockNLol", "TheLockNLol");
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			tllChecker.checkTwitch();
			tllChecker.checkYoutube();
		}
	}
}
