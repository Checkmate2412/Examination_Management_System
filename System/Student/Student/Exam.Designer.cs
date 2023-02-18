namespace Student_Examination
{
    partial class Exam
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.Clocktxt = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Greeting = new System.Windows.Forms.Label();
            this.Xbtn = new DevExpress.XtraEditors.PictureEdit();
            this.Home = new DevExpress.XtraEditors.PictureEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.OnePanel = new System.Windows.Forms.Panel();
            this.Examtxt = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Xbtn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Home.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Examtxt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.Clocktxt);
            this.panelControl2.Location = new System.Drawing.Point(1177, 676);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(154, 42);
            this.panelControl2.TabIndex = 61;
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.87319F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.83358F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.36263F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.930593F));
            this.tableLayoutPanel2.Controls.Add(this.Greeting, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Xbtn, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.Home, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 11);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1326, 41);
            this.tableLayoutPanel2.TabIndex = 60;
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
            this.Greeting.Text = "Take Examination";
            this.Greeting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Xbtn
            // 
            this.Xbtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Xbtn.EditValue = global::Student_Examination.Properties.Resources.CancelRed;
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
            this.Home.EditValue = global::Student_Examination.Properties.Resources.house;
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
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.Examtxt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(441, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 76);
            this.panel1.TabIndex = 62;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(469, 41);
            this.label2.TabIndex = 22;
            this.label2.Text = "Exam";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OnePanel
            // 
            this.OnePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OnePanel.BackColor = System.Drawing.Color.Transparent;
            this.OnePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OnePanel.Location = new System.Drawing.Point(134, 169);
            this.OnePanel.Name = "OnePanel";
            this.OnePanel.Size = new System.Drawing.Size(1082, 484);
            this.OnePanel.TabIndex = 63;
            // 
            // Examtxt
            // 
            this.Examtxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Examtxt.Location = new System.Drawing.Point(0, 40);
            this.Examtxt.Name = "Examtxt";
            this.Examtxt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Examtxt.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.Examtxt.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Examtxt.Properties.Appearance.Options.UseBackColor = true;
            this.Examtxt.Properties.Appearance.Options.UseFont = true;
            this.Examtxt.Properties.Appearance.Options.UseForeColor = true;
            this.Examtxt.Properties.Appearance.Options.UseTextOptions = true;
            this.Examtxt.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Examtxt.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Examtxt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Examtxt.Properties.DropDownRows = 5;
            this.Examtxt.Properties.Items.AddRange(new object[] {
            "Prelim",
            "Midterm",
            "Semi-Finals",
            "Finals"});
            this.Examtxt.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.Examtxt.Size = new System.Drawing.Size(469, 36);
            this.Examtxt.TabIndex = 64;
            this.Examtxt.SelectedIndexChanged += new System.EventHandler(this.Examtxt_SelectedIndexChanged_1);
            // 
            // Exam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.OnePanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Exam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Exam_FormClosed);
            this.Load += new System.EventHandler(this.Exam_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Exam_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Xbtn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Home.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Examtxt.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl Clocktxt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label Greeting;
        private DevExpress.XtraEditors.PictureEdit Xbtn;
        private DevExpress.XtraEditors.PictureEdit Home;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel OnePanel;
        private DevExpress.XtraEditors.ComboBoxEdit Examtxt;
    }
}