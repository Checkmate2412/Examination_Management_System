using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Lan_Based_Examination
{
    public partial class AdminAccount : DevExpress.XtraEditors.XtraForm
    {
        private string con;
        private MySqlConnection connected;
        MySqlCommand cmd = new MySqlCommand();
        string permission, name, schoolyear, status, date, button, sub, uname, username, count, logger;
        TableLayoutPanel tb = new TableLayoutPanel();
        ComboBox cb = new ComboBox();
        int i, id, numberofsubject, addtb;
        int subnum = 1;
        int savenum = 1;
        int loop = 0;

        public void Need(string un, string Gname, string perm, string sy)
        {
            username = un;
            permission = perm;
            name = Gname;
            schoolyear = sy;
        }

        public int ColumnFind(int number)
        {
            cmd.CommandText = "select count(*) from information_schema.columns where TABLE_SCHEMA = 'examination' AND " +
               "table_name = 'administrator' AND COLUMN_NAME = 'Subject" + number + "'";
            connected.Open();
            cmd.Connection = connected;
            string countstr = cmd.ExecuteScalar().ToString();
            int count = Int32.Parse(countstr);
            connected.Close();
            return count;
        }

        public void SubNotEmpty()
        {
            try
            {
                int count = ColumnFind(subnum);

                if (count == 0)
                    sub = "";

                else
                {
                    cmd.CommandText = "select * from administrator where username = '" + uname + "'";
                    cmd.Connection = connected;
                    connected.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        sub = dr["subject" + subnum + ""].ToString();
                        numberofsubject = (Int32.Parse(dr["numberofsubject"].ToString()));
                    }
                    subnum++;
                    connected.Close();
                }
            }

            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Save(string checkText)
        {
            try
            {
                int count = ColumnFind(savenum);

                if (count == 0)
                {
                    cmd.CommandText = "ALTER TABLE `administrator` ADD `Subject" + savenum + "` VARCHAR(999) NOT NULL;";
                    cmd.Connection = connected;
                    connected.Open();
                    cmd.ExecuteReader();
                    connected.Close();
                }

                Updated(checkText);
            }

            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            savenum++;
        }

        public void Updated(string checkText)
        {
            connected.Open();
            cmd.CommandText = "Update administrator set `Subject" + savenum + "` = '" + checkText + "', `numberofsubject` = '" + numberofsubject + "'" +
                " where username = '" + uname + "'";
            cmd.Connection = connected;
            cmd.ExecuteNonQuery();
            connected.Close();
        }

        public void Deletion()
        {
            int delnum = loop;

            try
            {
                do
                {
                    delnum++;
                    cmd.CommandText = "update `administrator` set `Subject" + delnum + "` = '' where `username` = '" + uname + "'";
                    cmd.Connection = connected;
                    connected.Open();
                    cmd.ExecuteNonQuery();
                    connected.Close();
                }
                while (numberofsubject != delnum);
            }

            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Check()
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
            cb.Items.Clear();

            if (Ans != 0)
                s = s + 1;

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
                tb.Dock = DockStyle.Fill;

            tb.ColumnCount = 3;
            tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tb.RowCount = s;

            for (int row = 0; row < s; row++)
            {
                tb.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            }

            try
            {
                cmd.CommandText = "select * from `subject`";
                cmd.Connection = connected;
                connected.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cb.Items.Add(dr["subject"].ToString());
                }

                connected.Close();
                cb.Sorted = true;
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
                box.Text = cb.GetItemText(cb.Items[addtb]);
                box.Name = addtb.ToString();
                box.ForeColor = Color.White;

                tb.AutoScroll = true;
                tb.AutoSize = true;

                tb.Controls.Add(box, columncount, rowcount);

                if (columncount != 3)
                    columncount++;

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

        private void Insert()
        {
            try
            {
                connected = new MySqlConnection(con);
                connected.Open();
                cmd.CommandText = "select count(id) from administrator";
                cmd.Connection = connected;
                string count = cmd.ExecuteScalar().ToString();
                int iddb = int.Parse(count) + 1;
                connected.Close();

                date = DateTime.Now.ToString("MM/dd/yyyy");
                connected = new MySqlConnection(con);
                connected.Open();
                cmd.Connection = connected;
                cmd.CommandText = "INSERT INTO administrator (`ID`, `name`, `lastname`, `firstname`, `middlename`,  " +
                "`username`, `password`, `key_code`, `permission`, `date`) VALUES('" + iddb + "' , '" + LN.Text + ", " + FN.Text + " "
                + MN.Text + "', '" + LN.Text + "', '" + FN.Text + "','" + MN.Text + "','" + UN.Text + "','" + Pass.Text + "', " +
                "SUBSTRING(MD5(RAND()) FROM 1 FOR 8), '" + P.Text + "','" + date + "')";
                cmd.Connection = connected;
                cmd.ExecuteNonQuery();
                connected.Close();
                InsertSubject();
                MessageBox.Show("Saved");
                CBoxUpdate();
                logger = "Inserted an admin account: " + UN.Text + "";
                Log();
            }

            catch (Exception err)
            {
                MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CBoxUpdate()
        {
            Nametxt.Properties.Items.Clear();
            connected = new MySqlConnection(con);
            cmd.CommandText = "select * from administrator";
            cmd.Connection = connected;
            connected.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Nametxt.Properties.Items.Add(dr["name"].ToString());
            }

            connected.Close();
        }

        private void InsertSubject()
        {
            subnum = 1;
            loop = 0;
            savenum = 1;
            SubNotEmpty();

            foreach (Control ctrl in tb.Controls)
            {
                if (ctrl is CheckBox)
                {
                    CheckBox c = ctrl as CheckBox;

                    if (c.Checked == true)
                    {
                        string checkText = c.Text;

                        do
                        {
                            loop++;
                            Save(checkText);

                        } while (checkText == "");
                    }
                }
            }

            if (numberofsubject > loop)
                Deletion();

            connected.Open();
            cmd.CommandText = "Update administrator set `numberofsubject` = '" + loop + "' where username = '" + uname + "'";
            cmd.Connection = connected;
            cmd.ExecuteNonQuery();
            connected.Close();
        }

        private void RefreshControl()
        {
            tb.Controls.Clear();
            Check();
            SubjectLoad();
            CheckedSubject();
        }

        private void Updated()
        {
            date = DateTime.Now.ToString("MM/dd/yyyy");
            connected = new MySqlConnection(con);
            connected.Open();
            cmd.CommandText = "Update administrator set `lastname` = '" + LN.Text + "', `firstname` = '" + FN.Text
            + "',  `middlename` = '" + MN.Text + "', `Username` = '" + UN.Text + "', `Password` = '" + Pass.Text +
            "', `key_code` = SUBSTRING(MD5(RAND()) FROM 1 FOR 8), `permission` = '" + P.Text + "', `date` = '"
            + date + "' where name = '" + UN.Text + "'";
            cmd.Connection = connected;
            cmd.ExecuteNonQuery();
            connected.Close();
            InsertSubject();
            MessageBox.Show("Updated");
            CBoxUpdate();
            logger = "Modified an admin account: " + UN.Text + "";
            Log();
        }

        private void Nametxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                status = "update";
                UN.Enabled = false;
                connected = new MySqlConnection(con);
                cmd.CommandText = "select * from administrator where name = '" + Nametxt.Text + "'";
                cmd.Connection = connected;
                connected.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    LN.Text = dr["lastname"].ToString();
                    FN.Text = dr["firstname"].ToString();
                    MN.Text = (dr["middlename"].ToString());
                    UN.Text = dr["username"].ToString();
                    uname = dr["username"].ToString();
                    Pass.Text = (dr["password"].ToString());
                    P.Text = (dr["permission"].ToString());
                }
                connected.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            i = 0;
            Visibility();
        }

        private void Subject_Click(object sender, EventArgs e)
        {
            logger = "Entered to Subject List Form";
            Log();
            SubjectList SL = new SubjectList();
            SL.ShowDialog();
            tb.Dock = DockStyle.None;
            RefreshControl();
            logger = "Entered to Admin Account Form";
            Log();
        }

        private void AdminAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger = "Exit Application";
            Log();
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

        private void logfile_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Go to Administrator Log?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                logger = "Entered to Administrator Log";
                Log();
                AdminLog AL = new AdminLog();
                AL.Need(username, name, permission, schoolyear);
                AL.Show();
                this.Hide();
            }
        }

        private void AdminAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Home_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.F1)
                MessageBox.Show("Alt + E = Log\nAlt + Left = Previous\nAlt + Right = Next\nDelete = Clear All Fields\nnEscape = Go to Main Menu\n" +
                    "Escape = Go to Main Menu\n\nWhen selecting subject/s:\n\nAlt + S = Go to Subject Form", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else if (TwoPanel.Visible == true && e.KeyCode == Keys.S && e.Modifiers == Keys.Alt)
                Subject_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.Delete)
                Clearbtn_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Alt)
                logfile_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.Left && e.Modifiers == Keys.Alt)
                Previous_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.Right && e.Modifiers == Keys.Alt)
                Next_Click(sender, EventArgs.Empty);
        }

        private void AdminAccount_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            status = "insert";
            Check();
            SubjectLoad();
            CBoxUpdate();
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            button = "prev";
            if (i == 0)
            {
                MessageBox.Show("First Page.");
                i = 0;
            }

            else
            {
                if (P.Text == "Professor")
                    i = i - 1;

                else if (P.Text != "Professor")
                    i = i - 2;
            }
            Visibility();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            button = "next";
            i = i + 1;
            Visibility();
        }

        private void ClearFields()
        {
            UncheckedSubject();
            i = 0;
            Nametxt.SelectedIndex = -1;
            LN.Text = "";
            FN.Text = "";
            MN.Text = "";
            UN.Text = "";
            Pass.Text = "";
            P.SelectedIndex = -1;
            status = "insert";
            UN.Enabled = true;
            Visibility();
        }

        private string Count()
        {
            connected = new MySqlConnection(con);
            connected.Open();
            cmd.CommandText = "select count(*) from administrator where username ='" + UN.Text + "'";
            cmd.Connection = connected;
            string count = cmd.ExecuteScalar().ToString();
            connected.Close();
            return count;
        }

        public void CheckedSubject()
        {
            subnum = 1;
            do
            {
                SubNotEmpty();

                foreach (Control ctrl in tb.Controls)
                {
                    if (ctrl is CheckBox)
                    {
                        CheckBox c = ctrl as CheckBox;
                        if (c.Text == sub)
                            c.Checked = true;
                    }
                }
            }
            while (sub != "");
        }

        public void UncheckedSubject()
        {
            foreach (Control ctrl in tb.Controls)
            {
                CheckBox c = ctrl as CheckBox;
                c.Checked = false;
            }
        }

        private void Visibility()
        {
            if (i == 0)
            {
                Previous.Enabled = true;
                OnePanel.Show();
                TwoPanel.Hide();
                FourPanel.Hide();
                Subject.Visible = false;
            }

            else if (i == 1)
            {
                if (LN.Text == "" || FN.Text == "" || P.Text == "")
                {
                    MessageBox.Show("Please answer all the fields.");
                    i = 0;
                }

                else if (LN.Text != "" || FN.Text != "" || P.Text != "")
                {
                    string firstname = FN.Text;
                    string lastname = LN.Text;

                    if (firstname.Substring(firstname.Length - 1) == "\\" || firstname.Substring(firstname.Length - 1) == "'"
                        || lastname.Substring(lastname.Length - 1) == "\\" || lastname.Substring(lastname.Length - 1) == "'")
                            MessageBox.Show("Quatation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else
                    {
                        if (P.Text == "Professor")
                        {
                            i = 1;
                            TwoPanel.Show();
                            OnePanel.Hide();
                            FourPanel.Hide();
                            Subject.Visible = true;

                            if (status == "update")
                            {
                                CheckedSubject();
                            }
                        }

                        else if (P.Text != "Professor")
                        {
                            if (button == "next")
                            {
                                FourPanel.Show();
                                OnePanel.Hide();
                                TwoPanel.Hide();
                                i = 2;
                            }

                            else if (button == "prev")
                            {
                                FourPanel.Hide();
                                TwoPanel.Hide();
                                OnePanel.Show();
                                i = 1;
                            }
                        }
                    }
                }
            }

            else if (i == 2)
            {
                if (P.Text == "Professor")
                {
                    Subject.Visible = false;
                    FourPanel.Show();
                    TwoPanel.Hide();
                    OnePanel.Hide();
                    i = 2;
                }
            }

            else if (i == 3)
            {
                if (UN.Text == "" || Pass.Text == "")
                {
                    MessageBox.Show("Please answer all the fields.");
                    i = 2;
                }

                else if (UN.Text != "" || Pass.Text != "")
                {
                    string username1 = UN.Text;
                    string password = Pass.Text;

                    if (username1.Substring(username1.Length - 1) == "\\" || username1.Substring(username1.Length - 1) == "'"
                        || password.Substring(password.Length - 1) == "\\" || password.Substring(password.Length - 1) == "'")
                            MessageBox.Show("Quatation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else
                    {
                        string count = Count();

                        if (count == "1")
                        {
                            if (status == "update")
                            {
                                uname = UN.Text.ToString();
                                Updated();
                                i = 0;
                                FourPanel.Hide();
                                TwoPanel.Hide();
                                OnePanel.Show();
                                ClearFields();
                            }

                            else if (status == "insert")
                            {
                                MessageBox.Show("Username already exist. Please use other username");
                                UN.Text = "";
                                i = 2;
                            }
                        }

                        else if (count == "0")
                        {
                            if (status == "insert")
                            {
                                uname = UN.Text.ToString();
                                Insert();
                                i = 0;
                                FourPanel.Hide();
                                TwoPanel.Hide();
                                OnePanel.Show();
                                ClearFields();
                            }
                        }
                    }
                }
            }
        }

        public AdminAccount()
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

        private void Xbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                this.Close();
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
    }
}