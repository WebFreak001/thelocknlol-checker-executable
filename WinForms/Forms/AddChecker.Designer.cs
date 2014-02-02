namespace WinForms.Forms
{
	partial class AddChecker
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnRem = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.cbYouTube = new System.Windows.Forms.CheckBox();
			this.cbTwitch = new System.Windows.Forms.CheckBox();
			this.cbFacebook = new System.Windows.Forms.CheckBox();
			this.cbTwitter = new System.Windows.Forms.CheckBox();
			this.tbYouTube = new System.Windows.Forms.TextBox();
			this.tbTwitch = new System.Windows.Forms.TextBox();
			this.tbFacebook = new System.Windows.Forms.TextBox();
			this.tbTwitter = new System.Windows.Forms.TextBox();
			this.tbTagName = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.btnRem);
			this.panel1.Controls.Add(this.btnAdd);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 137);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(287, 35);
			this.panel1.TabIndex = 2;
			// 
			// btnRem
			// 
			this.btnRem.Location = new System.Drawing.Point(86, 6);
			this.btnRem.Name = "btnRem";
			this.btnRem.Size = new System.Drawing.Size(75, 24);
			this.btnRem.TabIndex = 1;
			this.btnRem.Text = "Abbrechen";
			this.btnRem.UseVisualStyleBackColor = true;
			this.btnRem.Click += new System.EventHandler(this.btnRem_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(5, 6);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 24);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "OK";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// cbYouTube
			// 
			this.cbYouTube.AutoSize = true;
			this.cbYouTube.Checked = true;
			this.cbYouTube.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbYouTube.Location = new System.Drawing.Point(5, 45);
			this.cbYouTube.Name = "cbYouTube";
			this.cbYouTube.Size = new System.Drawing.Size(70, 17);
			this.cbYouTube.TabIndex = 3;
			this.cbYouTube.Text = "YouTube";
			this.cbYouTube.UseVisualStyleBackColor = true;
			this.cbYouTube.CheckedChanged += new System.EventHandler(this.cbYouTube_CheckedChanged);
			// 
			// cbTwitch
			// 
			this.cbTwitch.AutoSize = true;
			this.cbTwitch.Checked = true;
			this.cbTwitch.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbTwitch.Location = new System.Drawing.Point(5, 68);
			this.cbTwitch.Name = "cbTwitch";
			this.cbTwitch.Size = new System.Drawing.Size(58, 17);
			this.cbTwitch.TabIndex = 4;
			this.cbTwitch.Text = "Twitch";
			this.cbTwitch.UseVisualStyleBackColor = true;
			this.cbTwitch.CheckedChanged += new System.EventHandler(this.cbTwitch_CheckedChanged);
			// 
			// cbFacebook
			// 
			this.cbFacebook.AutoSize = true;
			this.cbFacebook.Checked = true;
			this.cbFacebook.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbFacebook.Location = new System.Drawing.Point(5, 91);
			this.cbFacebook.Name = "cbFacebook";
			this.cbFacebook.Size = new System.Drawing.Size(74, 17);
			this.cbFacebook.TabIndex = 5;
			this.cbFacebook.Text = "Facebook";
			this.cbFacebook.UseVisualStyleBackColor = true;
			this.cbFacebook.CheckedChanged += new System.EventHandler(this.cbFacebook_CheckedChanged);
			// 
			// cbTwitter
			// 
			this.cbTwitter.AutoSize = true;
			this.cbTwitter.Checked = true;
			this.cbTwitter.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbTwitter.Location = new System.Drawing.Point(5, 114);
			this.cbTwitter.Name = "cbTwitter";
			this.cbTwitter.Size = new System.Drawing.Size(58, 17);
			this.cbTwitter.TabIndex = 6;
			this.cbTwitter.Text = "Twitter";
			this.cbTwitter.UseVisualStyleBackColor = true;
			this.cbTwitter.CheckedChanged += new System.EventHandler(this.cbTwitter_CheckedChanged);
			// 
			// tbYouTube
			// 
			this.tbYouTube.Location = new System.Drawing.Point(86, 43);
			this.tbYouTube.Name = "tbYouTube";
			this.tbYouTube.Size = new System.Drawing.Size(196, 20);
			this.tbYouTube.TabIndex = 7;
			// 
			// tbTwitch
			// 
			this.tbTwitch.Location = new System.Drawing.Point(86, 66);
			this.tbTwitch.Name = "tbTwitch";
			this.tbTwitch.Size = new System.Drawing.Size(196, 20);
			this.tbTwitch.TabIndex = 8;
			// 
			// tbFacebook
			// 
			this.tbFacebook.Location = new System.Drawing.Point(86, 89);
			this.tbFacebook.Name = "tbFacebook";
			this.tbFacebook.Size = new System.Drawing.Size(196, 20);
			this.tbFacebook.TabIndex = 9;
			// 
			// tbTwitter
			// 
			this.tbTwitter.Location = new System.Drawing.Point(86, 112);
			this.tbTwitter.Name = "tbTwitter";
			this.tbTwitter.Size = new System.Drawing.Size(196, 20);
			this.tbTwitter.TabIndex = 10;
			// 
			// tbTagName
			// 
			this.tbTagName.Location = new System.Drawing.Point(12, 12);
			this.tbTagName.Name = "tbTagName";
			this.tbTagName.Size = new System.Drawing.Size(263, 20);
			this.tbTagName.TabIndex = 11;
			// 
			// AddChecker
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(287, 172);
			this.Controls.Add(this.tbTagName);
			this.Controls.Add(this.tbTwitter);
			this.Controls.Add(this.tbFacebook);
			this.Controls.Add(this.tbTwitch);
			this.Controls.Add(this.tbYouTube);
			this.Controls.Add(this.cbTwitter);
			this.Controls.Add(this.cbFacebook);
			this.Controls.Add(this.cbTwitch);
			this.Controls.Add(this.cbYouTube);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AddChecker";
			this.Text = "AddChecker";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnRem;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.CheckBox cbYouTube;
		private System.Windows.Forms.CheckBox cbTwitch;
		private System.Windows.Forms.CheckBox cbFacebook;
		private System.Windows.Forms.CheckBox cbTwitter;
		private System.Windows.Forms.TextBox tbYouTube;
		private System.Windows.Forms.TextBox tbTwitch;
		private System.Windows.Forms.TextBox tbFacebook;
		private System.Windows.Forms.TextBox tbTwitter;
		private System.Windows.Forms.TextBox tbTagName;
	}
}