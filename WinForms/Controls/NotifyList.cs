using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace WinForms.Controls
{
	public partial class NotifyList : UserControl
	{
		public event EventHandler RequestMore;
		public string NameTag { get { return lbName.Text; } set { lbName.Text = value; } }

		public NotifyList()
		{
			InitializeComponent();
		}

		public NotifyList(string tag)
		{
			InitializeComponent();
			Change(tag);
			Request();
		}

		public void AddNotification(Notification n)
		{
			layout.SuspendLayout();
			//n.Parent = layout;
			NotificationControl c = n.ToControl();
			c.Refresh();
			c.Visible = true;
			c.Parent = layout;
			c.Location = new Point(0, 0);
			c.Size = new Size(c.Width, n.Height);
			layout.Controls.Add(c);
			layout.ResumeLayout();
			List<Control> l = new List<Control>();
			foreach (Control c2 in layout.Controls) l.Add(c2);
			Height = Math.Min(1000, header.Height + l.Sum(e => e.Height) + footer.Height + 50);
		}

		private void btnLoadMore_Click(object sender, EventArgs e)
		{
			Request();
		}

		public void Change(string tag)
		{
			lbName.Text = tag;
			Request();
		}

		protected void Request()
		{
			if (RequestMore != null && lbName.Text != "<None>") RequestMore(null, EventArgs.Empty);
		}

		private void cbNamePicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			Request();
		}
	}
}
