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
		public MainForm()
		{
			InitializeComponent();
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Notifications.Notify(new ImagedMessageControl("https://yt3.ggpht.com/-7dHUz8U42ho/AAAAAAAAAAI/AAAAAAAAAAA/b49kPOMZUYM/s48-c-k-no/photo.jpg", "Test", "This is a example"));
		}
	}
}
