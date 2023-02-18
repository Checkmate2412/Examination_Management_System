using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DevExpress.XtraEditors;

namespace Student_Examination
{
    public partial class StudentInfo : DevExpress.XtraEditors.XtraForm
    {
        private string con;
        private MySqlConnection connected;
        MySqlCommand cmd = new MySqlCommand();
        TableLayoutPanel tb = new TableLayoutPanel();
        System.Windows.Forms.ComboBox cb = new System.Windows.Forms.ComboBox();
        string name, firstname, schoolyear, username, sub, count, logger, course, year, semester;
        int ii, id, numberofsubject, addtb;
        int savenum = 1;
        int loop = 0;
        int subnum = 1;

        private void Next_Click(object sender, EventArgs e)
        {
            ii++;
            Visibility();
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (ii == 0)
                ii = 0;

            else
                ii--;

            Visibility();
        }

        private void SchoolYearStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void SchoolYearEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
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
                logger = "Entered Main Menu Form";
                Log();
                Menu menu = new Menu();
                menu.Essentials(name, firstname, username, schoolyear);
                menu.Show();
                this.Hide();
            }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            Clocktxt.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void Visibility()
        {
            if (ii == 0)
            {
                Previous.Enabled = true;
                OnePanel.Show();
                TwoPanel.Hide();
                ThreePanel.Hide();
            }

            else if (ii == 1)
            {
                if (LN.Text == "" || SN.Text == "" || FN.Text == "" || MN.Text == "" || Gender.Text == ""
                     || Year.Text == "" || Section.Text == "" || Course.Text == "" || Semester.Text == "")
                {
                    MessageBox.Show("Please answer all the fields.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ii = 0;
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
                        TwoPanel.Show();
                        OnePanel.Hide();
                        ThreePanel.Hide();
                    }
                }
            }

            else if (ii == 2)
            {
                if (Password.Text == "" || SchoolYearEnd.Text == "" || SchoolYearStart.Text == "")
                {
                    ii = 1;
                    MessageBox.Show("Please enter values.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                else if (SchoolYearStart.Text != "" && SchoolYearEnd.Text != "" && UN.Text != "")
                {
                    username = UN.Text;
                    string password = Password.Text;

                    if (username.Substring(username.Length - 1) == "\\" || username.Substring(username.Length - 1) == "'"
                        || password.Substring(password.Length - 1) == "\\" || password.Substring(password.Length - 1) == "'")
                        MessageBox.Show("Quatation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else
                    {
                        int start = int.Parse(SchoolYearStart.Text);
                        int end = int.Parse(SchoolYearEnd.Text);
                        int endminus = end - 1;

                        if (SchoolYearEnd.Text.Length != 4 || SchoolYearEnd.Text.Length != 4)
                        {
                            ii = 1;
                            MessageBox.Show("The school year format is yyyy-yyyy. \n\nExample: 2012-2013", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else if ((SchoolYearEnd.Text.Length == 4 && SchoolYearEnd.Text.Length == 4) && start != endminus)
                        {
                            ii = 1;
                            MessageBox.Show("Please fix the school year.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else if ((SchoolYearEnd.Text.Length == 4 && SchoolYearEnd.Text.Length == 4) && start == endminus)
                        {
                            ThreePanel.Show();
                            TwoPanel.Hide();
                            OnePanel.Hide();


                            if (Stats.Text == "Regular")
                            {
                                if (Course.Text != course || Year.Text != year || Semester.Text != semester)
                                {
                                    DialogResult dialogResult = MessageBox.Show("You've changed one of this: Year, Course, Semester.\n\n" +
                                       "You want the system to automatically checked the subjects\nbase on your Year, Course and Semester?",
                                       "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        UncheckedSubject();
                                        CheckedSemesterSubject();
                                    }

                                    else if (dialogResult == DialogResult.No)
                                        CheckedSubject();
                                }

                                else if (Course.Text == course || Year.Text == year || Semester.Text == semester)
                                    CheckedSubject();
                            }

                            else if (Stats.Text == "Irregular")
                                UncheckedSubject();
                        }
                    }
                }
            }

            else if (ii == 3)
            {
                schoolyear = SchoolYearStart.Text + "-" + SchoolYearEnd.Text;
                try
                {
                    connected = new MySqlConnection(con);
                    connected.Open();
                    cmd.CommandText = "Update `student_info` set name = '" + LN.Text + ", " + FN.Text + " " + MN.Text + "', `lastname` = '"
                    + LN.Text + "', `firstname` = '" + FN.Text + "',  `middlename` = '" + MN.Text + "', `Gender` = '"
                    + Gender.Text + "', `Course` = '" + Course.Text + "', `Year` = '" + Year.Text + "', `Status` = '" + Stats.Text + "', `Section` = '"
                    + Section.Text + "', `studentnumber` = '" + SN.Text + "', `Password` = '" + Password.Text + "'" +
                    ", `Semester` = '" + Semester.Text + "', `schoolyearstart` = '" + SchoolYearStart.Text + "', `schoolyearend` = '" + SchoolYearEnd.Text + "' " +
                    "where `username` = '" + UN.Text + "'";
                    cmd.Connection = connected;
                    cmd.ExecuteNonQuery();
                    connected.Close();
                    InsertSubject();
                    MessageBox.Show("Updated", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnePanel.Show();
                    TwoPanel.Hide();
                    ThreePanel.Hide();
                    ii = 0;
                    logger = "Modified Student Information";
                    Log();
                }

                catch (Exception err)
                {
                    MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                MessageBox.Show("No recorded subjects in this semester. Please manually chose your subjects.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        public void Need(string Gname, string FName, string FUsername, string Fschoolyear)
        {
            name = Gname;
            firstname = FName;
            username = FUsername;
            schoolyear = Fschoolyear;
        }

        private void NameLoad()
        {
            try
            {
                connected = new MySqlConnection(con);
                cmd.CommandText = "select * from `student_info` where username = '" + username + "'";
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
                    Course.Text = dr["course"].ToString();
                    course = dr["course"].ToString();
                    year = dr["year"].ToString();
                    semester = dr["semester"].ToString();
                    Semester.Text = dr["semester"].ToString();
                    Stats.Text = dr["status"].ToString();
                    Section.Text = (dr["section"].ToString());
                    SchoolYearStart.Text = dr["schoolyearstart"].ToString();
                    SchoolYearEnd.Text = dr["schoolyearend"].ToString();
                    UN.Text = dr["username"].ToString();
                    Password.Text = (dr["password"].ToString());

                }
                connected.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ii = 0;
        }

        private void KP(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Numbers only.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void StudentInfo_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            Check();
            NameLoad();
            SubjectLoad();
            Visibility();
        }

        private void StudentInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger = "Exit Application";
            Log();
        }

        private void StudentInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Home_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.Left && e.Modifiers == Keys.Alt)
                Previous_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.Right && e.Modifiers == Keys.Alt)
                Next_Click(sender, EventArgs.Empty);

            if (e.KeyCode == Keys.F1)
                MessageBox.Show("Alt + Left = Previous\nAlt + Right = Next\nEscape = Go to Main Menu"
                    , "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Log()
        {
            try
            {
                connected.Open();
                cmd.Connection = connected;
                cmd.CommandText = "INSERT INTO `student_log` (`name`, `username`, `Time`, `Remarks`) " +
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
                Deletion();

            connected.Open();
            cmd.CommandText = "Update student_info set `numberofsubject` = '" + loop + "' where username = '" + UN.Text + "'";
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

        public void Updated(string checkText)
        {
            connected.Open();
            cmd.CommandText = "Update student_info set `Subject" + savenum + "` = '" + checkText + "', `numberofsubject` = '" + numberofsubject + "'" +
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
            cb.Items.Clear();

            if (Ans != 0)
                s++;

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
                CheckBox box = new CheckBox
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.Transparent,
                    AutoSize = true,

                    Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold),
                    ForeColor = Color.White,
                    Text = cb.GetItemText(cb.Items[addtb]),
                    Name = addtb.ToString()
                };
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
    }
}