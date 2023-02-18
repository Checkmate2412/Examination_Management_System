namespace Lan_Based_Examination
{
    partial class MainView
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
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.Ptxt = new DevExpress.XtraEditors.TextEdit();
            this.Utxt = new DevExpress.XtraEditors.TextEdit();
            this.LIPanel = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit3 = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.LogIn = new DevExpress.XtraEditors.SimpleButton();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.Clocktxt = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Xbtn = new DevExpress.XtraEditors.PictureEdit();
            this.SYPanel = new DevExpress.XtraEditors.PanelControl();
            this.Back = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.SYE = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Enter = new DevExpress.XtraEditors.SimpleButton();
            this.SYS = new DevExpress.XtraEditors.TextEdit();
            this.logo = new DevExpress.XtraEditors.PictureEdit();
            this.CheckPanel = new DevExpress.XtraEditors.PanelControl();
            this.Check = new System.Windows.Forms.CheckBox();
            this.Greeting = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ptxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Utxt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LIPanel)).BeginInit();
            this.LIPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Xbtn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SYPanel)).BeginInit();
            this.SYPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SYE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SYS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckPanel)).BeginInit();
            this.CheckPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
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
            // LIPanel
            // 
            this.LIPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LIPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.LIPanel.Controls.Add(this.pictureEdit3);
            this.LIPanel.Controls.Add(this.pictureEdit2);
            this.LIPanel.Controls.Add(this.LogIn);
            this.LIPanel.Controls.Add(this.Ptxt);
            this.LIPanel.Controls.Add(this.Utxt);
            this.LIPanel.Location = new System.Drawing.Point(356, 189);
            this.LIPanel.Name = "LIPanel";
            this.LIPanel.Size = new System.Drawing.Size(638, 389);
            this.LIPanel.TabIndex = 0;
            // 
            // pictureEdit3
            // 
            this.pictureEdit3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureEdit3.EditValue = global::Lan_Based_Examination.Properties.Resources.pass;
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
            this.pictureEdit2.EditValue = global::Lan_Based_Examination.Properties.Resources.key;
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
            this.LogIn.Location = new System.Drawing.Point(65, 284);
            this.LogIn.Name = "LogIn";
            this.LogIn.Size = new System.Drawing.Size(514, 44);
            this.LogIn.TabIndex = 2;
            this.LogIn.Text = "&Log-In";
            this.LogIn.Click += new System.EventHandler(this.LogIn_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.Clocktxt);
            this.panelControl2.Location = new System.Drawing.Point(1177, 677);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(154, 42);
            this.panelControl2.TabIndex = 16;
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
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.Greeting, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Xbtn, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1326, 41);
            this.tableLayoutPanel2.TabIndex = 1;
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
            this.Xbtn.Properties.ShowEditMenuItem = DevExpress.Utils.DefaultBoolean.False;
            this.Xbtn.Properties.ShowMenu = false;
            this.Xbtn.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.False;
            this.Xbtn.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.Xbtn.ShowToolTips = false;
            this.Xbtn.Size = new System.Drawing.Size(25, 25);
            this.Xbtn.TabIndex = 0;
            this.Xbtn.Click += new System.EventHandler(this.Xbtn_Click);
            // 
            // SYPanel
            // 
            this.SYPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SYPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.SYPanel.Controls.Add(this.Back);
            this.SYPanel.Controls.Add(this.labelControl2);
            this.SYPanel.Controls.Add(this.SYE);
            this.SYPanel.Controls.Add(this.labelControl1);
            this.SYPanel.Controls.Add(this.Enter);
            this.SYPanel.Controls.Add(this.SYS);
            this.SYPanel.Location = new System.Drawing.Point(396, 238);
            this.SYPanel.Name = "SYPanel";
            this.SYPanel.Size = new System.Drawing.Size(558, 241);
            this.SYPanel.TabIndex = 2;
            this.SYPanel.Visible = false;
            // 
            // Back
            // 
            this.Back.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Back.Appearance.BackColor = System.Drawing.Color.White;
            this.Back.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Back.Appearance.Options.UseBackColor = true;
            this.Back.Appearance.Options.UseFont = true;
            this.Back.Appearance.Options.UseForeColor = true;
            this.Back.Location = new System.Drawing.Point(299, 165);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(183, 44);
            this.Back.TabIndex = 68;
            this.Back.Text = "&Back";
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(271, 95);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(9, 29);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "-";
            // 
            // SYE
            // 
            this.SYE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SYE.Location = new System.Drawing.Point(299, 93);
            this.SYE.Margin = new System.Windows.Forms.Padding(6);
            this.SYE.Name = "SYE";
            this.SYE.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SYE.Properties.Appearance.Options.UseFont = true;
            this.SYE.Properties.Appearance.Options.UseTextOptions = true;
            this.SYE.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SYE.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SYE.Properties.MaxLength = 4;
            this.SYE.Properties.NullValuePrompt = "End";
            this.SYE.Size = new System.Drawing.Size(183, 36);
            this.SYE.TabIndex = 1;
            this.SYE.ToolTipTitle = "Username";
            this.SYE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SYE_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(207, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(144, 29);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "School Year";
            // 
            // Enter
            // 
            this.Enter.Appearance.BackColor = System.Drawing.Color.White;
            this.Enter.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enter.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Enter.Appearance.Options.UseBackColor = true;
            this.Enter.Appearance.Options.UseFont = true;
            this.Enter.Appearance.Options.UseForeColor = true;
            this.Enter.Location = new System.Drawing.Point(69, 165);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(183, 44);
            this.Enter.TabIndex = 2;
            this.Enter.Text = "&Enter";
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // SYS
            // 
            this.SYS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SYS.Location = new System.Drawing.Point(69, 93);
            this.SYS.Margin = new System.Windows.Forms.Padding(6);
            this.SYS.Name = "SYS";
            this.SYS.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SYS.Properties.Appearance.Options.UseFont = true;
            this.SYS.Properties.Appearance.Options.UseTextOptions = true;
            this.SYS.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SYS.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SYS.Properties.MaxLength = 4;
            this.SYS.Properties.NullValuePrompt = "Start";
            this.SYS.Size = new System.Drawing.Size(183, 36);
            this.SYS.TabIndex = 0;
            this.SYS.ToolTipTitle = "Username";
            this.SYS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SYS_KeyPress);
            // 
            // logo
            // 
            this.logo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logo.EditValue = global::Lan_Based_Examination.Properties.Resources.Logo;
            this.logo.Location = new System.Drawing.Point(575, 72);
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
            this.logo.TabIndex = 15;
            // 
            // CheckPanel
            // 
            this.CheckPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.CheckPanel.Controls.Add(this.Check);
            this.CheckPanel.Location = new System.Drawing.Point(575, 592);
            this.CheckPanel.Name = "CheckPanel";
            this.CheckPanel.Size = new System.Drawing.Size(210, 42);
            this.CheckPanel.TabIndex = 67;
            this.CheckPanel.Visible = false;
            // 
            // Check
            // 
            this.Check.AutoSize = true;
            this.Check.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.Check.Location = new System.Drawing.Point(7, 10);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(193, 24);
            this.Check.TabIndex = 1;
            this.Check.Tag = "";
            this.Check.Text = "&Change School Year";
            this.Check.UseVisualStyleBackColor = true;
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
            this.Greeting.TabIndex = 23;
            this.Greeting.Text = "Log-In";
            this.Greeting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.CheckPanel);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.LIPanel);
            this.Controls.Add(this.SYPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log-In";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainView_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ptxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Utxt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LIPanel)).EndInit();
            this.LIPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Xbtn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SYPanel)).EndInit();
            this.SYPanel.ResumeLayout(false);
            this.SYPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SYE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SYS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckPanel)).EndInit();
            this.CheckPanel.ResumeLayout(false);
            this.CheckPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraEditors.TextEdit Ptxt;
        private DevExpress.XtraEditors.PictureEdit logo;
        private DevExpress.XtraEditors.PanelControl LIPanel;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.TextEdit Utxt;
        private DevExpress.XtraEditors.SimpleButton LogIn;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl Clocktxt;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.PictureEdit Xbtn;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl SYPanel;
        private DevExpress.XtraEditors.SimpleButton Enter;
        private DevExpress.XtraEditors.TextEdit SYS;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit SYE;
        private DevExpress.XtraEditors.PanelControl CheckPanel;
        private System.Windows.Forms.CheckBox Check;
        private DevExpress.XtraEditors.SimpleButton Back;
        private System.Windows.Forms.Label Greeting;
    }
}

