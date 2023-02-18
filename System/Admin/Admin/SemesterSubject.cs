using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Lan_Based_Examination
{
    public partial class SemesterSubject : DevExpress.XtraEditors.XtraForm
    {
        private string con;
        private MySqlConnection connected;
        MySqlCommand cmd = new MySqlCommand();
        TableLayoutPanel tb = new TableLayoutPanel();
        ComboBox cb = new ComboBox();
        string permission, name, schoolyear, username, count, status, logger;
        int id, addtb;

        private void Xbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                this.Close();
        }

        public SemesterSubject()
        {
            InitializeComponent();

            try
            {
                con = "server=localhost; database=examination; username=Exam; password=examination;";
            }
            catch (Exception err)
            {
                MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Clocktxt.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void Semester_SelectedIndexChanged(object sender, EventArgs e)
        {
            PanelEnabler();
        }

        private void Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            Semester.Enabled = true;
            Semester.SelectedIndex = -1;
            UncheckedSubject();
        }

        private void Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            Course.Enabled = true;
            Semester.Enabled = false;
            Course.SelectedIndex = -1;
            Semester.SelectedIndex = -1;
            UncheckedSubject();
        }

        private void AddUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (status == "create")
                {
                    foreach (Control ctrl in tb.Controls)
                    {
                        if (ctrl is CheckBox)
                        {
                            CheckBox c = ctrl as CheckBox;

                            if (c.Checked == true)
                            {
                                {
                                    cmd.CommandText = "INSERT INTO `Semester_Subjects` (`subject`, `Course`, `Year`, `Semester`) " +
                                        "VALUES('" + c.Text + "', '" + Course.Text + "', '" + Year.Text + "', '" + Semester.Text + "')";
                                    connected.Open();
                                    cmd.Connection = connected;
                                    cmd.ExecuteNonQuery();
                                    connected.Close();
                                }
                            }
                        }
                    }

                    logger = "Finish creating " + Course.Text + ", " + Year.Text +
                    ", " + Semester.Text + " Semester";
                    Log();
                    MessageBox.Show("Saved");
                }

                else if (status == "update")
                {
                    cmd.CommandText = "Delete from `Semester_Subjects` where `Course` = '" + Course.Text + 
                        "' && `Year` = '" + Year.Text + "' && `Semester` = '" + Semester.Text + "'";
                    connected.Open();
                    cmd.Connection = connected;
                    cmd.ExecuteNonQuery();
                    connected.Close();

                    foreach (Control ctrl in tb.Controls)
                    {
                        if (ctrl is CheckBox)
                        {
                            CheckBox c = ctrl as CheckBox;
                            if (c.Checked == true)
                            {
                                cmd.CommandText = "INSERT INTO `Semester_Subjects` (`subject`, `Course`, `Year`, `Semester`) " +
                                    "VALUES('" + c.Text + "', '" + Course.Text + "', '" + Year.Text + "', '" + Semester.Text + "')";
                                connected.Open();
                                cmd.Connection = connected;
                                cmd.ExecuteNonQuery();
                                connected.Close();
                            }
                        }
                    }

                    logger = "Finish updating " + Course.Text + ", " + Year.Text +
                    ", " + Semester.Text + " Semester";
                    Log();
                    Log();
                    MessageBox.Show("Updated");
                }

                Clear();
            }

            catch (Exception err)
            {
                MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Log()
        {
            try
            {
                connected.Open();
                cmd.Connection = connected;
                cmd.CommandText = "INSERT INTO `administrator_log` (`name`, `username`, `Time`, `Remarks`) " +
                    "VALUES('" + name + "', '" + username + "', '" + DateTime.Now.ToString() + "', '" + logger + "')";
                cmd.Connection = connected;
                cmd.ExecuteNonQuery();
                connected.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Home_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Back to Menu?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                logger = "Entered to Main Menu Form";
                Log();
                Menu menu = new Menu();
                menu.Need(username, name, permission, schoolyear);
                menu.Show();
                this.Hide();
            }
        }

        private void SemesterSubject_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            Check();
            SubjectLoad();
        }

        private void PanelEnabler()
        {
            ThreePanel.Enabled = true;
            connected = new MySqlConnection(con);
            connected.Open();
            cmd.CommandText = "select count(*) from information_schema.tables where table_name='Semester_Subjects' AND TABLE_SCHEMA='examination'";
            cmd.Connection = connected;
            string count = cmd.ExecuteScalar().ToString();
            connected.Close();
            cb.Items.Clear();
            Subject.Visible = true;
            Essential.Visible = true;

            if (count == "0")
            {
                logger = "Creating list of subjects per semester: " + Course.Text + ", " + Year.Text +
                    ", " + Semester.Text + " Semester";
                Log();
                status = "create";
                connected.Open();
                cmd.CommandText = "create table `Semester_Subjects` (`Course` LONGTEXT NOT NULL , `Year` LONGTEXT NOT NULL " +
                    ", `Semester` LONGTEXT NOT NULL , `Subject` LONGTEXT NOT NULL ) ENGINE = InnoDB;";
                cmd.Connection = connected;
                cmd.ExecuteNonQuery();
                connected.Close();
            }

            else if (count == "1")
            {
                status = "update";
                logger = "Updating the list of subjects per semester.";
                Log();
                CheckedSubject();
            }
        }

        private void Subject_Click(object sender, EventArgs e)
        {
            logger = "Entered to Subject List Form";
            Log();
            SubjectList SL = new SubjectList();
            SL.ShowDialog();
            tb.Dock = DockStyle.None;
            RefreshControl();
            logger = "Entered to Semester Subject Form";
            Log();
        }

        private void SemesterSubject_FormClosing(object sender, FormClosingEventArgs e)
        {
            logger = "Exit Application";
            Log();
        }

        private void SemesterSubject_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger = "Exit Application";
            Log();
        }

        private void SemesterSubject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Home_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.F1)
                MessageBox.Show("Alt + A or U = Add or Update the Semester Subjects\nDelete = Clear All the Fields\nEscape = Go to Main Menu" +
                    "\n\nWhen selecting subject/s:\n\nAlt + S = Go to Subject Form", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else if (Subject.Visible == true && e.KeyCode == Keys.S && e.Modifiers == Keys.Alt)
                Subject_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.Delete && Essential.Visible == true)
                Clearbtn_Click_1(sender, EventArgs.Empty);

            else if ((e.KeyCode == Keys.A || e.KeyCode == Keys.U) && e.Modifiers == Keys.Alt && Essential.Visible == true)
                AddUpdate_Click(sender, EventArgs.Empty);
        }

        private void RefreshControl()
        {
            tb.Controls.Clear();
            Check();
            SubjectLoad();
            CheckedSubject();
        }

        private void Clearbtn_Click_1(object sender, EventArgs e)
        {
            Clear();
        }

        public void Need(string un, string Gname, string perm, string sy)
        {
            username = un;
            permission = perm;
            name = Gname;
            schoolyear = sy;
        }

        private void Check()
        {
            try
            {
                connected = new MySqlConnection(con);
                connected.Open();
                cmd.CommandText = "select count(*) from `subject`";
                cmd.Connection = connected;
                count = cmd.ExecuteScalar().ToString();
                id = int.Parse(count);
                connected.Close();
            }

            catch (Exception err)
            {
                MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SubjectLoad()
        {
            connected = new MySqlConnection(con);
            int Ans = id % 3;
            int s = id / 3;

            if (Ans != 0)
            {
                s = s + 1;
            }

            if (s == 1)
            {
                tb.Dock = DockStyle.None;
                tb.Location = new Point(1, panel5.Height / 3);
                tb.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                tb.Height = panel5.Height / 3;
                tb.Width = panel5.Width;
            }

            else if (s == 2 || s == 3)
            {
                tb.Dock = DockStyle.None;
                tb.Location = new Point(1, panel5.Height / (s * 2));
                tb.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                tb.Height = panel5.Height / s;
                tb.Width = panel5.Width;
            }

            else
            {
                tb.Dock = DockStyle.Fill;
            }

            tb.ColumnCount = 3;
            tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tb.RowCount = s;

            for (int row = 0; row < s; row++)
            {
                tb.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            }

            ComboBox cb1 = new ComboBox();

            try
            {
                cmd.CommandText = "select * from `subject`";
                cmd.Connection = connected;
                connected.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cb1.Items.Add(dr["subject"].ToString());
                }
                connected.Close();
                cb1.Sorted = true;
            }

            catch (Exception err)
            {
                MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            int columncount = 0, rowcount = 0;

            for (addtb = 0; addtb < id; addtb++)
            {
                CheckBox box = new CheckBox();
                box.Dock = DockStyle.Fill;
                box.BackColor = Color.Transparent;
                box.AutoSize = true;

                box.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
                box.ForeColor = Color.White;
                box.Text = cb1.GetItemText(cb1.Items[addtb]);
                box.Name = addtb.ToString();

                tb.AutoScroll = true;
                tb.AutoSize = true;

                tb.Controls.Add(box, columncount, rowcount);

                if (columncount != 3)
                {
                    columncount++;
                }

                else if (columncount == 3)
                {
                    rowcount++;
                    columncount = 0;
                }
            }

            tb.BackColor = Color.Transparent;
            tb.Name = "tbsub";
            panel5.Controls.Add(tb);

        }

        private void Clear()
        {
            Year.SelectedIndex = -1;
            Course.SelectedIndex = -1;
            Semester.SelectedIndex = -1;
            Semester.Enabled = false;
            Course.Enabled = false;
            ThreePanel.Enabled = false;
            UncheckedSubject();
        }

        public void UncheckedSubject()
        {
            foreach (Control ctrl in tb.Controls)
            {
                CheckBox c = ctrl as CheckBox;
                c.Checked = false;
            }
        }

        public void CheckedSubject()
        {
            if (Course.Text != "" && Year.Text != "" && Semester.Text != "")
            {
                try
                {
                    cmd.CommandText = "select * from `Semester_Subjects` where `Course` = '" + Course.Text + "' && `Year` = '" + Year.Text + "' && `Semester` = '" + Semester.Text + "'";
                    cmd.Connection = connected;
                    connected.Open();
                    MySqlDataReader dr1 = cmd.ExecuteReader();

                    while (dr1.Read())
                    {
                        cb.Items.Add(dr1["subject"].ToString());
                    }
                    connected.Close();
                    cb.Sorted = true;
                }

                catch (Exception err)
                {
                    MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                for (int subcounter = 0; subcounter < cb.Items.Count; subcounter++)
                {
                    foreach (Control ctrl in tb.Controls)
                    {
                        if (ctrl is CheckBox)
                        {
                            CheckBox c = ctrl as CheckBox;
                            if (c.Text == cb.GetItemText(cb.Items[subcounter]))
                                c.Checked = true;
                        }
                    }
                }
            }
        }
    }
}