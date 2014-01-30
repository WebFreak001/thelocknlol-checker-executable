using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
			MessageManager.OnMessage += OnMessage;
		}

		void OnMessage(object sender, Control e)
		{
			layout.SuspendLayout();
			layout.Controls.Add(e);
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
			tllChecker.checkTwitch();
			tllChecker.checkYoutube();
		}

		private void btnOptions_Click(object sender, EventArgs e)
		{
			new Forms.OptionsForm().ShowDialog();
		}
	}
}
