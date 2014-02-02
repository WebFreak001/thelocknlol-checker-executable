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
			this.tsbAbout = new System.Windows.Forms.ToolStripButton();
			this.refreshTimer = new System.Windows.Forms.Timer(this.components);
			this.notifications = new System.Windows.Forms.FlowLayoutPanel();
			this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.trayClose = new System.Windows.Forms.ToolStripMenuItem();
			this.trayOptions = new System.Windows.Forms.ToolStripMenuItem();
			this.trayAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.tsOptions.SuspendLayout();
			this.trayMenu.SuspendLayout();
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
			// refreshTimer
			// 
			this.refreshTimer.Interval = 10000;
			this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
			// 
			// notifications
			// 
			this.notifications.AutoScroll = true;
			this.notifications.Dock = System.Windows.Forms.DockStyle.Fill;
			this.notifications.Location = new System.Drawing.Point(0, 25);
			this.notifications.Name = "notifications";
			this.notifications.Size = new System.Drawing.Size(654, 422);
			this.notifications.TabIndex = 1;
			// 
			// trayIcon
			// 
			this.trayIcon.ContextMenuStrip = this.trayMenu;
			this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
			this.trayIcon.Text = "notifyIcon1";
			this.trayIcon.Visible = true;
			// 
			// trayMenu
			// 
			this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayClose,
            this.trayOptions,
            this.trayAbout});
			this.trayMenu.Name = "trayMenu";
			this.trayMenu.ShowItemToolTips = false;
			this.trayMenu.Size = new System.Drawing.Size(125, 70);
			// 
			// trayClose
			// 
			this.trayClose.Name = "trayClose";
			this.trayClose.Size = new System.Drawing.Size(152, 22);
			this.trayClose.Text = "Beenden";
			this.trayClose.Click += new System.EventHandler(this.trayClose_Click);
			// 
			// trayOptions
			// 
			this.trayOptions.Name = "trayOptions";
			this.trayOptions.Size = new System.Drawing.Size(152, 22);
			this.trayOptions.Text = "Optionen";
			this.trayOptions.Click += new System.EventHandler(this.trayOptions_Click);
			// 
			// trayAbout
			// 
			this.trayAbout.Name = "trayAbout";
			this.trayAbout.Size = new System.Drawing.Size(152, 22);
			this.trayAbout.Text = "Über";
			this.trayAbout.Click += new System.EventHandler(this.trayAbout_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(654, 447);
			this.Controls.Add(this.notifications);
			this.Controls.Add(this.tsOptions);
			this.Name = "MainForm";
			this.Text = "TheLockNLol Checker";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.tsOptions.ResumeLayout(false);
			this.tsOptions.PerformLayout();
			this.trayMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tsOptions;
		private System.Windows.Forms.ToolStripButton btnOptions;
		private System.Windows.Forms.ToolStripButton btnRefresh;
		private System.Windows.Forms.Timer refreshTimer;
		private System.Windows.Forms.ToolStripButton tsbAbout;
		private System.Windows.Forms.FlowLayoutPanel notifications;
		private System.Windows.Forms.NotifyIcon trayIcon;
		private System.Windows.Forms.ContextMenuStrip trayMenu;
		private System.Windows.Forms.ToolStripMenuItem trayClose;
		private System.Windows.Forms.ToolStripMenuItem trayOptions;
		private System.Windows.Forms.ToolStripMenuItem trayAbout;
	}
}

