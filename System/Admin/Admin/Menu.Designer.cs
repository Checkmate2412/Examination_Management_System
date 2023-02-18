namespace Lan_Based_Examination
{
    partial class Menu
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Greeting = new System.Windows.Forms.Label();
            this.LogOut = new DevExpress.XtraEditors.PictureEdit();
            this.Xbtn = new DevExpress.XtraEditors.PictureEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.Clocktxt = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.LogIn = new DevExpress.XtraEditors.SimpleButton();
            this.Codetxt = new DevExpress.XtraEditors.LabelControl();
            this.AdminPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.AdminAccount = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.Student = new DevExpress.XtraEditors.SimpleButton();
            this.Semester = new DevExpress.XtraEditors.SimpleButton();
            this.TeacherPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ViewScore = new DevExpress.XtraEditors.SimpleButton();
            this.Check = new DevExpress.XtraEditors.SimpleButton();
            this.StudentInfoTeacher = new DevExpress.XtraEditors.SimpleButton();
            this.AddQuestionTeacher = new DevExpress.XtraEditors.SimpleButton();
            this.ProctorPanel = new System.Windows.Forms.Panel();
            this.ProctorStudent = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xbtn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.AdminPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.TeacherPanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.ProctorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.42232F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.5641F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.935145F));
            this.tableLayoutPanel2.Controls.Add(this.Greeting, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.LogOut, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.Xbtn, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1326, 41);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // Greeting
            // 
            this.Greeting.BackColor = System.Drawing.Color.Transparent;
            this.Greeting.Dock = System.Windows.Forms.DockStyle.Left;
            this.Greeting.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Greeting.ForeColor = System.Drawing.Color.White;
            this.Greeting.Location = new System.Drawing.Point(3, 0);
            this.Greeting.Name = "Greeting";
            this.Greeting.Size = new System.Drawing.Size(530, 41);
            this.Greeting.TabIndex = 20;
            this.Greeting.Text = "Hi!";
            this.Greeting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LogOut
            // 
            this.LogOut.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LogOut.EditValue = global::Lan_Based_Examination.Properties.Resources.log_out;
            this.LogOut.Location = new System.Drawing.Point(1205, 8);
            this.LogOut.Name = "LogOut";
            this.LogOut.Properties.AllowFocused = false;
            this.LogOut.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.LogOut.Properties.Appearance.Options.UseBackColor = true;
            this.LogOut.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LogOut.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.LogOut.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.False;
            this.LogOut.Properties.ShowMenu = false;
            this.LogOut.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.False;
            this.LogOut.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.LogOut.ShowToolTips = false;
            this.LogOut.Size = new System.Drawing.Size(25, 25);
            this.LogOut.TabIndex = 19;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // Xbtn
            // 
            this.Xbtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Xbtn.EditValue = global::Lan_Based_Examination.Properties.Resources.CancelRed;
            this.Xbtn.Location = new System.Drawing.Point(1298, 8);
            this.Xbtn.Name = "Xbtn";
            this.Xbtn.Properties.AllowFocused = false;
            this.Xbtn.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Xbtn.Properties.Appearance.Options.UseBackColor = true;
            this.Xbtn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Xbtn.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.Xbtn.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.False;
            this.Xbtn.Properties.ShowMenu = false;
            this.Xbtn.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.False;
            this.Xbtn.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.Xbtn.ShowToolTips = false;
            this.Xbtn.Size = new System.Drawing.Size(25, 25);
            this.Xbtn.TabIndex = 0;
            this.Xbtn.Click += new System.EventHandler(this.Xbtn_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.Clocktxt);
            this.panelControl2.Location = new System.Drawing.Point(1177, 677);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(154, 42);
            this.panelControl2.TabIndex = 17;
            // 
            // Clocktxt
            // 
            this.Clocktxt.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.Clocktxt.Appearance.Options.UseFont = true;
            this.Clocktxt.Location = new System.Drawing.Point(5, 5);
            this.Clocktxt.Name = "Clocktxt";
            this.Clocktxt.Size = new System.Drawing.Size(105, 29);
            this.Clocktxt.TabIndex = 0;
            this.Clocktxt.Text = "               ";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.LogIn);
            this.panelControl1.Controls.Add(this.Codetxt);
            this.panelControl1.Location = new System.Drawing.Point(12, 670);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(430, 50);
            this.panelControl1.TabIndex = 19;
            // 
            // LogIn
            // 
            this.LogIn.Appearance.BackColor = System.Drawing.Color.White;
            this.LogIn.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogIn.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.LogIn.Appearance.Options.UseBackColor = true;
            this.LogIn.Appearance.Options.UseFont = true;
            this.LogIn.Appearance.Options.UseForeColor = true;
            this.LogIn.Location = new System.Drawing.Point(321, 2);
            this.LogIn.Name = "LogIn";
            this.LogIn.Size = new System.Drawing.Size(104, 45);
            this.LogIn.TabIndex = 21;
            this.LogIn.Text = "&Generate\r\n&Code";
            this.LogIn.Click += new System.EventHandler(this.LogIn_Click);
            // 
            // Codetxt
            // 
            this.Codetxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Codetxt.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.Codetxt.Appearance.Options.UseFont = true;
            this.Codetxt.Appearance.Options.UseTextOptions = true;
            this.Codetxt.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Codetxt.Location = new System.Drawing.Point(8, 9);
            this.Codetxt.Name = "Codetxt";
            this.Codetxt.Size = new System.Drawing.Size(77, 29);
            this.Codetxt.TabIndex = 20;
            this.Codetxt.Text = "Code: ";
            // 
            // AdminPanel
            // 
            this.AdminPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AdminPanel.BackColor = System.Drawing.Color.Transparent;
            this.AdminPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AdminPanel.Controls.Add(this.panel4);
            this.AdminPanel.Controls.Add(this.tableLayoutPanel5);
            this.AdminPanel.Location = new System.Drawing.Point(131, 105);
            this.AdminPanel.Name = "AdminPanel";
            this.AdminPanel.Size = new System.Drawing.Size(1089, 518);
            this.AdminPanel.TabIndex = 23;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.AdminAccount);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, -1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1087, 267);
            this.panel4.TabIndex = 13;
            // 
            // AdminAccount
            // 
            this.AdminAccount.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.AdminAccount.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.AdminAccount.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.AdminAccount.Appearance.ForeColor = System.Drawing.Color.White;
            this.AdminAccount.Appearance.Options.UseBackColor = true;
            this.AdminAccount.Appearance.Options.UseFont = true;
            this.AdminAccount.Appearance.Options.UseForeColor = true;
            this.AdminAccount.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.AdminAccount.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.AdminAccount.AppearanceHovered.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.AdminAccount.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.AdminAccount.AppearanceHovered.Options.UseBackColor = true;
            this.AdminAccount.AppearanceHovered.Options.UseFont = true;
            this.AdminAccount.AppearanceHovered.Options.UseForeColor = true;
            this.AdminAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdminAccount.Location = new System.Drawing.Point(0, 0);
            this.AdminAccount.Name = "AdminAccount";
            this.AdminAccount.Size = new System.Drawing.Size(1087, 267);
            this.AdminAccount.TabIndex = 67;
            this.AdminAccount.Text = "Add/Edit &Admin Account";
            this.AdminAccount.Click += new System.EventHandler(this.AdminAccount_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.Student, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.Semester, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 266);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1087, 250);
            this.tableLayoutPanel5.TabIndex = 12;
            // 
            // Student
            // 
            this.Student.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Student.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Student.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.Student.Appearance.ForeColor = System.Drawing.Color.White;
            this.Student.Appearance.Options.UseBackColor = true;
            this.Student.Appearance.Options.UseFont = true;
            this.Student.Appearance.Options.UseForeColor = true;
            this.Student.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.Student.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.Student.AppearanceHovered.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.Student.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.Student.AppearanceHovered.Options.UseBackColor = true;
            this.Student.AppearanceHovered.Options.UseFont = true;
            this.Student.AppearanceHovered.Options.UseForeColor = true;
            this.Student.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Student.Location = new System.Drawing.Point(546, 3);
            this.Student.Name = "Student";
            this.Student.Size = new System.Drawing.Size(538, 244);
            this.Student.TabIndex = 70;
            this.Student.Text = "Add/Edit &Student Account";
            this.Student.Click += new System.EventHandler(this.Student_Click);
            // 
            // Semester
            // 
            this.Semester.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Semester.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Semester.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.Semester.Appearance.ForeColor = System.Drawing.Color.White;
            this.Semester.Appearance.Options.UseBackColor = true;
            this.Semester.Appearance.Options.UseFont = true;
            this.Semester.Appearance.Options.UseForeColor = true;
            this.Semester.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.Semester.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.Semester.AppearanceHovered.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.Semester.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.Semester.AppearanceHovered.Options.UseBackColor = true;
            this.Semester.AppearanceHovered.Options.UseFont = true;
            this.Semester.AppearanceHovered.Options.UseForeColor = true;
            this.Semester.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Semester.Location = new System.Drawing.Point(3, 3);
            this.Semester.Name = "Semester";
            this.Semester.Size = new System.Drawing.Size(537, 244);
            this.Semester.TabIndex = 69;
            this.Semester.Text = "S&et Semester Subjects";
            this.Semester.Click += new System.EventHandler(this.Semester_Click);
            // 
            // TeacherPanel
            // 
            this.TeacherPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TeacherPanel.BackColor = System.Drawing.Color.Transparent;
            this.TeacherPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TeacherPanel.Controls.Add(this.tableLayoutPanel3);
            this.TeacherPanel.Location = new System.Drawing.Point(131, 105);
            this.TeacherPanel.Name = "TeacherPanel";
            this.TeacherPanel.Size = new System.Drawing.Size(1089, 518);
            this.TeacherPanel.TabIndex = 22;
            this.TeacherPanel.Visible = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.ViewScore, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.Check, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.StudentInfoTeacher, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.AddQuestionTeacher, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1087, 516);
            this.tableLayoutPanel3.TabIndex = 13;
            // 
            // ViewScore
            // 
            this.ViewScore.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ViewScore.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ViewScore.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.ViewScore.Appearance.ForeColor = System.Drawing.Color.White;
            this.ViewScore.Appearance.Options.UseBackColor = true;
            this.ViewScore.Appearance.Options.UseFont = true;
            this.ViewScore.Appearance.Options.UseForeColor = true;
            this.ViewScore.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.ViewScore.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.ViewScore.AppearanceHovered.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.ViewScore.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.ViewScore.AppearanceHovered.Options.UseBackColor = true;
            this.ViewScore.AppearanceHovered.Options.UseFont = true;
            this.ViewScore.AppearanceHovered.Options.UseForeColor = true;
            this.ViewScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ViewScore.Location = new System.Drawing.Point(546, 261);
            this.ViewScore.Name = "ViewScore";
            this.ViewScore.Size = new System.Drawing.Size(538, 252);
            this.ViewScore.TabIndex = 71;
            this.ViewScore.Text = "&Records";
            this.ViewScore.Click += new System.EventHandler(this.ViewScore_Click);
            // 
            // Check
            // 
            this.Check.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Check.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Check.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.Check.Appearance.ForeColor = System.Drawing.Color.White;
            this.Check.Appearance.Options.UseBackColor = true;
            this.Check.Appearance.Options.UseFont = true;
            this.Check.Appearance.Options.UseForeColor = true;
            this.Check.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.Check.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.Check.AppearanceHovered.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.Check.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.Check.AppearanceHovered.Options.UseBackColor = true;
            this.Check.AppearanceHovered.Options.UseFont = true;
            this.Check.AppearanceHovered.Options.UseForeColor = true;
            this.Check.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Check.Location = new System.Drawing.Point(3, 261);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(537, 252);
            this.Check.TabIndex = 70;
            this.Check.Text = "Check &Answer";
            this.Check.Click += new System.EventHandler(this.Check_Click);
            // 
            // StudentInfoTeacher
            // 
            this.StudentInfoTeacher.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.StudentInfoTeacher.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.StudentInfoTeacher.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.StudentInfoTeacher.Appearance.ForeColor = System.Drawing.Color.White;
            this.StudentInfoTeacher.Appearance.Options.UseBackColor = true;
            this.StudentInfoTeacher.Appearance.Options.UseFont = true;
            this.StudentInfoTeacher.Appearance.Options.UseForeColor = true;
            this.StudentInfoTeacher.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.StudentInfoTeacher.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.StudentInfoTeacher.AppearanceHovered.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.StudentInfoTeacher.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.StudentInfoTeacher.AppearanceHovered.Options.UseBackColor = true;
            this.StudentInfoTeacher.AppearanceHovered.Options.UseFont = true;
            this.StudentInfoTeacher.AppearanceHovered.Options.UseForeColor = true;
            this.StudentInfoTeacher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentInfoTeacher.Location = new System.Drawing.Point(546, 3);
            this.StudentInfoTeacher.Name = "StudentInfoTeacher";
            this.StudentInfoTeacher.Size = new System.Drawing.Size(538, 252);
            this.StudentInfoTeacher.TabIndex = 69;
            this.StudentInfoTeacher.Text = "Add/Edit &Student Account";
            this.StudentInfoTeacher.Click += new System.EventHandler(this.StudentInfoTeacher_Click);
            // 
            // AddQuestionTeacher
            // 
            this.AddQuestionTeacher.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.AddQuestionTeacher.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.AddQuestionTeacher.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.AddQuestionTeacher.Appearance.ForeColor = System.Drawing.Color.White;
            this.AddQuestionTeacher.Appearance.Options.UseBackColor = true;
            this.AddQuestionTeacher.Appearance.Options.UseFont = true;
            this.AddQuestionTeacher.Appearance.Options.UseForeColor = true;
            this.AddQuestionTeacher.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.AddQuestionTeacher.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.AddQuestionTeacher.AppearanceHovered.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.AddQuestionTeacher.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.AddQuestionTeacher.AppearanceHovered.Options.UseBackColor = true;
            this.AddQuestionTeacher.AppearanceHovered.Options.UseFont = true;
            this.AddQuestionTeacher.AppearanceHovered.Options.UseForeColor = true;
            this.AddQuestionTeacher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddQuestionTeacher.Location = new System.Drawing.Point(3, 3);
            this.AddQuestionTeacher.Name = "AddQuestionTeacher";
            this.AddQuestionTeacher.Size = new System.Drawing.Size(537, 252);
            this.AddQuestionTeacher.TabIndex = 68;
            this.AddQuestionTeacher.Text = "Add/Edit &Examination";
            this.AddQuestionTeacher.Click += new System.EventHandler(this.AddQuestionTeacher_Click);
            // 
            // ProctorPanel
            // 
            this.ProctorPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProctorPanel.BackColor = System.Drawing.Color.Transparent;
            this.ProctorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProctorPanel.Controls.Add(this.ProctorStudent);
            this.ProctorPanel.Location = new System.Drawing.Point(131, 105);
            this.ProctorPanel.Name = "ProctorPanel";
            this.ProctorPanel.Size = new System.Drawing.Size(1089, 518);
            this.ProctorPanel.TabIndex = 24;
            this.ProctorPanel.Visible = false;
            // 
            // ProctorStudent
            // 
            this.ProctorStudent.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ProctorStudent.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.ProctorStudent.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.ProctorStudent.Appearance.ForeColor = System.Drawing.Color.White;
            this.ProctorStudent.Appearance.Options.UseBackColor = true;
            this.ProctorStudent.Appearance.Options.UseFont = true;
            this.ProctorStudent.Appearance.Options.UseForeColor = true;
            this.ProctorStudent.AppearanceHovered.BackColor = System.Drawing.Color.White;
            this.ProctorStudent.AppearanceHovered.BackColor2 = System.Drawing.Color.White;
            this.ProctorStudent.AppearanceHovered.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.ProctorStudent.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.ProctorStudent.AppearanceHovered.Options.UseBackColor = true;
            this.ProctorStudent.AppearanceHovered.Options.UseFont = true;
            this.ProctorStudent.AppearanceHovered.Options.UseForeColor = true;
            this.ProctorStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProctorStudent.Location = new System.Drawing.Point(0, 0);
            this.ProctorStudent.Name = "ProctorStudent";
            this.ProctorStudent.Size = new System.Drawing.Size(1087, 516);
            this.ProctorStudent.TabIndex = 70;
            this.ProctorStudent.Text = "Add/Edit &Student Account";
            this.ProctorStudent.Click += new System.EventHandler(this.ProctorStudent_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.TeacherPanel);
            this.Controls.Add(this.ProctorPanel);
            this.Controls.Add(this.AdminPanel);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.tableLayoutPanel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "*****";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Menu_KeyDown);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xbtn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.AdminPanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.TeacherPanel.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ProctorPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.PictureEdit Xbtn;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl Clocktxt;
        private DevExpress.XtraEditors.PictureEdit LogOut;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl Codetxt;
        private DevExpress.XtraEditors.SimpleButton LogIn;
        private System.Windows.Forms.Label Greeting;
        private System.Windows.Forms.Panel AdminPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel TeacherPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel ProctorPanel;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.SimpleButton AdminAccount;
        private DevExpress.XtraEditors.SimpleButton Semester;
        private DevExpress.XtraEditors.SimpleButton ViewScore;
        private DevExpress.XtraEditors.SimpleButton Check;
        private DevExpress.XtraEditors.SimpleButton StudentInfoTeacher;
        private DevExpress.XtraEditors.SimpleButton AddQuestionTeacher;
        private DevExpress.XtraEditors.SimpleButton Student;
        private DevExpress.XtraEditors.SimpleButton ProctorStudent;
    }
}