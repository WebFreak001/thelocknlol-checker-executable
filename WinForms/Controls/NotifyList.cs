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
		public string NameTag { get { return cbNamePicker.SelectedItem.ToString(); } set { cbNamePicker.SelectedItem = value; } }

		public NotifyList()
		{
			InitializeComponent();
			List<string> tags = new List<string>();
			Config.Settings.Checkers.ForEach(f => tags.Add(f.Name));
			cbNamePicker.Items.AddRange(tags.ToArray());
			cbNamePicker.Items.Add("<None>");
			cbNamePicker.SelectedItem = "<None>";
		}

		public NotifyList(string tag)
			: this()
		{
			Change(tag);
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
			c.Size = new Size(Width, n.Height);
			layout.Controls.Add(c);
			layout.ResumeLayout();
			List<Control> l = new List<Control>();
			foreach (Control c2 in layout.Controls) l.Add(c2);
			Height = header.Height + l.Sum(e => e.Height) + footer.Height + 10;
		}

		private void btnLoadMore_Click(object sender, EventArgs e)
		{
			Request();
		}

		public void Change(string tag)
		{
			if (cbNamePicker.Items.Contains(tag))
			{
				cbNamePicker.SelectedItem = tag;
				Request();
			}
		}

		protected void Request()
		{
			if (RequestMore != null && cbNamePicker.SelectedItem.ToString() != "<None>") RequestMore(null, EventArgs.Empty);
		}

		private void cbNamePicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (RequestMore != null && cbNamePicker.SelectedItem.ToString() != "<None>")
			{
				RequestMore(null, EventArgs.Empty);
				RequestMore(null, EventArgs.Empty);
				RequestMore(null, EventArgs.Empty);
				RequestMore(null, EventArgs.Empty);
				RequestMore(null, EventArgs.Empty);
			}
		}
	}
}
