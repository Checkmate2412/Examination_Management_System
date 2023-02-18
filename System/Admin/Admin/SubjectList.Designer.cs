namespace Lan_Based_Examination
{
    partial class SubjectList
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
            this.SL = new DevExpress.XtraEditors.ComboBoxEdit();
            this.Greeting = new System.Windows.Forms.Label();
            this.Panel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.SU = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.SC = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SN = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Delete = new DevExpress.XtraEditors.SimpleButton();
            this.AddUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.Clearbtn = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SL.Properties)).BeginInit();
            this.Panel.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SU.Properties)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SN.Properties)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.SL);
            this.panel1.Controls.Add(this.Greeting);
            this.panel1.Location = new System.Drawing.Point(75, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 82);
            this.panel1.TabIndex = 42;
            // 
            // SL
            // 
            this.SL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SL.Location = new System.Drawing.Point(0, 46);
            this.SL.Name = "SL";
            this.SL.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.SL.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.SL.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.SL.Properties.Appearance.Options.UseBackColor = true;
            this.SL.Properties.Appearance.Options.UseFont = true;
            this.SL.Properties.Appearance.Options.UseForeColor = true;
            this.SL.Properties.Appearance.Options.UseTextOptions = true;
            this.SL.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SL.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SL.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SL.Properties.DropDownRows = 5;
            this.SL.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.SL.Size = new System.Drawing.Size(435, 36);
            this.SL.TabIndex = 22;
            this.SL.SelectedIndexChanged += new System.EventHandler(this.SL_SelectedIndexChanged);
            // 
            // Greeting
            // 
            this.Greeting.BackColor = System.Drawing.Color.Transparent;
            this.Greeting.Dock = System.Windows.Forms.DockStyle.Top;
            this.Greeting.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Greeting.ForeColor = System.Drawing.Color.White;
            this.Greeting.Location = new System.Drawing.Point(0, 0);
            this.Greeting.Name = "Greeting";
            this.Greeting.Size = new System.Drawing.Size(435, 36);
            this.Greeting.TabIndex = 21;
            this.Greeting.Text = "Subject";
            this.Greeting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel
            // 
            this.Panel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel.Controls.Add(this.tableLayoutPanel4);
            this.Panel.Controls.Add(this.tableLayoutPanel3);
            this.Panel.Controls.Add(this.tableLayoutPanel1);
            this.Panel.Location = new System.Drawing.Point(74, 126);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(436, 224);
            this.Panel.TabIndex = 43;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.SU, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 140);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.47059F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.52941F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(434, 70);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // SU
            // 
            this.SU.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SU.Location = new System.Drawing.Point(6, 26);
            this.SU.Margin = new System.Windows.Forms.Padding(6);
            this.SU.Name = "SU";
            this.SU.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SU.Properties.Appearance.Options.UseFont = true;
            this.SU.Properties.Appearance.Options.UseTextOptions = true;
            this.SU.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SU.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SU.Properties.NullValuePrompt = "Unit/s";
            this.SU.Size = new System.Drawing.Size(422, 36);
            this.SU.TabIndex = 1;
            this.SU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SU_KeyPress);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.SC, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 70);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.47059F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.52941F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(434, 70);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // SC
            // 
            this.SC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SC.Location = new System.Drawing.Point(6, 26);
            this.SC.Margin = new System.Windows.Forms.Padding(6);
            this.SC.Name = "SC";
            this.SC.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SC.Properties.Appearance.Options.UseFont = true;
            this.SC.Properties.Appearance.Options.UseTextOptions = true;
            this.SC.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SC.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SC.Properties.NullValuePrompt = "Subject Code";
            this.SC.Size = new System.Drawing.Size(422, 36);
            this.SC.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.SN, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.47059F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.52941F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(434, 70);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // SN
            // 
            this.SN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SN.Location = new System.Drawing.Point(6, 26);
            this.SN.Margin = new System.Windows.Forms.Padding(6);
            this.SN.Name = "SN";
            this.SN.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SN.Properties.Appearance.Options.UseFont = true;
            this.SN.Properties.Appearance.Options.UseTextOptions = true;
            this.SN.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SN.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SN.Properties.NullValuePrompt = "Subject Name";
            this.SN.Size = new System.Drawing.Size(422, 36);
            this.SN.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.Delete, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.AddUpdate, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Clearbtn, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(129, 385);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(327, 44);
            this.tableLayoutPanel2.TabIndex = 45;
            // 
            // Delete
            // 
            this.Delete.Appearance.BackColor = System.Drawing.Color.White;
            this.Delete.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Delete.Appearance.Options.UseBackColor = true;
            this.Delete.Appearance.Options.UseFont = true;
            this.Delete.Appearance.Options.UseForeColor = true;
            this.Delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Delete.Location = new System.Drawing.Point(221, 3);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(103, 38);
            this.Delete.TabIndex = 48;
            this.Delete.Text = "&Delete";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // AddUpdate
            // 
            this.AddUpdate.Appearance.BackColor = System.Drawing.Color.White;
            this.AddUpdate.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddUpdate.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.AddUpdate.Appearance.Options.UseBackColor = true;
            this.AddUpdate.Appearance.Options.UseFont = true;
            this.AddUpdate.Appearance.Options.UseForeColor = true;
            this.AddUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddUpdate.Location = new System.Drawing.Point(3, 3);
            this.AddUpdate.Name = "AddUpdate";
            this.AddUpdate.Size = new System.Drawing.Size(103, 38);
            this.AddUpdate.TabIndex = 47;
            this.AddUpdate.Text = "&Add";
            this.AddUpdate.Click += new System.EventHandler(this.AddUpdate_Click);
            // 
            // Clearbtn
            // 
            this.Clearbtn.Appearance.BackColor = System.Drawing.Color.White;
            this.Clearbtn.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clearbtn.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Clearbtn.Appearance.Options.UseBackColor = true;
            this.Clearbtn.Appearance.Options.UseFont = true;
            this.Clearbtn.Appearance.Options.UseForeColor = true;
            this.Clearbtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Clearbtn.Location = new System.Drawing.Point(112, 3);
            this.Clearbtn.Name = "Clearbtn";
            this.Clearbtn.Size = new System.Drawing.Size(103, 38);
            this.Clearbtn.TabIndex = 46;
            this.Clearbtn.Text = "&Clear";
            this.Clearbtn.Click += new System.EventHandler(this.Clearbtn_Click);
            // 
            // SubjectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 467);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Panel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubjectList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SubjectList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SubjectList_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SL.Properties)).EndInit();
            this.Panel.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SU.Properties)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SC.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SN.Properties)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SimpleButton Delete;
        private DevExpress.XtraEditors.SimpleButton AddUpdate;
        private DevExpress.XtraEditors.SimpleButton Clearbtn;
        private System.Windows.Forms.Label Greeting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.ComboBoxEdit SL;
        private DevExpress.XtraEditors.TextEdit SN;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevExpress.XtraEditors.TextEdit SU;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevExpress.XtraEditors.TextEdit SC;
    }
}