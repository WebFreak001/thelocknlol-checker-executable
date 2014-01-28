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
		public string Image, Title, Desc;

		public ImagedMessageControl()
		{
			InitializeComponent();
			Image = "";
			Title = "";
			Desc = "";
		}
		public ImagedMessageControl(string image, string title, string text)
		{
			InitializeComponent();
			Image = image;
			Title = title;
			Desc = text;
			bitImage.LoadAsync(image);
			rtfTitle.Text = title;
			rtfDesc.Text = text;
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			RefreshSize();
		}

		private void bitImage_LoadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			RefreshSize();
		}

		public void RefreshSize()
		{
			bitImage.Width = splitter.Panel1.Width;
			bitImage.Height = bitImage.Width;
		}
	}
}
