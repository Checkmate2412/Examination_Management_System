using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Lan_Based_Examination
{
    public partial class StudentInfo : DevExpress.XtraEditors.XtraForm
    {
        private string con;
        private MySqlConnection connected;
        MySqlCommand cmd = new MySqlCommand();
        TableLayoutPanel tb = new TableLayoutPanel();
        ComboBox cb = new ComboBox();
        int i = 0, id, numberofsubject, addtb, flag = 0, savenum = 1, loop = 0, subnum = 1;
        string sub, permission, name, status, schoolyear, username, count, sem, year, course, logger;

        private void Xbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                this.Close();
        }

        public StudentInfo()
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

        public void Need(string un, string Gname, string perm, string sy)
        {
            username = un;
            permission = perm;
            name = Gname;
            schoolyear = sy;
        }

        private void RefreshControl()
        {
            tb.Controls.Clear();
            Check();
            SubjectLoad();
            CheckedSubject();
        }

        private string Count()
        {
            connected = new MySqlConnection(con);
            connected.Open();
            cmd.CommandText = "select count(*) from `student_info` where username ='" + UN.Text + "'";
            cmd.Connection = connected;
            string count = cmd.ExecuteScalar().ToString();
            connected.Close();
            return count;
        }

        private void SchoolYearEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void SchoolYearStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void Next_Click(object sender, EventArgs e)
        {
            i = i + 1;
            Visibility();
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            Subject.Visible = false;

            if (i == 0)
                i = 0;

            else
                i = i - 1;

            Visibility();
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

        private void Subject_Click(object sender, EventArgs e)
        {
            logger = "Entered to Subject List Form";
            Log();
            i = 2;
            SubjectList SL = new SubjectList();
            SL.ShowDialog();
            tb.Dock = DockStyle.None;
            RefreshControl();
            logger = "Entered to Student Account Form";
            Log();
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Nametxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            status = "update";
            UN.Enabled = false;
            try
            {
                connected = new MySqlConnection(con);
                cmd.CommandText = "select * from `student_info` where name = '" + Nametxt.Text + "'";
                cmd.Connection = connected;
                connected.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    SN.Text = dr["studentnumber"].ToString();
                    LN.Text = dr["lastname"].ToString();
                    FN.Text = dr["firstname"].ToString();
                    MN.Text = (dr["middlename"].ToString());
                    Gender.Text = dr["gender"].ToString();
                    Year.Text = dr["year"].ToString();
                    year = dr["year"].ToString();
                    course = dr["course"].ToString();
                    sem = dr["semester"].ToString();
                    Course.Text = dr["course"].ToString();
                    Stats.Text = dr["status"].ToString();
                    Section.Text = (dr["section"].ToString());
                    Semester.Text = (dr["semester"].ToString());
                    UN.Text = dr["username"].ToString();
                    Password.Text = (dr["password"].ToString());
                    SchoolYearStart.Text = dr["SchoolYearStart"].ToString();
                    SchoolYearEnd.Text = (dr["SchoolYearend"].ToString());
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            Clocktxt.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void StudentInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger = "Exit Application";
            Log();
        }

        private void logfile_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Go to Student Log?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                logger = "Entered to Administrator Log";
                Log();
                StudentLog SL = new StudentLog();
                SL.Need(username, name, permission, schoolyear);
                SL.Show();
                this.Hide();
            }
        }

        private void StudentInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Home_Click(sender, EventArgs.Empty);

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

            if (e.KeyCode == Keys.F1)
            {
                if (logfile.Visible == true)
                    MessageBox.Show("Alt + E = Log\nAlt + Left = Previous\nAlt + Right = Next\nDelete = Clear All Fields\nEscape = Go to Main Menu\n\nWhen selecting subject/s:" +
                        "\n\nAlt + S = Go to Subject Form", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else if (logfile.Visible == false)
                    MessageBox.Show("Alt + Left = Previous\nAlt + Right = Next\nEscape = Go to Main Menu\nDelete = Clear All Fields\n\nWhen selecting subject/s:" +
                        "\n\nAlt + S = Go to Subject Form", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void StudentInfo_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            status = "insert";
            Check();
            SubjectLoad();
            CBoxUpdate();
        }

        private void Visibility()
        {
            if (i == 0)
            {
                Previous.Enabled = true;
                OnePanel.Show();
                TwoPanel.Hide();
                ThreePanel.Hide();
            }

            else if (i == 1)
            {
                if (LN.Text == "" || SN.Text == "" || FN.Text == "" || Gender.Text == "" || Stats.Text == ""
                     || Year.Text == "" || Section.Text == "" || Course.Text == "" || Semester.Text == "")
                {
                    MessageBox.Show("Please answer all the fields.");
                    i = 0;
                }

                else
                {
                    string lastname = LN.Text;
                    string studnum = SN.Text;
                    string firstname = FN.Text;
                    string middlename = MN.Text;

                    if (lastname.Substring(lastname.Length - 1) == "\\" || lastname.Substring(lastname.Length - 1) == "'"
                        || studnum.Substring(studnum.Length - 1) == "\\" || studnum.Substring(studnum.Length - 1) == "'"
                        || firstname.Substring(firstname.Length - 1) == "\\" || firstname.Substring(firstname.Length - 1) == "'"
                        || middlename.Substring(middlename.Length - 1) == "\\" || middlename.Substring(middlename.Length - 1) == "'")
                            MessageBox.Show("Quatation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else
                    {
                        if (status == "insert")
                            flag = 0;

                        else if (status == "update")
                        {
                            if (Course.Text != course || Year.Text != year || Semester.Text != sem)
                                flag = 1;

                            else if (Course.Text == course || Year.Text == year || Semester.Text == sem)
                                flag = 0;
                        }

                        TwoPanel.Show();
                        OnePanel.Hide();
                        ThreePanel.Hide();
                    }
                }
            }

            else if (i == 2)
            {

                string count = Count();

                if (status == "insert")
                {
                    if (count == "1")
                    {
                        MessageBox.Show("Username already exist. Please use other username");
                        UN.Text = "";
                        i = 1;
                    }

                    else if (count == "0")
                    {
                        if (UN.Text == "" || Password.Text == "" || SchoolYearStart.Text == "" || SchoolYearEnd.Text == "")
                        {
                            i = 1;
                            MessageBox.Show("Please enter values.");
                        }

                        else if (SchoolYearStart.Text != "" && SchoolYearEnd.Text != "" && UN.Text != "")
                        {
                            string username1 = UN.Text;
                            string password = Password.Text;

                            if (username1.Substring(username1.Length - 1) == "\\" || username1.Substring(username1.Length - 1) == "'"
                                || password.Substring(password.Length - 1) == "\\" || password.Substring(password.Length - 1) == "'")
                                    MessageBox.Show("Quatation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            else
                            {
                                int start = int.Parse(SchoolYearStart.Text);
                                int end = int.Parse(SchoolYearEnd.Text);
                                int endminus = end - 1;

                                if (SchoolYearEnd.Text.Length != 4 || SchoolYearEnd.Text.Length != 4)
                                {
                                    i = 1;
                                    MessageBox.Show("The school year format is yyyy-yyyy. \n\nExample: 2012-2013");
                                }

                                else if ((SchoolYearEnd.Text.Length == 4 && SchoolYearEnd.Text.Length == 4) && start != endminus)
                                {
                                    i = 1;
                                    MessageBox.Show("Please fix the school year.");
                                }

                                else if ((SchoolYearEnd.Text.Length == 4 && SchoolYearEnd.Text.Length == 4) && start == endminus)
                                {
                                    i = 2;
                                    ThreePanel.Show();
                                    TwoPanel.Hide();
                                    OnePanel.Hide();
                                    FillSubjects();
                                }
                            }
                        }
                    }
                }

                else if (status == "update")
                {
                    if (count == "1")
                    {
                        if (Password.Text == "" || SchoolYearEnd.Text == "" || SchoolYearStart.Text == "")
                        {
                            i = 1;
                            MessageBox.Show("Please enter values.");
                        }

                        else if (SchoolYearStart.Text != "" && SchoolYearEnd.Text != "" && Password.Text != "")
                        {
                            string password = Password.Text;

                            if (password.Substring(password.Length - 1) == "\\" || password.Substring(password.Length - 1) == "'")
                                MessageBox.Show("Quatation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            else
                            {
                                int start = int.Parse(SchoolYearStart.Text);
                                int end = int.Parse(SchoolYearEnd.Text);
                                int endminus = end - 1;

                                if (SchoolYearEnd.Text.Length != 4 || SchoolYearEnd.Text.Length != 4)
                                {
                                    i = 1;
                                    MessageBox.Show("The school year format is yyyy-yyyy. \n\nExample: 2012-2013");
                                }

                                else if ((SchoolYearEnd.Text.Length == 4 && SchoolYearEnd.Text.Length == 4) && start != endminus)
                                {
                                    i = 1;
                                    MessageBox.Show("Please fix the school year.");
                                }

                                else if ((SchoolYearEnd.Text.Length == 4 && SchoolYearEnd.Text.Length == 4) && start == endminus)
                                {
                                    i = 2;
                                    ThreePanel.Show();
                                    TwoPanel.Hide();
                                    OnePanel.Hide();
                                    FillSubjects();
                                    Subject.Visible = true;
                                }
                            }
                        }
                    }
                }
            }

            else if (i == 3)
            {
                try
                {
                    connected = new MySqlConnection(con);
                    if (status == "insert")
                    {
                        connected.Open();
                        cmd.CommandText = "INSERT INTO `student_info` (`studentnumber`, `lastname`, `firstname`," +
                        "`middlename`, `name`, `Gender`, `Course`, `Year`, `Section`, `Semester`, `Username`, `Password`, " +
                        "`schoolyearstart`, `schoolyearend`, `status`) VALUES('" + SN.Text + "', '" + LN.Text + "',  '" +
                        FN.Text + "', '" + MN.Text + "','" + LN.Text + ", " + FN.Text + " " + MN.Text + "','" +
                        Gender.Text + "','" + Course.Text + "','" + Year.Text + "','" + Section.Text + "','" + Semester.Text + "','" +
                        UN.Text + "','" + Password.Text + "','" + SchoolYearStart.Text + "','" + SchoolYearEnd.Text + "', '" + Stats.Text + "')";
                        cmd.Connection = connected;
                        cmd.ExecuteNonQuery();
                        connected.Close();
                        InsertSubject();
                        MessageBox.Show("Saved");
                        OnePanel.Show();
                        ThreePanel.Hide();
                        TwoPanel.Hide();
                        logger = "Inserted a student account: " + UN.Text + "";
                        Log();
                    }

                    else if (status == "update")
                    {
                        connected.Open();
                        cmd.CommandText = "Update `student_info` set `studentnumber` = '" + SN.Text + "', `lastname` = '"
                        + LN.Text + "', `firstname` = '" + FN.Text + "',  `middlename` = '" + MN.Text + "', `Gender` = '"
                        + Gender.Text + "', `Course` = '" + Course.Text + "', `Semester` = '" + Semester.Text + "'," +
                        "`Year` = '" + Year.Text + "', `Section` = '" + Section.Text + "', `Username` = '" + UN.Text + "'" +
                        ", `Password` = '" + Password.Text + "', `schoolyearstart` = '" + SchoolYearStart.Text + "', " +
                        "`schoolyearstart` = '" + SchoolYearStart.Text + "', `Status` = '" + Stats.Text + "'" +
                        " where name = '" + LN.Text + ", " + FN.Text + " " + MN.Text + "'";
                        cmd.Connection = connected;
                        cmd.ExecuteNonQuery();
                        connected.Close();
                        InsertSubject();
                        MessageBox.Show("Updated");
                        OnePanel.Show();
                        ThreePanel.Hide();
                        TwoPanel.Hide();
                        logger = "Modified a student account: " + UN.Text + "";
                        Log();
                    }
                    i = 0;
                    Clear();
                    CBoxUpdate();
                    Subject.Visible = false;
                }

                catch (Exception err)
                {
                    MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void CheckedSemesterSubject()
        {
            cb.Items.Clear();

            try
            {
                cmd.CommandText = "select * from `Semester_Subjects` where `Course` = '" + Course.Text +
                        "' && `Year` = '" + Year.Text + "' && `Semester` = '" + Semester.Text + "'";
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

            if (cb.Items.Count == 0)
                MessageBox.Show("No recorded subjects in this semester. Please manually chose your subjects.");

            else if (cb.Items.Count != 0)
            {
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

        private void FillSubjects()
        {
            try
            {
                int countsub = 0;
                connected = new MySqlConnection(con);
                connected.Open();
                cmd.CommandText = "select count(*) from information_schema.tables where table_name='Semester_Subjects' AND TABLE_SCHEMA='examination'";
                cmd.Connection = connected;
                string count = cmd.ExecuteScalar().ToString();
                connected.Close();

                if (count == "0")
                {
                    foreach (Control ctrl in tb.Controls)
                    {
                        if (ctrl is CheckBox)
                        {
                            CheckBox c = ctrl as CheckBox;
                            if (c.Checked == true)
                                countsub++;
                        }
                    }

                    if (countsub == 0)
                        MessageBox.Show("No recorded subjects in this semester. Please manually chose your subjects.");
                }

                else if (count == "1")
                {
                    if (Stats.Text == "Regular")
                    {
                        if (flag == 1)
                        {
                            DialogResult dialogResult = MessageBox.Show("You've changed one of this: Year, Course, Semester.\n\n" +
                                "You want the system to automatically checked the subjects\nbase on your Year, Course and Semester?", 
                                "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (dialogResult == DialogResult.Yes)
                            {
                                UncheckedSubject();
                                CheckedSemesterSubject();
                            }

                            else
                                CheckedSubject();
                        }

                        else if (flag == 0)
                        {
                            UncheckedSubject();
                            CheckedSemesterSubject();
                        }
                    }

                    else if (Stats.Text == "Irregular")
                        UncheckedSubject();
                }
            }

            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int ColumnFind(int number)
        {
            cmd.CommandText = "select count(*) from information_schema.columns where TABLE_SCHEMA = 'examination' AND " +
               "table_name = 'student_info' AND COLUMN_NAME = 'Subject" + number + "'";
            connected.Open();
            cmd.Connection = connected;
            string countstr = cmd.ExecuteScalar().ToString();
            int count = Int32.Parse(countstr);
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
                if (ctrl is CheckBox)
                {
                    CheckBox c = ctrl as CheckBox;
                    if (c.Checked == true)
                        c.Checked = false;
                }
            }
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
                        if (checkText != "")
                        {
                            loop++;
                            Save(checkText);
                        }
                    }
                }
            }

            if (numberofsubject > loop)
            {
                Deletion();
            }

            connected.Open();
            cmd.CommandText = "Update `student_info` set `numberofsubject` = '" + loop + "' where username = '" + UN.Text + "'";
            cmd.Connection = connected;
            cmd.ExecuteNonQuery();
            connected.Close();
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
                    cmd.CommandText = "select * from `student_info` where username = '" + UN.Text + "'";
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
                    cmd.CommandText = "ALTER TABLE `student_info` ADD `Subject" + savenum + "` VARCHAR(99) NOT NULL;";
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

        private void KP(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Numbers only.");
            }
        }

        public void Updated(string checkText)
        {
            connected.Open();
            cmd.CommandText = "Update `student_info` set `Subject" + savenum + "` = '" + checkText + "', `numberofsubject` = '" + numberofsubject + "'" +
                " where username = '" + UN.Text + "'";
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
                    cmd.CommandText = "update `student_info` set `Subject" + delnum + "` = '' where `username` = '" + UN.Text + "'";
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

        private void Clear()
        {
            course = "";
            year = "";
            sem = "";
            cb.Items.Clear();
            flag = 0;
            UncheckedSubject();
            Subject.Visible = false;
            Semester.Text = "";
            i = 0;
            SchoolYearStart.Text = "";
            SchoolYearEnd.Text = "";
            Nametxt.SelectedIndex = -1;
            SN.Text = "";
            LN.Text = "";
            FN.Text = "";
            MN.Text = "";
            Gender.SelectedIndex = -1;
            Year.SelectedIndex = -1;
            Course.SelectedIndex = -1;
            Section.SelectedIndex = -1;
            Stats.SelectedIndex = -1;
            Semester.SelectedIndex = -1;
            UN.Text = "";
            Password.Text = "";
            status = "insert";
            UN.Enabled = true;
            Visibility();
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

        private void CBoxUpdate()
        {
            Nametxt.Properties.Items.Clear();
            connected = new MySqlConnection(con);
            cmd.CommandText = "select * from `student_info`";
            cmd.Connection = connected;
            connected.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Nametxt.Properties.Items.Add(dr["name"].ToString());
            }

            connected.Close();
        }
    }
}