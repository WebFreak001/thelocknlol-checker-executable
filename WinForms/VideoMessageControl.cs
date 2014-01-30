using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace WinForms
{
	public partial class VideoMessageControl : UserControl
	{
		public VideoMessageControl(string image, string text, string desc, string link)
		{
			InitializeComponent();
			string v = HttpUtility.ParseQueryString(new Uri(link).Query).Get(0);
			webBrowser.Url = new Uri("http://www.youtube.com/embed/" + v);
			ImagedMessageControl descControl = new ImagedMessageControl(image, text, desc);
			splitContainer1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			descControl.Dock = System.Windows.Forms.DockStyle.Fill;
			descControl.Location = new System.Drawing.Point(0, 0);
			descControl.Name = "descControl";
			descControl.Size = new System.Drawing.Size(441, 93);
			descControl.TabIndex = 0;
			splitContainer1.Panel2.Controls.Add(descControl);
			splitContainer1.Panel2.ResumeLayout();
			splitContainer1.ResumeLayout();
			Refresh();
		}
	}
}
