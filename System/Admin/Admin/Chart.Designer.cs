namespace Lan_Based_Examination
{
    partial class Chart
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
            this.Essential = new System.Windows.Forms.TableLayoutPanel();
            this.Export = new DevExpress.XtraEditors.PictureEdit();
            this.Previous = new DevExpress.XtraEditors.PictureEdit();
            this.Next = new DevExpress.XtraEditors.PictureEdit();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.Students = new System.Windows.Forms.Label();
            this.Greeting = new System.Windows.Forms.Label();
            this.Xbtn = new DevExpress.XtraEditors.PictureEdit();
            this.Home = new DevExpress.XtraEditors.PictureEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.Subject = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Exam = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Clocktxt = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.Range = new System.Windows.Forms.Label();
            this.Essential.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Export.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Previous.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Next.Properties)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Xbtn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Home.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Subject.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Exam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Essential
            // 
            this.Essential.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Essential.ColumnCount = 3;
            this.Essential.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Essential.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Essential.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Essential.Controls.Add(this.Export, 0, 0);
            this.Essential.Controls.Add(this.Previous, 0, 0);
            this.Essential.Controls.Add(this.Next, 2, 0);
            this.Essential.Location = new System.Drawing.Point(512, 667);
            this.Essential.Name = "Essential";
            this.Essential.RowCount = 1;
            this.Essential.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Essential.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.Essential.Size = new System.Drawing.Size(327, 47);
            this.Essential.TabIndex = 53;
            this.Essential.Visible = false;
            // 
            // Export
            // 
            this.Export.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Export.EditValue = global::Lan_Based_Examination.Properties.Resources.excel;
            this.Export.Location = new System.Drawing.Point(146, 6);
            this.Export.Name = "Export";
            this.Export.Properties.AllowFocused = false;
            this.Export.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Export.Properties.Appearance.Options.UseBackColor = true;
            this.Export.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Export.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.Export.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.False;
            this.Export.Properties.ShowMenu = false;
            this.Export.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.False;
            this.Export.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.Export.ShowToolTips = false;
            this.Export.Size = new System.Drawing.Size(35, 35);
            this.Export.TabIndex = 50;
            this.Export.Click += new System.EventHandler(this.Export_Click);
            // 
            // Previous
            // 
            this.Previous.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Previous.EditValue = global::Lan_Based_Examination.Properties.Resources.Previous;
            this.Previous.Location = new System.Drawing.Point(37, 6);
            this.Previous.Name = "Previous";
            this.Previous.Properties.AllowFocused = false;
            this.Previous.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Previous.Properties.Appearance.Options.UseBackColor = true;
            this.Previous.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Previous.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.Previous.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.False;
            this.Previous.Properties.ShowMenu = false;
            this.Previous.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.False;
            this.Previous.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.Previous.ShowToolTips = false;
            this.Previous.Size = new System.Drawing.Size(35, 35);
            this.Previous.TabIndex = 48;
            this.Previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // Next
            // 
            this.Next.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Next.EditValue = global::Lan_Based_Examination.Properties.Resources.Next;
            this.Next.Location = new System.Drawing.Point(255, 6);
            this.Next.Name = "Next";
            this.Next.Properties.AllowFocused = false;
            this.Next.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Next.Properties.Appearance.Options.UseBackColor = true;
            this.Next.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Next.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.Next.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.False;
            this.Next.Properties.ShowMenu = false;
            this.Next.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.False;
            this.Next.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.Next.ShowToolTips = false;
            this.Next.Size = new System.Drawing.Size(35, 35);
            this.Next.TabIndex = 49;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.87319F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.83358F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.36263F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.930593F));
            this.tableLayoutPanel2.Controls.Add(this.panelControl1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.Greeting, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Xbtn, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.Home, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 11);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1326, 41);
            this.tableLayoutPanel2.TabIndex = 51;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.Students);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(425, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(469, 35);
            this.panelControl1.TabIndex = 59;
            // 
            // Students
            // 
            this.Students.BackColor = System.Drawing.Color.Transparent;
            this.Students.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Students.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Students.ForeColor = System.Drawing.Color.White;
            this.Students.Location = new System.Drawing.Point(0, 0);
            this.Students.Name = "Students";
            this.Students.Size = new System.Drawing.Size(469, 35);
            this.Students.TabIndex = 22;
            this.Students.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Students.Visible = false;
            // 
            // Greeting
            // 
            this.Greeting.BackColor = System.Drawing.Color.Transparent;
            this.Greeting.Dock = System.Windows.Forms.DockStyle.Left;
            this.Greeting.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Greeting.ForeColor = System.Drawing.Color.White;
            this.Greeting.Location = new System.Drawing.Point(3, 0);
            this.Greeting.Name = "Greeting";
            this.Greeting.Size = new System.Drawing.Size(416, 41);
            this.Greeting.TabIndex = 21;
            this.Greeting.Text = "Report";
            this.Greeting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // Home
            // 
            this.Home.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Home.EditValue = global::Lan_Based_Examination.Properties.Resources.house;
            this.Home.Location = new System.Drawing.Point(1218, 8);
            this.Home.Name = "Home";
            this.Home.Properties.AllowFocused = false;
            this.Home.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Home.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.Home.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.False;
            this.Home.Properties.ShowMenu = false;
            this.Home.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.False;
            this.Home.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.Home.ShowToolTips = false;
            this.Home.Size = new System.Drawing.Size(25, 25);
            this.Home.TabIndex = 19;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Subject);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(299, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(311, 76);
            this.panel3.TabIndex = 55;
            // 
            // Subject
            // 
            this.Subject.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Subject.Location = new System.Drawing.Point(0, 40);
            this.Subject.Name = "Subject";
            this.Subject.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Subject.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.Subject.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Subject.Properties.Appearance.Options.UseBackColor = true;
            this.Subject.Properties.Appearance.Options.UseFont = true;
            this.Subject.Properties.Appearance.Options.UseForeColor = true;
            this.Subject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Subject.Properties.DropDownRows = 5;
            this.Subject.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.Subject.Size = new System.Drawing.Size(311, 36);
            this.Subject.TabIndex = 23;
            this.Subject.SelectedIndexChanged += new System.EventHandler(this.Subject_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 41);
            this.label1.TabIndex = 22;
            this.label1.Text = "Subject";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Exam);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(741, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 76);
            this.panel1.TabIndex = 56;
            // 
            // Exam
            // 
            this.Exam.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Exam.Enabled = false;
            this.Exam.Location = new System.Drawing.Point(0, 40);
            this.Exam.Name = "Exam";
            this.Exam.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Exam.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.Exam.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Exam.Properties.Appearance.Options.UseBackColor = true;
            this.Exam.Properties.Appearance.Options.UseFont = true;
            this.Exam.Properties.Appearance.Options.UseForeColor = true;
            this.Exam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Exam.Properties.DropDownRows = 5;
            this.Exam.Properties.Items.AddRange(new object[] {
            "Prelim",
            "Midterm",
            "Semi-Final",
            "Finals"});
            this.Exam.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.Exam.Size = new System.Drawing.Size(311, 36);
            this.Exam.TabIndex = 24;
            this.Exam.SelectedIndexChanged += new System.EventHandler(this.Exam_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 41);
            this.label2.TabIndex = 22;
            this.label2.Text = "Exam";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(128, 154);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1094, 484);
            this.panel2.TabIndex = 57;
            this.panel2.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(111, 735);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.Size = new System.Drawing.Size(1032, 447);
            this.dataGridView1.TabIndex = 58;
            this.dataGridView1.Visible = false;
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
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.Clocktxt);
            this.panelControl2.Location = new System.Drawing.Point(1177, 676);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(154, 42);
            this.panelControl2.TabIndex = 52;
            // 
            // Range
            // 
            this.Range.BackColor = System.Drawing.Color.Transparent;
            this.Range.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Range.ForeColor = System.Drawing.Color.White;
            this.Range.Location = new System.Drawing.Point(13, 672);
            this.Range.Name = "Range";
            this.Range.Size = new System.Drawing.Size(416, 41);
            this.Range.TabIndex = 22;
            this.Range.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Range.Visible = false;
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.Range);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Essential);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Chart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Chart_FormClosed);
            this.Load += new System.EventHandler(this.Chart_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Chart_KeyDown);
            this.Essential.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Export.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Previous.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Next.Properties)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Xbtn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Home.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Subject.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Exam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Essential;
        private DevExpress.XtraEditors.PictureEdit Previous;
        private DevExpress.XtraEditors.PictureEdit Next;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label Greeting;
        private DevExpress.XtraEditors.PictureEdit Xbtn;
        private DevExpress.XtraEditors.PictureEdit Home;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.ComboBoxEdit Subject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.ComboBoxEdit Exam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.PictureEdit Export;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label Students;
        private DevExpress.XtraEditors.LabelControl Clocktxt;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Label Range;
    }
}