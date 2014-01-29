namespace WinForms.Forms
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
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "TheLockNLol",
            "TheLockNLol",
            "TheLockNLol",
            "TheLockNLol"}, -1);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tpGeneral = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.lvCheckers = new System.Windows.Forms.ListView();
			this.dname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ytName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.twitchName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.fbName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnRem = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tpGeneral.SuspendLayout();
			this.panel1.SuspendLayout();
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
			this.tabControl1.Size = new System.Drawing.Size(386, 274);
			this.tabControl1.TabIndex = 0;
			// 
			// tpGeneral
			// 
			this.tpGeneral.Controls.Add(this.lvCheckers);
			this.tpGeneral.Controls.Add(this.panel1);
			this.tpGeneral.Location = new System.Drawing.Point(4, 22);
			this.tpGeneral.Name = "tpGeneral";
			this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tpGeneral.Size = new System.Drawing.Size(378, 248);
			this.tpGeneral.TabIndex = 0;
			this.tpGeneral.Text = "Generell";
			this.tpGeneral.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(378, 248);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Benachrichtigungen";
			this.tabPage2.UseVisualStyleBackColor = true;
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
			listViewItem2.Checked = true;
			listViewItem2.StateImageIndex = 1;
			this.lvCheckers.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
			this.lvCheckers.Location = new System.Drawing.Point(3, 3);
			this.lvCheckers.Name = "lvCheckers";
			this.lvCheckers.Size = new System.Drawing.Size(372, 207);
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
			this.panel1.BackColor = System.Drawing.Color.Gainsboro;
			this.panel1.Controls.Add(this.btnRem);
			this.panel1.Controls.Add(this.btnAdd);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(3, 210);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(372, 35);
			this.panel1.TabIndex = 1;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(5, 6);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 24);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "Hinzufügen";
			this.btnAdd.UseVisualStyleBackColor = true;
			// 
			// btnRem
			// 
			this.btnRem.Location = new System.Drawing.Point(86, 6);
			this.btnRem.Name = "btnRem";
			this.btnRem.Size = new System.Drawing.Size(75, 24);
			this.btnRem.TabIndex = 1;
			this.btnRem.Text = "Entfernen";
			this.btnRem.UseVisualStyleBackColor = true;
			// 
			// OptionsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(386, 274);
			this.Controls.Add(this.tabControl1);
			this.Name = "OptionsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Optionen";
			this.tabControl1.ResumeLayout(false);
			this.tpGeneral.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
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
	}
}