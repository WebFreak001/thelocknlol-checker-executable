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
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.bitImage = new System.Windows.Forms.PictureBox();
			this.rtfText = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.flaVideo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bitImage)).BeginInit();
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
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
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
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.IsSplitterFixed = true;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.bitImage);
			this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.rtfText);
			this.splitContainer2.Size = new System.Drawing.Size(441, 93);
			this.splitContainer2.SplitterDistance = 102;
			this.splitContainer2.TabIndex = 0;
			// 
			// bitImage
			// 
			this.bitImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.bitImage.Location = new System.Drawing.Point(0, 0);
			this.bitImage.Name = "bitImage";
			this.bitImage.Size = new System.Drawing.Size(102, 93);
			this.bitImage.TabIndex = 0;
			this.bitImage.TabStop = false;
			// 
			// rtfText
			// 
			this.rtfText.BackColor = System.Drawing.SystemColors.Control;
			this.rtfText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtfText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtfText.Location = new System.Drawing.Point(0, 0);
			this.rtfText.Name = "rtfText";
			this.rtfText.Size = new System.Drawing.Size(335, 93);
			this.rtfText.TabIndex = 1;
			this.rtfText.Text = "";
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
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bitImage)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private AxShockwaveFlashObjects.AxShockwaveFlash flaVideo;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.PictureBox bitImage;
		private System.Windows.Forms.RichTextBox rtfText;

	}
}
