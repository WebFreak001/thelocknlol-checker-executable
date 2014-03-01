using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinForms.Controls
{
	public partial class ThemedButton : UserControl
	{
		public string ButtonText { get { return label1.Text; } set { label1.Text = value; } }
		public event EventHandler OnClick;

		public ThemedButton()
		{
			InitializeComponent();
		}

		private void ThemedButton_Load(object sender, EventArgs e)
		{
			if (!DesignMode)
			{
				Bitmap b = new Bitmap(Image.FromStream(new MemoryStream(File.ReadAllBytes("Image/Palette.png"))));
				Color c = b.GetPixel(Config.Settings.NotifyColor, 2);
				BackColor = Color.FromArgb((int)(c.R * 0.7f), (int)(c.G * 0.7f), (int)(c.B * 0.7f));
				label1.ForeColor = b.GetPixel(Config.Settings.NotifyColor, 1);
			}
		}

		private void label1_Click(object sender, EventArgs e)
		{
			if (OnClick != null) OnClick(sender, e);
		}
	}
}
