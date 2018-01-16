namespace SA45_TEAM01A_LibrarySystem
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblMembers = new System.Windows.Forms.Label();
            this.lblBooks = new System.Windows.Forms.Label();
            this.lblReports = new System.Windows.Forms.Label();
            this.linkLogout = new System.Windows.Forms.LinkLabel();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnBooks = new System.Windows.Forms.Button();
            this.btnMember = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.labelTeam = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelMem = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.panelBooks = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.panelReports = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelMem.SuspendLayout();
            this.panelBooks.SuspendLayout();
            this.panelReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMembers
            // 
            this.lblMembers.AutoSize = true;
            this.lblMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMembers.Location = new System.Drawing.Point(269, 189);
            this.lblMembers.Name = "lblMembers";
            this.lblMembers.Size = new System.Drawing.Size(90, 24);
            this.lblMembers.TabIndex = 3;
            this.lblMembers.Text = "Members";
            // 
            // lblBooks
            // 
            this.lblBooks.AutoSize = true;
            this.lblBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBooks.Location = new System.Drawing.Point(268, 271);
            this.lblBooks.Name = "lblBooks";
            this.lblBooks.Size = new System.Drawing.Size(62, 24);
            this.lblBooks.TabIndex = 4;
            this.lblBooks.Text = "Books";
            // 
            // lblReports
            // 
            this.lblReports.AutoSize = true;
            this.lblReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReports.Location = new System.Drawing.Point(269, 352);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(75, 24);
            this.lblReports.TabIndex = 5;
            this.lblReports.Text = "Reports";
            // 
            // linkLogout
            // 
            this.linkLogout.AutoSize = true;
            this.linkLogout.Location = new System.Drawing.Point(632, 9);
            this.linkLogout.Name = "linkLogout";
            this.linkLogout.Size = new System.Drawing.Size(40, 13);
            this.linkLogout.TabIndex = 6;
            this.linkLogout.TabStop = true;
            this.linkLogout.Text = "Logout";
            this.linkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLogout_LinkClicked);
            // 
            // btnReports
            // 
            this.btnReports.BackgroundImage = global::SA45_TEAM01A_LibrarySystem.Properties.Resources._25089_200;
            this.btnReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReports.Location = new System.Drawing.Point(365, 320);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(75, 72);
            this.btnReports.TabIndex = 2;
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            this.btnReports.MouseEnter += new System.EventHandler(this.btnReports_MouseEnter);
            // 
            // btnBooks
            // 
            this.btnBooks.BackgroundImage = global::SA45_TEAM01A_LibrarySystem.Properties.Resources.book_icon_78889;
            this.btnBooks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBooks.Location = new System.Drawing.Point(187, 239);
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.Size = new System.Drawing.Size(75, 72);
            this.btnBooks.TabIndex = 1;
            this.btnBooks.UseVisualStyleBackColor = true;
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);
            this.btnBooks.MouseEnter += new System.EventHandler(this.btnBooks_MouseEnter);
            // 
            // btnMember
            // 
            this.btnMember.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnMember.BackgroundImage = global::SA45_TEAM01A_LibrarySystem.Properties.Resources.account_friend_human_man_member_person_profile_user_users_256;
            this.btnMember.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMember.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.btnMember.Location = new System.Drawing.Point(365, 153);
            this.btnMember.Name = "btnMember";
            this.btnMember.Size = new System.Drawing.Size(75, 72);
            this.btnMember.TabIndex = 0;
            this.btnMember.UseVisualStyleBackColor = false;
            this.btnMember.Click += new System.EventHandler(this.btnMember_Click);
            this.btnMember.MouseEnter += new System.EventHandler(this.btnMember_MouseEnter);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnHome);
            this.panel2.Controls.Add(this.labelTeam);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(491, 102);
            this.panel2.TabIndex = 46;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Wheat;
            this.btnHome.BackgroundImage = global::SA45_TEAM01A_LibrarySystem.Properties.Resources.free_vector_diversity_knowledge_book_tree_132983_Diversity_knowledge_book_tree;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHome.Enabled = false;
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(103, 102);
            this.btnHome.TabIndex = 47;
            this.btnHome.UseVisualStyleBackColor = false;
            // 
            // labelTeam
            // 
            this.labelTeam.AutoSize = true;
            this.labelTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 33F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTeam.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelTeam.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelTeam.Location = new System.Drawing.Point(94, 35);
            this.labelTeam.Name = "labelTeam";
            this.labelTeam.Size = new System.Drawing.Size(383, 52);
            this.labelTeam.TabIndex = 2;
            this.labelTeam.Text = "TEAM01A Library";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(684, 22);
            this.statusStrip1.TabIndex = 47;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(384, 17);
            this.toolStripStatusLabel1.Text = "Main menu. Please select an option or click on icon for default window.";
            // 
            // panelMem
            // 
            this.panelMem.Controls.Add(this.btnAdd);
            this.panelMem.Controls.Add(this.btnDel);
            this.panelMem.Controls.Add(this.btnEdit);
            this.panelMem.Controls.Add(this.btnView);
            this.panelMem.Location = new System.Drawing.Point(450, 126);
            this.panelMem.Name = "panelMem";
            this.panelMem.Size = new System.Drawing.Size(163, 118);
            this.panelMem.TabIndex = 49;
            this.panelMem.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(54, 37);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 25);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add Members";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(54, 85);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(92, 25);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Delete Members";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(54, 61);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(92, 25);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit Members";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(19, 12);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(127, 25);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "View Members";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // panelBooks
            // 
            this.panelBooks.Controls.Add(this.button5);
            this.panelBooks.Controls.Add(this.button10);
            this.panelBooks.Controls.Add(this.btnReturn);
            this.panelBooks.Controls.Add(this.btnBorrow);
            this.panelBooks.Controls.Add(this.button13);
            this.panelBooks.Location = new System.Drawing.Point(34, 191);
            this.panelBooks.Name = "panelBooks";
            this.panelBooks.Size = new System.Drawing.Size(147, 164);
            this.panelBooks.TabIndex = 50;
            this.panelBooks.Visible = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(73, 28);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(71, 25);
            this.button5.TabIndex = 4;
            this.button5.Text = "Add Book";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(73, 50);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(71, 25);
            this.button10.TabIndex = 3;
            this.button10.Text = "Edit Book";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(52, 129);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(92, 25);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.Text = "Return Books";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnBorrow
            // 
            this.btnBorrow.Location = new System.Drawing.Point(52, 89);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(92, 25);
            this.btnBorrow.TabIndex = 1;
            this.btnBorrow.Text = "Borrow Books";
            this.btnBorrow.UseVisualStyleBackColor = true;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(19, 4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(125, 25);
            this.button13.TabIndex = 0;
            this.button13.Text = "View Books";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // panelReports
            // 
            this.panelReports.Controls.Add(this.button1);
            this.panelReports.Controls.Add(this.button2);
            this.panelReports.Controls.Add(this.button3);
            this.panelReports.Controls.Add(this.button4);
            this.panelReports.Location = new System.Drawing.Point(450, 294);
            this.panelReports.Name = "panelReports";
            this.panelReports.Size = new System.Drawing.Size(135, 118);
            this.panelReports.TabIndex = 51;
            this.panelReports.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(57, 84);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 25);
            this.button2.TabIndex = 2;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(57, 60);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 25);
            this.button3.TabIndex = 1;
            this.button3.Text = "Edit";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(19, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(92, 25);
            this.button4.TabIndex = 0;
            this.button4.Text = "View";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.panelReports);
            this.Controls.Add(this.panelBooks);
            this.Controls.Add(this.panelMem);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.linkLogout);
            this.Controls.Add(this.lblReports);
            this.Controls.Add(this.lblBooks);
            this.Controls.Add(this.lblMembers);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnBooks);
            this.Controls.Add(this.btnMember);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Team01A Library";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelMem.ResumeLayout(false);
            this.panelBooks.ResumeLayout(false);
            this.panelReports.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMember;
        private System.Windows.Forms.Button btnBooks;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Label lblMembers;
        private System.Windows.Forms.Label lblBooks;
        private System.Windows.Forms.Label lblReports;
        private System.Windows.Forms.LinkLabel linkLogout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelTeam;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panelMem;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Panel panelBooks;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnBorrow;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Panel panelReports;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}