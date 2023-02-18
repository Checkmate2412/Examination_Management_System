namespace Student_Examination
{
    partial class Form1
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Xbtn = new DevExpress.XtraEditors.PictureEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.Clocktxt = new DevExpress.XtraEditors.LabelControl();
            this.LIPanel = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit3 = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.LogIn = new DevExpress.XtraEditors.SimpleButton();
            this.Ptxt = new DevExpress.XtraEditors.TextEdit();
            this.Utxt = new DevExpress.XtraEditors.TextEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.logo = new DevExpress.XtraEditors.PictureEdit();
            this.Greeting = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Xbtn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LIPanel)).BeginInit();
            this.LIPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ptxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Utxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.Greeting, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Xbtn, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 11);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1326, 41);
            this.tableLayoutPanel2.TabIndex = 18;
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
            this.panelControl2.Location = new System.Drawing.Point(1177, 676);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(154, 42);
            this.panelControl2.TabIndex = 20;
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
            // LIPanel
            // 
            this.LIPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LIPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.LIPanel.Controls.Add(this.pictureEdit3);
            this.LIPanel.Controls.Add(this.pictureEdit2);
            this.LIPanel.Controls.Add(this.LogIn);
            this.LIPanel.Controls.Add(this.Ptxt);
            this.LIPanel.Controls.Add(this.Utxt);
            this.LIPanel.Location = new System.Drawing.Point(356, 188);
            this.LIPanel.Name = "LIPanel";
            this.LIPanel.Size = new System.Drawing.Size(638, 389);
            this.LIPanel.TabIndex = 17;
            // 
            // pictureEdit3
            // 
            this.pictureEdit3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureEdit3.EditValue = global::Student_Examination.Properties.Resources.pass;
            this.pictureEdit3.Location = new System.Drawing.Point(80, 109);
            this.pictureEdit3.Name = "pictureEdit3";
            this.pictureEdit3.Properties.AllowFocused = false;
            this.pictureEdit3.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit3.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.False;
            this.pictureEdit3.Properties.ShowMenu = false;
            this.pictureEdit3.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.False;
            this.pictureEdit3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit3.ShowToolTips = false;
            this.pictureEdit3.Size = new System.Drawing.Size(50, 50);
            this.pictureEdit3.TabIndex = 17;
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureEdit2.EditValue = global::Student_Examination.Properties.Resources.key;
            this.pictureEdit2.Location = new System.Drawing.Point(80, 185);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.AllowFocused = false;
            this.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit2.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.False;
            this.pictureEdit2.Properties.ShowMenu = false;
            this.pictureEdit2.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.False;
            this.pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit2.ShowToolTips = false;
            this.pictureEdit2.Size = new System.Drawing.Size(50, 50);
            this.pictureEdit2.TabIndex = 16;
            // 
            // LogIn
            // 
            this.LogIn.Appearance.BackColor = System.Drawing.Color.White;
            this.LogIn.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogIn.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.LogIn.Appearance.Options.UseBackColor = true;
            this.LogIn.Appearance.Options.UseFont = true;
            this.LogIn.Appearance.Options.UseForeColor = true;
            this.LogIn.Location = new System.Drawing.Point(65, 294);
            this.LogIn.Name = "LogIn";
            this.LogIn.Size = new System.Drawing.Size(514, 44);
            this.LogIn.TabIndex = 2;
            this.LogIn.Text = "&Log-In";
            this.LogIn.Click += new System.EventHandler(this.LogIn_Click);
            // 
            // Ptxt
            // 
            this.Ptxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Ptxt.Location = new System.Drawing.Point(149, 192);
            this.Ptxt.Margin = new System.Windows.Forms.Padding(6);
            this.Ptxt.Name = "Ptxt";
            this.Ptxt.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ptxt.Properties.Appearance.Options.UseFont = true;
            this.Ptxt.Properties.NullValuePrompt = "Password";
            this.Ptxt.Properties.UseSystemPasswordChar = true;
            this.Ptxt.Size = new System.Drawing.Size(430, 36);
            this.Ptxt.TabIndex = 1;
            // 
            // Utxt
            // 
            this.Utxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Utxt.Location = new System.Drawing.Point(149, 116);
            this.Utxt.Margin = new System.Windows.Forms.Padding(6);
            this.Utxt.Name = "Utxt";
            this.Utxt.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Utxt.Properties.Appearance.Options.UseFont = true;
            this.Utxt.Properties.NullValuePrompt = "Username";
            this.Utxt.Size = new System.Drawing.Size(430, 36);
            this.Utxt.TabIndex = 0;
            this.Utxt.ToolTipTitle = "Username";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // logo
            // 
            this.logo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logo.EditValue = global::Student_Examination.Properties.Resources.Logo;
            this.logo.Location = new System.Drawing.Point(575, 71);
            this.logo.Name = "logo";
            this.logo.Properties.AllowFocused = false;
            this.logo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.logo.Properties.Appearance.Options.UseBackColor = true;
            this.logo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.logo.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.False;
            this.logo.Properties.ShowMenu = false;
            this.logo.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.False;
            this.logo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.logo.ShowToolTips = false;
            this.logo.Size = new System.Drawing.Size(200, 200);
            this.logo.TabIndex = 19;
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
            this.Greeting.TabIndex = 24;
            this.Greeting.Text = "Student Log-In";
            this.Greeting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AcceptButton = this.LogIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.LIPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Xbtn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LIPanel)).EndInit();
            this.LIPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ptxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Utxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.PictureEdit Xbtn;
        private DevExpress.XtraEditors.PictureEdit logo;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl Clocktxt;
        private DevExpress.XtraEditors.PanelControl LIPanel;
        private DevExpress.XtraEditors.PictureEdit pictureEdit3;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraEditors.SimpleButton LogIn;
        private DevExpress.XtraEditors.TextEdit Ptxt;
        private DevExpress.XtraEditors.TextEdit Utxt;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Greeting;
    }
}

