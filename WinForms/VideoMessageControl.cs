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
		public VideoMessageControl(string image, string text, string link)
		{
			InitializeComponent();
			string v = HttpUtility.ParseQueryString(new Uri(link).Query).Get("v");
			flaVideo.Movie = v;
			bitImage.LoadAsync(image);
			rtfText.Text = text;
		}

		private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
		{
			splitContainer2.Panel1.Width = splitContainer2.Panel1.Height;
		}
	}
}
