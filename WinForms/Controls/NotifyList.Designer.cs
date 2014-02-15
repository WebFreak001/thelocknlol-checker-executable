namespace WinForms.Controls
{
	partial class NotifyList
	{
		/// <summary> 
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.header = new System.Windows.Forms.Panel();
			this.lbName = new System.Windows.Forms.Label();
			this.layout = new System.Windows.Forms.FlowLayoutPanel();
			this.footer = new System.Windows.Forms.Panel();
			this.btnLoadMore = new System.Windows.Forms.Button();
			this.header.SuspendLayout();
			this.footer.SuspendLayout();
			this.SuspendLayout();
			// 
			// header
			// 
			this.header.Controls.Add(this.lbName);
			this.header.Dock = System.Windows.Forms.DockStyle.Top;
			this.header.Location = new System.Drawing.Point(0, 0);
			this.header.Name = "header";
			this.header.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.header.Size = new System.Drawing.Size(395, 27);
			this.header.TabIndex = 0;
			// 
			// lbName
			// 
			this.lbName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbName.Location = new System.Drawing.Point(0, 0);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(395, 22);
			this.lbName.TabIndex = 0;
			this.lbName.Text = "<None>";
			this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// layout
			// 
			this.layout.AutoScroll = true;
			this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layout.Location = new System.Drawing.Point(0, 27);
			this.layout.Name = "layout";
			this.layout.Size = new System.Drawing.Size(395, 31);
			this.layout.TabIndex = 1;
			// 
			// footer
			// 
			this.footer.Controls.Add(this.btnLoadMore);
			this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.footer.Location = new System.Drawing.Point(0, 58);
			this.footer.Name = "footer";
			this.footer.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
			this.footer.Size = new System.Drawing.Size(395, 36);
			this.footer.TabIndex = 2;
			// 
			// btnLoadMore
			// 
			this.btnLoadMore.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnLoadMore.Location = new System.Drawing.Point(0, 5);
			this.btnLoadMore.Name = "btnLoadMore";
			this.btnLoadMore.Size = new System.Drawing.Size(395, 31);
			this.btnLoadMore.TabIndex = 0;
			this.btnLoadMore.Text = "Mehr Laden";
			this.btnLoadMore.UseVisualStyleBackColor = true;
			this.btnLoadMore.Click += new System.EventHandler(this.btnLoadMore_Click);
			// 
			// NotifyList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.LightGray;
			this.Controls.Add(this.layout);
			this.Controls.Add(this.footer);
			this.Controls.Add(this.header);
			this.Name = "NotifyList";
			this.Size = new System.Drawing.Size(395, 94);
			this.header.ResumeLayout(false);
			this.footer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel header;
		private System.Windows.Forms.FlowLayoutPanel layout;
		private System.Windows.Forms.Panel footer;
		private System.Windows.Forms.Button btnLoadMore;
		private System.Windows.Forms.Label lbName;
	}
}
