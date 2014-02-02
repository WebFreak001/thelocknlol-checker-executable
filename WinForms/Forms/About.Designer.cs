namespace WinForms.Forms
{
	partial class About
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.text = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.pictureBox1.ImageLocation = "Image/koala100.png";
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 100);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// text
			// 
			this.text.BackColor = System.Drawing.SystemColors.Control;
			this.text.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.text.Dock = System.Windows.Forms.DockStyle.Fill;
			this.text.Location = new System.Drawing.Point(100, 0);
			this.text.Name = "text";
			this.text.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.text.Size = new System.Drawing.Size(364, 100);
			this.text.TabIndex = 2;
			this.text.Text = "";
			this.text.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.text_LinkClicked);
			this.text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_KeyDown);
			this.text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_KeyPress);
			// 
			// About
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(464, 100);
			this.Controls.Add(this.text);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "About";
			this.Text = "About";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.RichTextBox text;
	}
}