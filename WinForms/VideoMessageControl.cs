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
			flaVideo.Movie = v;
			descControl.Image = image;
			descControl.Title = text;
			descControl.Desc = desc;
			descControl.RefreshSize();
			descControl.Refresh();
		}
	}
}
