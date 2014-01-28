using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
	public partial class ImagedMessageControl : UserControl
	{
		public ImagedMessageControl(string image, string text)
		{
			bitImage.LoadAsync(image);
			rtfText.Text = text;
			InitializeComponent();
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			bitImage.Height = bitImage.Width;
		}
	}
}
