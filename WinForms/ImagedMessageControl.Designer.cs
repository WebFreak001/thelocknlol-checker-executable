namespace WinForms
{
	partial class ImagedMessageControl
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
			this.splitter = new System.Windows.Forms.SplitContainer();
			this.bitImage = new System.Windows.Forms.PictureBox();
			this.rtfText = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
			this.splitter.Panel1.SuspendLayout();
			this.splitter.Panel2.SuspendLayout();
			this.splitter.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bitImage)).BeginInit();
			this.SuspendLayout();
			// 
			// splitter
			// 
			this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitter.Location = new System.Drawing.Point(0, 0);
			this.splitter.Name = "splitter";
			// 
			// splitter.Panel1
			// 
			this.splitter.Panel1.Controls.Add(this.bitImage);
			// 
			// splitter.Panel2
			// 
			this.splitter.Panel2.Controls.Add(this.rtfText);
			this.splitter.Size = new System.Drawing.Size(223, 147);
			this.splitter.SplitterDistance = 60;
			this.splitter.TabIndex = 0;
			// 
			// bitImage
			// 
			this.bitImage.Dock = System.Windows.Forms.DockStyle.Top;
			this.bitImage.Location = new System.Drawing.Point(0, 0);
			this.bitImage.Name = "bitImage";
			this.bitImage.Size = new System.Drawing.Size(60, 50);
			this.bitImage.TabIndex = 0;
			this.bitImage.TabStop = false;
			this.bitImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
			// 
			// rtfText
			// 
			this.rtfText.BackColor = System.Drawing.SystemColors.Control;
			this.rtfText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtfText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtfText.Location = new System.Drawing.Point(0, 0);
			this.rtfText.Name = "rtfText";
			this.rtfText.Size = new System.Drawing.Size(159, 147);
			this.rtfText.TabIndex = 0;
			this.rtfText.Text = "";
			// 
			// ImagedMessageControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitter);
			this.Name = "ImagedMessageControl";
			this.Size = new System.Drawing.Size(223, 147);
			this.splitter.Panel1.ResumeLayout(false);
			this.splitter.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
			this.splitter.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.bitImage)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitter;
		private System.Windows.Forms.PictureBox bitImage;
		private System.Windows.Forms.RichTextBox rtfText;
	}
}
