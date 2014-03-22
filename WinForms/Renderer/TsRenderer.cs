using System.Drawing;
using System.Windows.Forms;

namespace WinForms.Renderer
{
	public class TsRenderer : ToolStripSystemRenderer
	{
		private Color colorLight;
		private Color colorDark;

		public TsRenderer(Color c)
		{
			colorLight = c;
			colorDark = Color.FromArgb((int)(c.R * 0.9f), (int)(c.G * 0.9f), (int)(c.B * 0.9f));
		}

		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
		{
		}

		protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
		{
			Rectangle r = Rectangle.Inflate(e.Item.ContentRectangle, 2, 2);

			if (e.Item.Selected)
			{
				using (Brush b = new SolidBrush(colorDark))
				{
					e.Graphics.FillRectangle(b, r);
				}
			}
			else
			{
				using (Brush b = new SolidBrush(colorLight))
				{
					e.Graphics.FillRectangle(b, r);
				}
			}
		}
	}
}