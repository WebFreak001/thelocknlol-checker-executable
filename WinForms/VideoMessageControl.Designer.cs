namespace WinForms
{
	partial class VideoMessageControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoMessageControl));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.flaVideo = new AxShockwaveFlashObjects.AxShockwaveFlash();
			this.descControl = new WinForms.ImagedMessageControl();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.flaVideo)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.flaVideo);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.descControl);
			this.splitContainer1.Size = new System.Drawing.Size(441, 399);
			this.splitContainer1.SplitterDistance = 302;
			this.splitContainer1.TabIndex = 0;
			// 
			// flaVideo
			// 
			this.flaVideo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flaVideo.Enabled = true;
			this.flaVideo.Location = new System.Drawing.Point(0, 0);
			this.flaVideo.Name = "flaVideo";
			this.flaVideo.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("flaVideo.OcxState")));
			this.flaVideo.Size = new System.Drawing.Size(441, 302);
			this.flaVideo.TabIndex = 0;
			// 
			// descControl
			// 
			this.descControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.descControl.Location = new System.Drawing.Point(0, 0);
			this.descControl.Name = "descControl";
			this.descControl.Size = new System.Drawing.Size(441, 93);
			this.descControl.TabIndex = 0;
			// 
			// VideoMessageControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Name = "VideoMessageControl";
			this.Size = new System.Drawing.Size(441, 399);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.flaVideo)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private AxShockwaveFlashObjects.AxShockwaveFlash flaVideo;
		private ImagedMessageControl descControl;

	}
}
