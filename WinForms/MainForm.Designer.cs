namespace WinForms
{
	partial class MainForm
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

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tsOptions = new System.Windows.Forms.ToolStrip();
			this.btnRefresh = new System.Windows.Forms.ToolStripButton();
			this.btnOptions = new System.Windows.Forms.ToolStripButton();
			this.layout = new System.Windows.Forms.FlowLayoutPanel();
			this.refreshTimer = new System.Windows.Forms.Timer(this.components);
			this.lvFilter = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tsbAbout = new System.Windows.Forms.ToolStripButton();
			this.btnUnread = new System.Windows.Forms.CheckBox();
			this.btnHistory = new System.Windows.Forms.CheckBox();
			this.tsOptions.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tsOptions
			// 
			this.tsOptions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tsOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnOptions,
            this.tsbAbout});
			this.tsOptions.Location = new System.Drawing.Point(0, 0);
			this.tsOptions.Name = "tsOptions";
			this.tsOptions.Size = new System.Drawing.Size(654, 25);
			this.tsOptions.TabIndex = 0;
			this.tsOptions.Text = "Optionen";
			// 
			// btnRefresh
			// 
			this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
			this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(79, 22);
			this.btnRefresh.Text = "Aktualisieren";
			this.btnRefresh.ToolTipText = "Prüft nach den neusten Informationen aller Kanäle";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnOptions
			// 
			this.btnOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOptions.Image")));
			this.btnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnOptions.Name = "btnOptions";
			this.btnOptions.Size = new System.Drawing.Size(61, 22);
			this.btnOptions.Text = "Optionen";
			this.btnOptions.ToolTipText = "Hier kannst du einstellen, wer angezeigt werden soll und welche Sachen angezeigt " +
    "werden sollen";
			this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
			// 
			// layout
			// 
			this.layout.AutoScroll = true;
			this.layout.BackColor = System.Drawing.SystemColors.ControlLight;
			this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layout.Location = new System.Drawing.Point(200, 25);
			this.layout.Name = "layout";
			this.layout.Size = new System.Drawing.Size(454, 422);
			this.layout.TabIndex = 1;
			// 
			// refreshTimer
			// 
			this.refreshTimer.Interval = 10000;
			this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
			// 
			// lvFilter
			// 
			this.lvFilter.CheckBoxes = true;
			this.lvFilter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.lvFilter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvFilter.GridLines = true;
			this.lvFilter.Location = new System.Drawing.Point(0, 33);
			this.lvFilter.Name = "lvFilter";
			this.lvFilter.Size = new System.Drawing.Size(200, 389);
			this.lvFilter.TabIndex = 2;
			this.lvFilter.UseCompatibleStateImageBehavior = false;
			this.lvFilter.View = System.Windows.Forms.View.Details;
			this.lvFilter.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvFilter_ItemChecked);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Prüfe";
			this.columnHeader1.Width = 195;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lvFilter);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 25);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 422);
			this.panel1.TabIndex = 3;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnHistory);
			this.panel2.Controls.Add(this.btnUnread);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(200, 33);
			this.panel2.TabIndex = 3;
			// 
			// tsbAbout
			// 
			this.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbout.Image")));
			this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAbout.Name = "tsbAbout";
			this.tsbAbout.Size = new System.Drawing.Size(36, 22);
			this.tsbAbout.Text = "Über";
			this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
			// 
			// btnUnread
			// 
			this.btnUnread.Appearance = System.Windows.Forms.Appearance.Button;
			this.btnUnread.Location = new System.Drawing.Point(3, 3);
			this.btnUnread.Name = "btnUnread";
			this.btnUnread.Size = new System.Drawing.Size(96, 27);
			this.btnUnread.TabIndex = 0;
			this.btnUnread.Text = "Ungelesen";
			this.btnUnread.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnUnread.UseVisualStyleBackColor = true;
			this.btnUnread.Click += new System.EventHandler(this.btnUnread_Click);
			// 
			// btnHistory
			// 
			this.btnHistory.Appearance = System.Windows.Forms.Appearance.Button;
			this.btnHistory.Checked = true;
			this.btnHistory.CheckState = System.Windows.Forms.CheckState.Checked;
			this.btnHistory.Location = new System.Drawing.Point(101, 3);
			this.btnHistory.Name = "btnHistory";
			this.btnHistory.Size = new System.Drawing.Size(96, 27);
			this.btnHistory.TabIndex = 1;
			this.btnHistory.Text = "Verlauf";
			this.btnHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnHistory.UseVisualStyleBackColor = true;
			this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(654, 447);
			this.Controls.Add(this.layout);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.tsOptions);
			this.Name = "MainForm";
			this.Text = "TheLockNLol Checker";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.tsOptions.ResumeLayout(false);
			this.tsOptions.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tsOptions;
		private System.Windows.Forms.ToolStripButton btnOptions;
		private System.Windows.Forms.FlowLayoutPanel layout;
		private System.Windows.Forms.ToolStripButton btnRefresh;
		private System.Windows.Forms.Timer refreshTimer;
		private System.Windows.Forms.ListView lvFilter;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ToolStripButton tsbAbout;
		private System.Windows.Forms.CheckBox btnHistory;
		private System.Windows.Forms.CheckBox btnUnread;
	}
}

