﻿namespace WinForms.Forms
{
	partial class OptionsForm
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
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "TheLockNLol",
            "TheLockNLol",
            "TheLockNLol",
            "TheLockNLol"}, -1);
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Sounds/pew.wav");
			System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("System:Asterisk");
			System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("System:Beep");
			System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("System:Exclamation");
			System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("System:Hand");
			System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("System:Question");
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpGeneral = new System.Windows.Forms.TabPage();
			this.lvCheckers = new System.Windows.Forms.ListView();
			this.dname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ytName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.twitchName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.fbName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnRem = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnPreviewSound = new System.Windows.Forms.Button();
			this.cbSound = new System.Windows.Forms.ComboBox();
			this.tbSoundFile = new System.Windows.Forms.TextBox();
			this.btnAddSound = new System.Windows.Forms.Button();
			this.lvSounds = new System.Windows.Forms.ListView();
			this.cbSoundFBook = new System.Windows.Forms.CheckBox();
			this.cbSoundLivestream = new System.Windows.Forms.CheckBox();
			this.cbSoundVidup = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.cbCombineVidFacebook = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbNotifyFb = new System.Windows.Forms.CheckBox();
			this.cbNotifyLivestream = new System.Windows.Forms.CheckBox();
			this.cbNotifyVideo = new System.Windows.Forms.CheckBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnResetChanges = new System.Windows.Forms.Button();
			this.btnSaveAndClose = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tpGeneral.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tpGeneral);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(450, 289);
			this.tabControl1.TabIndex = 0;
			// 
			// tpGeneral
			// 
			this.tpGeneral.Controls.Add(this.lvCheckers);
			this.tpGeneral.Controls.Add(this.panel1);
			this.tpGeneral.Location = new System.Drawing.Point(4, 22);
			this.tpGeneral.Name = "tpGeneral";
			this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tpGeneral.Size = new System.Drawing.Size(442, 263);
			this.tpGeneral.TabIndex = 0;
			this.tpGeneral.Text = "Generell";
			this.tpGeneral.UseVisualStyleBackColor = true;
			// 
			// lvCheckers
			// 
			this.lvCheckers.CheckBoxes = true;
			this.lvCheckers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.dname,
            this.ytName,
            this.twitchName,
            this.fbName});
			this.lvCheckers.Dock = System.Windows.Forms.DockStyle.Fill;
			listViewItem1.Checked = true;
			listViewItem1.StateImageIndex = 1;
			this.lvCheckers.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
			this.lvCheckers.Location = new System.Drawing.Point(3, 3);
			this.lvCheckers.Name = "lvCheckers";
			this.lvCheckers.Size = new System.Drawing.Size(436, 222);
			this.lvCheckers.TabIndex = 0;
			this.lvCheckers.UseCompatibleStateImageBehavior = false;
			this.lvCheckers.View = System.Windows.Forms.View.Details;
			// 
			// dname
			// 
			this.dname.Text = "Name";
			this.dname.Width = 100;
			// 
			// ytName
			// 
			this.ytName.Text = "Youtube Name";
			this.ytName.Width = 85;
			// 
			// twitchName
			// 
			this.twitchName.Text = "Twitch Name";
			this.twitchName.Width = 85;
			// 
			// fbName
			// 
			this.fbName.Text = "Facebook Name";
			this.fbName.Width = 95;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.btnRem);
			this.panel1.Controls.Add(this.btnAdd);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(3, 225);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(436, 35);
			this.panel1.TabIndex = 1;
			// 
			// btnRem
			// 
			this.btnRem.Location = new System.Drawing.Point(86, 6);
			this.btnRem.Name = "btnRem";
			this.btnRem.Size = new System.Drawing.Size(75, 24);
			this.btnRem.TabIndex = 1;
			this.btnRem.Text = "Entfernen";
			this.btnRem.UseVisualStyleBackColor = true;
			this.btnRem.Click += new System.EventHandler(this.btnRem_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(5, 6);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 24);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "Hinzufügen";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.splitContainer1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(442, 263);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Benachrichtigungen";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
			this.splitContainer1.Size = new System.Drawing.Size(436, 257);
			this.splitContainer1.SplitterDistance = 218;
			this.splitContainer1.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnPreviewSound);
			this.groupBox1.Controls.Add(this.cbSound);
			this.groupBox1.Controls.Add(this.tbSoundFile);
			this.groupBox1.Controls.Add(this.btnAddSound);
			this.groupBox1.Controls.Add(this.lvSounds);
			this.groupBox1.Controls.Add(this.cbSoundFBook);
			this.groupBox1.Controls.Add(this.cbSoundLivestream);
			this.groupBox1.Controls.Add(this.cbSoundVidup);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(218, 257);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Sounds";
			// 
			// btnPreviewSound
			// 
			this.btnPreviewSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPreviewSound.Font = new System.Drawing.Font("Arial", 8.25F);
			this.btnPreviewSound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.btnPreviewSound.Location = new System.Drawing.Point(189, 87);
			this.btnPreviewSound.Name = "btnPreviewSound";
			this.btnPreviewSound.Size = new System.Drawing.Size(23, 23);
			this.btnPreviewSound.TabIndex = 8;
			this.btnPreviewSound.Text = "►";
			this.btnPreviewSound.UseVisualStyleBackColor = true;
			this.btnPreviewSound.Click += new System.EventHandler(this.btnPreviewSound_Click);
			// 
			// cbSound
			// 
			this.cbSound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSound.FormattingEnabled = true;
			this.cbSound.Location = new System.Drawing.Point(6, 88);
			this.cbSound.Name = "cbSound";
			this.cbSound.Size = new System.Drawing.Size(181, 21);
			this.cbSound.TabIndex = 7;
			// 
			// tbSoundFile
			// 
			this.tbSoundFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSoundFile.Location = new System.Drawing.Point(5, 230);
			this.tbSoundFile.Name = "tbSoundFile";
			this.tbSoundFile.Size = new System.Drawing.Size(130, 20);
			this.tbSoundFile.TabIndex = 6;
			this.tbSoundFile.TextChanged += new System.EventHandler(this.tbSoundFile_TextChanged);
			// 
			// btnAddSound
			// 
			this.btnAddSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddSound.Location = new System.Drawing.Point(137, 228);
			this.btnAddSound.Name = "btnAddSound";
			this.btnAddSound.Size = new System.Drawing.Size(75, 23);
			this.btnAddSound.TabIndex = 5;
			this.btnAddSound.Text = "Durchsuchen";
			this.btnAddSound.UseVisualStyleBackColor = true;
			this.btnAddSound.Click += new System.EventHandler(this.btnAddSound_Click);
			// 
			// lvSounds
			// 
			this.lvSounds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvSounds.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			listViewItem2.Checked = true;
			listViewItem2.StateImageIndex = 1;
			this.lvSounds.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7});
			this.lvSounds.Location = new System.Drawing.Point(6, 115);
			this.lvSounds.Name = "lvSounds";
			this.lvSounds.Size = new System.Drawing.Size(206, 107);
			this.lvSounds.TabIndex = 4;
			this.lvSounds.UseCompatibleStateImageBehavior = false;
			this.lvSounds.View = System.Windows.Forms.View.List;
			// 
			// cbSoundFBook
			// 
			this.cbSoundFBook.AutoSize = true;
			this.cbSoundFBook.Location = new System.Drawing.Point(6, 65);
			this.cbSoundFBook.Name = "cbSoundFBook";
			this.cbSoundFBook.Size = new System.Drawing.Size(125, 17);
			this.cbSoundFBook.TabIndex = 2;
			this.cbSoundFBook.Text = "Sound bei Facebook";
			this.cbSoundFBook.UseVisualStyleBackColor = true;
			// 
			// cbSoundLivestream
			// 
			this.cbSoundLivestream.AutoSize = true;
			this.cbSoundLivestream.Checked = true;
			this.cbSoundLivestream.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSoundLivestream.Location = new System.Drawing.Point(6, 42);
			this.cbSoundLivestream.Name = "cbSoundLivestream";
			this.cbSoundLivestream.Size = new System.Drawing.Size(128, 17);
			this.cbSoundLivestream.TabIndex = 1;
			this.cbSoundLivestream.Text = "Sound bei Livestream";
			this.cbSoundLivestream.UseVisualStyleBackColor = true;
			// 
			// cbSoundVidup
			// 
			this.cbSoundVidup.AutoSize = true;
			this.cbSoundVidup.Location = new System.Drawing.Point(6, 19);
			this.cbSoundVidup.Name = "cbSoundVidup";
			this.cbSoundVidup.Size = new System.Drawing.Size(149, 17);
			this.cbSoundVidup.TabIndex = 0;
			this.cbSoundVidup.Text = "Sound beim Video-Upload";
			this.cbSoundVidup.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.cbCombineVidFacebook);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.cbNotifyFb);
			this.groupBox2.Controls.Add(this.cbNotifyLivestream);
			this.groupBox2.Controls.Add(this.cbNotifyVideo);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(214, 257);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Benachrichtigungen";
			// 
			// cbCombineVidFacebook
			// 
			this.cbCombineVidFacebook.AutoSize = true;
			this.cbCombineVidFacebook.Checked = true;
			this.cbCombineVidFacebook.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbCombineVidFacebook.Location = new System.Drawing.Point(26, 42);
			this.cbCombineVidFacebook.Name = "cbCombineVidFacebook";
			this.cbCombineVidFacebook.Size = new System.Drawing.Size(105, 17);
			this.cbCombineVidFacebook.TabIndex = 6;
			this.cbCombineVidFacebook.Text = "Zusammenfügen";
			this.cbCombineVidFacebook.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.label1.Location = new System.Drawing.Point(6, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(23, 15);
			this.label1.TabIndex = 7;
			this.label1.Text = "├─";
			// 
			// cbNotifyFb
			// 
			this.cbNotifyFb.AutoSize = true;
			this.cbNotifyFb.Checked = true;
			this.cbNotifyFb.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbNotifyFb.Location = new System.Drawing.Point(6, 65);
			this.cbNotifyFb.Name = "cbNotifyFb";
			this.cbNotifyFb.Size = new System.Drawing.Size(74, 17);
			this.cbNotifyFb.TabIndex = 5;
			this.cbNotifyFb.Text = "Facebook";
			this.cbNotifyFb.UseVisualStyleBackColor = true;
			// 
			// cbNotifyLivestream
			// 
			this.cbNotifyLivestream.AutoSize = true;
			this.cbNotifyLivestream.Checked = true;
			this.cbNotifyLivestream.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbNotifyLivestream.Location = new System.Drawing.Point(6, 88);
			this.cbNotifyLivestream.Name = "cbNotifyLivestream";
			this.cbNotifyLivestream.Size = new System.Drawing.Size(77, 17);
			this.cbNotifyLivestream.TabIndex = 4;
			this.cbNotifyLivestream.Text = "Livestream";
			this.cbNotifyLivestream.UseVisualStyleBackColor = true;
			// 
			// cbNotifyVideo
			// 
			this.cbNotifyVideo.AutoSize = true;
			this.cbNotifyVideo.Checked = true;
			this.cbNotifyVideo.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbNotifyVideo.Location = new System.Drawing.Point(6, 19);
			this.cbNotifyVideo.Name = "cbNotifyVideo";
			this.cbNotifyVideo.Size = new System.Drawing.Size(90, 17);
			this.cbNotifyVideo.TabIndex = 3;
			this.cbNotifyVideo.Text = "Video-Upload";
			this.cbNotifyVideo.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel2.Controls.Add(this.btnResetChanges);
			this.panel2.Controls.Add(this.btnSaveAndClose);
			this.panel2.Controls.Add(this.btnSave);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 289);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(450, 39);
			this.panel2.TabIndex = 1;
			// 
			// btnResetChanges
			// 
			this.btnResetChanges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.btnResetChanges.Location = new System.Drawing.Point(4, 3);
			this.btnResetChanges.Name = "btnResetChanges";
			this.btnResetChanges.Size = new System.Drawing.Size(97, 33);
			this.btnResetChanges.TabIndex = 2;
			this.btnResetChanges.Text = "Wiederherstellen";
			this.btnResetChanges.UseVisualStyleBackColor = true;
			this.btnResetChanges.Click += new System.EventHandler(this.btnResetChanges_Click);
			// 
			// btnSaveAndClose
			// 
			this.btnSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveAndClose.Location = new System.Drawing.Point(107, 3);
			this.btnSaveAndClose.Name = "btnSaveAndClose";
			this.btnSaveAndClose.Size = new System.Drawing.Size(256, 33);
			this.btnSaveAndClose.TabIndex = 1;
			this.btnSaveAndClose.Text = "OK";
			this.btnSaveAndClose.UseVisualStyleBackColor = true;
			this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(369, 3);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(77, 33);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Übernehmen";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// OptionsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(450, 328);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.panel2);
			this.MinimumSize = new System.Drawing.Size(402, 240);
			this.Name = "OptionsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Optionen";
			this.Load += new System.EventHandler(this.OptionsForm_Load);
			this.tabControl1.ResumeLayout(false);
			this.tpGeneral.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tpGeneral;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ListView lvCheckers;
		private System.Windows.Forms.ColumnHeader dname;
		private System.Windows.Forms.ColumnHeader ytName;
		private System.Windows.Forms.ColumnHeader twitchName;
		private System.Windows.Forms.ColumnHeader fbName;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnRem;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox cbSoundFBook;
		private System.Windows.Forms.CheckBox cbSoundLivestream;
		private System.Windows.Forms.CheckBox cbSoundVidup;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox cbNotifyFb;
		private System.Windows.Forms.CheckBox cbNotifyLivestream;
		private System.Windows.Forms.CheckBox cbNotifyVideo;
		private System.Windows.Forms.ListView lvSounds;
		private System.Windows.Forms.TextBox tbSoundFile;
		private System.Windows.Forms.Button btnAddSound;
		private System.Windows.Forms.ComboBox cbSound;
		private System.Windows.Forms.CheckBox cbCombineVidFacebook;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnPreviewSound;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnSaveAndClose;
		private System.Windows.Forms.Button btnResetChanges;
	}
}