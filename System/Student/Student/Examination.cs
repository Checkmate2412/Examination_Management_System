using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;

namespace Student_Examination.Properties
{
    public partial class Examination : XtraForm
    {
        private string con;
        private MySqlConnection connected;
        MySqlCommand cmd = new MySqlCommand();
        TableLayoutPanel tb = new TableLayoutPanel();
        System.Windows.Forms.ComboBox cb = new System.Windows.Forms.ComboBox();
        DateTime End;
        string questions, a, b, c, d, answer, sub, examtype, exam, item2, ans, button, name, gender, course, logger,
        section, schoolyear, proctorby, firstname, prevans, username, profname, text, enuma, enumb, enumc, enumd, enume, 
        fix, done = "Yes";

        private void Examination_KeyDown(object sender, KeyEventArgs e)
        {
            if (Starter.Visible == true)
            {
                if (e.KeyCode == Keys.Enter)
                    Code_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.F1)
                    MessageBox.Show("Enter or Alt + E = Enter\nEscape = Go to Take Exam", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else if (e.KeyCode == Keys.Enter)
                    Home_Click(sender, EventArgs.Empty);
            }

            else if (ProfPanel.Visible == true)
            {
                if (e.KeyCode == Keys.Enter)
                    Done_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.F1)
                    MessageBox.Show("Enter or Alt + D = Done", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (ProfPanel.Visible == false && Starter.Visible == false)
            {
                if (e.KeyCode == Keys.Left && e.Modifiers == Keys.Alt)
                    Previous_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.Right && e.Modifiers == Keys.Alt)
                    Next_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.F1)
                    MessageBox.Show("Alt + Right Arrow = Save/Update/Next\nAlt + Left Arrow = Previous" +
                        "\n\nNote: You can't close the application until you finish taking " +
                        "the examination.\n\nAnother note: You can't switch to another software. " +
                        "No Alt + Tab or Alt + Tab + Shift", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Examination_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
        }

        int points, totalpoints, id = 1, i = 1, iddb, firstnumberdb, lastnumberdb, totalitems, year, pointsdb,
        counternumberofsubject, loopcounter;

        private void Examination_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger = "Exit Application";
            Log();
        }

        private void TITrue_CheckedChanged(object sender, EventArgs e)
        {
            if (TITrue.Checked == true)
            {
                TIFalse.Enabled = false;
                TIFalse.Text = "";
            }

            else if (TITrue.Checked == false)
                TIFalse.Enabled = true;
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

        private void Done_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in tb.Controls)
            {
                if (ctrl is RadioButton)
                {
                    RadioButton c = ctrl as RadioButton;

                    if (c.Checked == true)
                    {
                        text = c.Text.ToString();
                        profname = text;
                        DonePanel.Visible = false;
                        ProfPanel.Visible = false;
                        Loading();
                    }
                }
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (examtype == "Multiple Choice")
            {
                if (AAnsMC.Checked == false && BAnsMC.Checked == false && CAnsMC.Checked == false && DAnsMC.Checked == false)
                    MessageBox.Show("Choose an answer.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else if (AAnsMC.Checked == true || BAnsMC.Checked == true || CAnsMC.Checked == true || DAnsMC.Checked == true)
                {
                    button = "next";
                    Score();
                    id++;
                    Display();
                    DisplayAnswer();
                }

            }

            else if (examtype == "True/False")
            {
                if (TFTrue.Checked == false && TFFalse.Checked == false)
                    MessageBox.Show("Choose an answer.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else if (TFTrue.Checked == true || TFFalse.Checked == true)
                {
                    button = "next";
                    Score();
                    id++;
                    Display();
                    DisplayAnswer();
                }
            }

            else if (examtype == "True/Identify")
            {
                string TIAns = TIFalse.Text;

                if (TITrue.Checked == false && TIAns == "")
                    MessageBox.Show("Choose/Type your answer.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else if (TITrue.Checked == false && TIFalse.Enabled == true && TIAns == "")
                    MessageBox.Show("Type your answer.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else
                {
                    if (TITrue.Checked == false && TIAns != "")
                    {
                        if (TIAns.Substring(TIAns.Length - 1) == "\\" || TIAns.Substring(TIAns.Length - 1) == "'")
                            MessageBox.Show("Quatation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        else
                        {
                            button = "next";
                            Score();
                            id++;
                            Display();
                            DisplayAnswer();
                        }
                    }

                    if (TITrue.Checked == true && TIAns == "")
                    {
                        button = "next";
                        Score();
                        id++;
                        Display();
                        DisplayAnswer();
                    }
                }
            }

            else if (examtype == "Identification")
            {
                string IAns = AnswerIdent.Text;

                if (IAns == "")
                {
                    MessageBox.Show("Type your answer.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else if (IAns!= "")
                {
                    if (IAns.Substring(IAns.Length - 1) == "\\" || IAns.Substring(IAns.Length - 1) == "'")
                        MessageBox.Show("Quatation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else
                    {
                        button = "next";
                        Score();
                        id++;
                        Display();
                        DisplayAnswer();
                    }
                }
            }

            else if (examtype == "Essay")
            {
                string EA = AnswerEssay.Text;

                if (EA == "")
                    MessageBox.Show("Type your answer.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else if (EA != "")
                {
                    if (EA.Substring(EA.Length - 1) == "\\" || EA.Substring(EA.Length - 1) == "'")
                        MessageBox.Show("Quatation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else if (AnswerEssay.Text != "")
                    {
                        button = "next";
                        Score();
                        id++;
                        Display();
                        DisplayAnswer();
                    }
                }
            }

            else if (examtype == "Enumeration")
            {
                string EA = EnumA.Text;
                string EB = EnumB.Text;
                string EC = EnumC.Text;
                string ED = EnumD.Text;
                string EE = EnumE.Text;

                if (EA == "" || EB == "" || EC == "" || ED == "" || EE == "")
                    MessageBox.Show("Please fill up all the fields.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (EA != "" || EB != "" || EC != "" || ED != "" || EE != "")
                {
                    if (EA.Substring(EA.Length - 1) == "\\" || EA.Substring(EA.Length - 1) == "'"
                    || EB.Substring(EB.Length - 1) == "\\" || EB.Substring(EB.Length - 1) == "'"
                    || EC.Substring(EC.Length - 1) == "\\" || EC.Substring(EC.Length - 1) == "'"
                    || ED.Substring(ED.Length - 1) == "\\" || ED.Substring(ED.Length - 1) == "'"
                    || EE.Substring(EE.Length - 1) == "\\" || EE.Substring(EE.Length - 1) == "'")
                        MessageBox.Show("Quatation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else
                    {
                        button = "next";
                        Score();
                        id++;
                        Display();
                        DisplayAnswer();
                    }
                }
            }
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (totalpoints == 0)
                totalpoints = 0;

            if (id == 1)
            {
                MessageBox.Show("You reach the first question", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                totalpoints = 0;
                id = 1;
            }

            else
            {
                button = "prev";
                id--;
                AAnsMC.Checked = false;
                BAnsMC.Checked = false;
                CAnsMC.Checked = false;
                DAnsMC.Checked = false;
                TITrue.Checked = false;
                TIFalse.Text = "";
                TFTrue.Checked = true;
                TFFalse.Checked = false;
                AnswerIdent.Text = "";
                AnswerEssay.Text = "";
                Score();
                Display();
                DisplayAnswer();
            }
        }

        private void Examination_FormClosing(object sender, FormClosingEventArgs e)
        {
            logger = "Trying to exit the application.";
            Log();
            e.Cancel = true;
        }

        private void Home_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Back?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                logger = "Entered Take Exam Form";
                Log();
                Exam exam = new Exam();
                exam.Need(name, firstname, username, schoolyear);
                exam.Show();
                this.Hide();
            }
        }

        public Examination()
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

        private void MI()
        {
            MultipleScoreTI.Show();
            MultipleScoreMC.Show();
            MultipleScoreTF.Show();
            MultipleScoreIdent.Show();
            MultipleScoreEssay.Show();
            MultipleScoreEnum.Show();
            SingleScoreEnum.Hide();
            SingleScoreMC.Hide();
            SingleScoreTF.Hide();
            SingleScoreTI.Hide();
            SingleScoreIdent.Hide();
            SingleScoreEssay.Hide();
        }

        private void SI()
        {
            MultipleScoreTI.Hide();
            MultipleScoreMC.Hide();
            MultipleScoreTF.Hide();
            MultipleScoreIdent.Hide();
            MultipleScoreEssay.Hide();
            MultipleScoreEnum.Hide();
            SingleScoreEnum.Show();
            SingleScoreMC.Show();
            SingleScoreTF.Show();
            SingleScoreTI.Show();
            SingleScoreIdent.Show();
            SingleScoreEssay.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Clocktxt.Text = DateTime.Now.ToString("hh:mm:ss tt");
            DateTime Now = DateTime.Now;

            if (Now > End)
            {
                Display();
                timer1.Stop();
                MessageBox.Show("Time's Up.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Exam exam = new Exam();
                exam.Need(name, firstname, username, schoolyear);
                exam.Show();
                this.Hide();
            }
        }

        private void Code_Click(object sender, EventArgs e)
        {
            try
            {
                connected = new MySqlConnection(con);
                connected.Open();
                cmd.CommandText = "select count(*) from `administrator` where Key_Code ='" + SC.Text + "'";
                cmd.Connection = connected;
                string count = cmd.ExecuteScalar().ToString();
                connected.Close();

                if (count == "0")
                {
                    logger = "Wrong Code.";
                    Log();
                    MessageBox.Show("Invalid Code.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else if (count == "1")
                {
                    connected = new MySqlConnection(con);
                    cmd.CommandText = "select * from `administrator` where key_code = '" + SC.Text + "'";
                    cmd.Connection = connected;
                    connected.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        proctorby = (dr["name"].ToString());
                    }

                    connected.Close();
                    MessageBox.Show("Your Proctor: " + proctorby, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    connected.Open();
                    cmd.CommandText = "select max(`NumberOfSubject`) FROM administrator";
                    cmd.Connection = connected;
                    string count1 = cmd.ExecuteScalar().ToString();
                    counternumberofsubject = int.Parse(count1);
                    connected.Close();

                    for (loopcounter = 1; loopcounter <= counternumberofsubject; loopcounter++)
                    {
                        connected.Open();
                        cmd.CommandText = "select * from `administrator` where `Subject" + loopcounter.ToString() + "` = '" + sub + "'";
                        cmd.Connection = connected;
                        MySqlDataReader dr1 = cmd.ExecuteReader();

                        while (dr1.Read())
                        {
                            cb.Items.Add(dr1["name"].ToString());
                        }
                        connected.Close();
                    }

                    logger = "Correct Code.";
                    Log();
                    cb.Sorted = true;
                    tableLayoutPanel2.Visible = false;

                    if (cb.Items.Count == 1)
                    {
                        Starter.Visible = false;
                        profname = cb.GetItemText(cb.Items[0]);
                        Loading();
                    }

                    else 
                    {
                        int Ans = loopcounter % 2;
                        int s = loopcounter / 2;

                        if (Ans != 0)
                            s++;

                        if (s == 1)
                        {
                            tb.Dock = DockStyle.None;
                            tb.Location = new Point(1, panel5.Height / 3);
                            tb.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                            tb.Height = panel18.Height / 3;
                            tb.Width = panel18.Width;
                        }

                        else if (s == 2 || s == 3)
                        {
                            tb.Dock = DockStyle.None;
                            tb.Location = new Point(1, panel5.Height / (s * 2));
                            tb.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                            tb.Height = panel18.Height / s;
                            tb.Width = panel18.Width;
                        }

                        else
                            tb.Dock = DockStyle.Fill;

                        tb.ColumnCount = 2;
                        tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                        tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                        tb.RowCount = s;

                        for (int row = 0; row < s; row++)
                            tb.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));

                        int columncount = 0, rowcount = 0;

                        for (int addtb = 0; addtb < cb.Items.Count; addtb++)
                        {
                            RadioButton box = new RadioButton
                            {
                                Dock = DockStyle.Fill,
                                AutoSize = true,

                                Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold),
                                ForeColor = Color.White,
                                Text = cb.GetItemText(cb.Items[addtb]),
                                Name = addtb.ToString()
                            };

                            tb.AutoScroll = true;
                            tb.AutoSize = true;

                            tb.Controls.Add(box, columncount, rowcount);

                            if (columncount != 2)
                                columncount++;

                            else if (columncount == 2)
                            {
                                rowcount++;
                                columncount = 0;
                            }
                        }

                        tb.BackColor = Color.Transparent;
                        tb.Name = "tbsub";
                        panel18.Controls.Add(tb);
                        ProfPanel.Visible = true;
                        Starter.Visible = false;
                        DonePanel.Visible = true;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Display()
        {
            try
            {
                connected = new MySqlConnection(con);
                cmd.Connection = connected;
                cmd.CommandText = "select * from `" + exam.Replace("-", "") + "_" + sub.Replace(" ", "") + "_" + schoolyear + "` where id = '" + id + "'";
                cmd.Connection = connected;
                connected.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    firstnumberdb = (Int32.Parse(dr["number"].ToString()));
                    lastnumberdb = (Int32.Parse(dr["lastnumber"].ToString()));
                    questions = (dr["questions"].ToString());
                    a = (dr["a"].ToString());
                    b = (dr["b"].ToString());
                    c = (dr["c"].ToString());
                    d = (dr["d"].ToString());
                    enuma = (dr["enumerationa"].ToString());
                    enumb = (dr["enumerationb"].ToString());
                    enumc = (dr["enumerationc"].ToString());
                    enumd = (dr["enumerationd"].ToString());
                    enume = (dr["enumeratione"].ToString());
                    fix = (dr["fixenumeration"].ToString());
                    examtype = (dr["questiontype"].ToString());
                    points = (Int32.Parse(dr["points"].ToString()));
                    totalitems = (Int32.Parse(dr["totalitems"].ToString()));
                    answer = (dr["answer"].ToString());
                    item2 = (dr["itemtype"].ToString());
                }
            }

            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            HideShow();
            connected.Close();

            if (examtype == "Multiple Choice")
            {
                QuestionMC.Text = questions;
                AMC.Text = a;
                BMC.Text = b;
                CMC.Text = c;
                DMC.Text = d;

                if (item2 == "Multiple Score")
                {
                    MinItemMC.Text = firstnumberdb.ToString();
                    MaxItemMC.Text = lastnumberdb.ToString();
                    MI();
                }

                else if (item2 == "Single Score")
                {
                    ScoreMC.Text = firstnumberdb.ToString();
                    SI();
                }

            }

            else if (examtype == "True/False")
            {
                QuestionTF.Text = questions;

                if (item2 == "Multiple Score")
                {
                    MinItemTF.Text = firstnumberdb.ToString();
                    MaxItemTF.Text = lastnumberdb.ToString();
                    MI();
                }

                else if (item2 == "Single Score")
                {
                    ScoreTF.Text = firstnumberdb.ToString();
                    SI();
                }
            }

            else if (examtype == "True/Identify")
            {
                QuestionTI.Text = questions;

                if (item2 == "Multiple Score")
                {
                    MinItemTI.Text = firstnumberdb.ToString();
                    MaxItemTI.Text = lastnumberdb.ToString();
                    MI();
                }

                else if (item2 == "Single Score")
                {
                    ScoreTI.Text = firstnumberdb.ToString();
                    SI();
                }
            }

            else if (examtype == "Identification")
            {
                QuestionIdent.Text = questions;

                if (item2 == "Multiple Score")
                {
                    MinItemIdent.Text = firstnumberdb.ToString();
                    MaxItemIdent.Text = lastnumberdb.ToString();
                    MI();
                }

                else if (item2 == "Single Score")
                {
                    ScoreIdent.Text = firstnumberdb.ToString();
                    SI();
                }
            }

            else if (examtype == "Essay")
            {
                QuestionEssay.Text = questions;

                if (item2 == "Multiple Score")
                {
                    MinItemEssay.Text = firstnumberdb.ToString();
                    MaxItemEssay.Text = lastnumberdb.ToString();
                    MI();
                }

                else if (item2 == "Single Score")
                {
                    ScoreEssay.Text = firstnumberdb.ToString();
                    SI();
                }

                done = "No";
            }

            else if (examtype == "Enumeration")
            {
                QuestionEnum.Text = questions;

                if (item2 == "Multiple Score")
                {
                    MinItemEnum.Text = firstnumberdb.ToString();
                    MaxItemEnum.Text = lastnumberdb.ToString();
                    MI();
                }

                else if (item2 == "Single Score")
                {
                    ScoreEnum.Text = firstnumberdb.ToString();
                    SI();
                }
            }
        }

        private void Finish()
        {
            if (id > iddb)
            {
                connected = new MySqlConnection(con);
                connected.Open();
                cmd.CommandText = "select count(*) from information_schema.columns where TABLE_SCHEMA = 'examination' AND " +
                "table_name = 'result_" + exam.Replace("-", "") + "_" + Subtxt.Text.Replace(" ", "") + "_" + schoolyear + "' AND COLUMN_NAME = 'Done'";
                cmd.Connection = connected;
                string count = cmd.ExecuteScalar().ToString();
                connected.Close();

                if (count == "0")
                {
                    connected.Open();
                    cmd.CommandText = "ALTER TABLE `result_" + exam.Replace("-", "") + "_" + Subtxt.Text.Replace(" ", "") + "_" + schoolyear + "` ADD `Done` VARCHAR(3) " +
                            "NOT NULL;";
                    cmd.Connection = connected;
                    cmd.ExecuteReader();
                    connected.Close();
                }

                connected.Open();
                cmd.Connection = connected;
                cmd.CommandText = "Update `result_" + exam.Replace("-", "") + "_" + sub.Replace(" ", "") + "_" + schoolyear + "` " +
                    "set `Done` = '" + done + "' where username = '" + username + "'";
                cmd.Connection = connected;
                cmd.ExecuteReader();
                connected.Close();

                MessageBox.Show("Examination Complete.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                logger = "Finish taking the " + exam + " Examination of " + sub + ", " + schoolyear + ".";
                Log();
                DialogResult dialogResult = MessageBox.Show("Review Your Answer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.No)
                {
                    logger = "Entered Schedule Form";
                    Log();
                    Exam exam = new Exam();
                    exam.Need(name, firstname, username, schoolyear);
                    exam.Show();
                    this.Hide();
                }

                else if (dialogResult == DialogResult.Yes)
                {
                    logger = "Reviewing the answers of the " + exam + " Examination of " + sub + ", " + schoolyear + ".";
                    Log();
                    id = 1;
                    totalpoints = 0;
                    Display();
                    DisplayAnswer();
                }

            }
        }

        private void Last()
        {
            cmd.CommandText = "select id from `" + exam.Replace("-", "") + "_" + sub.Replace(" ", "") + "_" + schoolyear +
                "` order by id desc limit 1"; ;
            cmd.Connection = connected;
            connected.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                iddb = (Int32.Parse(dr["id"].ToString()));
            }
            connected.Close();
        }

        private void HideShow()
        {
            Essay.Hide();
            Identification.Hide();
            TrueIdentify.Hide();
            MultipleChoice.Hide();
            TrueFalse.Hide();
            Enumeration.Hide();

            if (examtype == "Multiple Choice")
                MultipleChoice.Show();

            else if (examtype == "True/False")
                TrueFalse.Show();

            else if (examtype == "True/Identify")
                TrueIdentify.Show();

            else if (examtype == "Identification")
                Identification.Show();

            else if (examtype == "Essay")
                Essay.Show();

            else if (examtype == "Enumeration")
                Enumeration.Show();
        }

        private void InsertName()
        {
            connected.Open();
            cmd.CommandText = "select count(*) from information_schema.tables where table_name='result_" + exam.Replace("-", "") + "_" + sub.Replace(" ", "") +
                "_" + schoolyear + "' AND TABLE_SCHEMA='examination'";
            cmd.Connection = connected;
            string count = cmd.ExecuteScalar().ToString();
            connected.Close();

            if (count == "0")
            {
                connected.Open();
                cmd.CommandText = "create table `result_" + exam.Replace("-", "") + "_" + sub.Replace(" ", "") + "_" + schoolyear + "`(" +
                    " name VARCHAR(255) NOT NULL, gender VARCHAR(6) NOT NULL, course VARCHAR(255) NOT NULL, year INT NOT NULL, section VARCHAR(1) NOT NULL," +
                    " proctorby VARCHAR(255) NOT NULL, score INT NOT NULL, professor VARCHAR(255) NOT NULL, username VARCHAR(255) NOT NULL, PRIMARY KEY(username));";
                cmd.Connection = connected;
                cmd.ExecuteReader();
                connected.Close();
            }

            connected.Open();
            cmd.CommandText = "select count(*) from `result_" + exam.Replace("-", "") + "_" + sub.Replace(" ", "") + "_" + schoolyear + "` where `username` = '" + username + "'";
            cmd.Connection = connected;
            string countessay = cmd.ExecuteScalar().ToString();
            connected.Close();

            if (countessay == "0")
            {
                connected.Open();
                cmd.CommandText = "INSERT INTO `result_" + exam.Replace("-", "") + "_" + sub.Replace(" ", "") + "_" + schoolyear + "` " +
                    "(`name`, `gender`, `course`, `year`, `section`, `proctorby`, `score`, `professor`, `username`) VALUES('" + name + "', '" + gender + "', '" + course + "',  " +
                    "'" + year + "', '" + section + "', '" + proctorby + "', '', '" + profname + "', '" + username + "')";
                cmd.Connection = connected;
                cmd.ExecuteNonQuery();
                connected.Close();
            }
        }

        private void AlterTable()
        {
            try
            {
                i = id - 1;
                connected = new MySqlConnection(con);
                connected.Open();
                cmd.CommandText = "select count(*) from information_schema.columns where TABLE_SCHEMA = 'examination' AND " +
                "table_name = 'result_" + exam.Replace("-", "") + "_" + sub.Replace(" ", "") + "_" + schoolyear + "' AND COLUMN_NAME = 'Q" + id + "'";
                cmd.Connection = connected;
                string count = cmd.ExecuteScalar().ToString();
                connected.Close();

                if (count == "0")
                {
                    connected.Open();

                    if (examtype == "Enumeration")
                        cmd.CommandText = "ALTER TABLE `result_" + exam.Replace("-", "") + "_" + sub.Replace(" ", "") + "_" + schoolyear + "` ADD `Q" + id + "` INT(3) " +
                        "NOT NULL, ADD `EnumerationA" + id + "` LONGTEXT NOT NULL, ADD `EnumerationB" + id + "` LONGTEXT NOT NULL, ADD `EnumerationC" + id + "` LONGTEXT NOT NULL" +
                        ", ADD `EnumerationD" + id + "` LONGTEXT NOT NULL, ADD `EnumerationE" + id + "` LONGTEXT NOT NULL;";

                    else
                        cmd.CommandText = "ALTER TABLE `result_" + exam.Replace("-", "") + "_" + sub.Replace(" ", "") + "_" + schoolyear + "` ADD `Q" + id + "` INT(3) " +
                        "NOT NULL, ADD `AnswerQ" + id + "` LONGTEXT NOT NULL;";

                    cmd.Connection = connected;
                    cmd.ExecuteReader();
                    connected.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadName()
        {
            try
            {
                connected = new MySqlConnection(con);
                cmd.Connection = connected;
                cmd.CommandText = "select * from `student_info` where username = '" + username + "'";
                cmd.Connection = connected;
                connected.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    gender = (dr["gender"].ToString());
                    firstname = (dr["firstname"].ToString());
                    year = (Int32.Parse(dr["year"].ToString()));
                    course = (dr["course"].ToString());
                    section = (dr["section"].ToString());
                }
                connected.Close();
            }

            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayAnswer()
        {
            try
            {
                connected.Open();
                cmd.CommandText = "select count(*) from information_schema.columns where TABLE_SCHEMA = 'examination' AND " +
                "table_name = 'result_" + exam.Replace("-", "") + "_" + sub.Replace(" ", "") + "_" + schoolyear + "' AND COLUMN_NAME = 'Q" + id + "'";
                cmd.Connection = connected;
                string count = cmd.ExecuteScalar().ToString();
                connected.Close();

                if (count == "1")
                {
                    if (examtype == "Enumeration")
                    {
                        cmd.CommandText = "select * from `result_" + exam.Replace("-", "") + "_" + sub.Replace(" ", "") + "_" + schoolyear + "` where username = '" + username + "'";
                        cmd.Connection = connected;
                        connected.Open();
                        MySqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            EnumA.Text = (dr["EnumerationA" + id + ""].ToString());
                            EnumB.Text = (dr["EnumerationB" + id + ""].ToString());
                            EnumC.Text = (dr["EnumerationC" + id + ""].ToString());
                            EnumD.Text = (dr["EnumerationD" + id + ""].ToString());
                            EnumE.Text = (dr["EnumerationE" + id + ""].ToString());
                        }

                        connected.Close();
                    }

                    else
                    {
                        cmd.CommandText = "select * from `result_" + exam.Replace("-", "") + "_" + sub.Replace(" ", "") + "_" + schoolyear + "` where username = '" + username + "'";
                        cmd.Connection = connected;
                        connected.Open();
                        MySqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            prevans = (dr["AnswerQ" + id + ""].ToString());
                        }

                        connected.Close();

                        if (examtype == "Multiple Choice")
                        {
                            if (prevans == a)
                                AAnsMC.Checked = true;

                            else if (prevans == b)
                                BAnsMC.Checked = true;

                            else if (prevans == c)
                                CAnsMC.Checked = true;

                            else if (prevans == d)
                                BAnsMC.Checked = true;
                        }

                        else if (examtype == "True/False")
                        {
                            if (prevans == "True")
                                TFTrue.Checked = true;

                            else if (prevans == "False")
                                TFFalse.Checked = true;
                        }

                        else if (examtype == "True/Identify")
                        {
                            if (prevans == "True")
                            {
                                TITrue.Checked = true;
                                TIFalse.Text = "";
                            }

                            else if (prevans != "True")
                            {
                                TITrue.Checked = false;
                                TIFalse.Text = prevans;
                            }
                        }

                        else if (examtype == "Identification")
                            AnswerIdent.Text = prevans;

                        else if (examtype == "Essay")
                            AnswerEssay.Text = prevans;
                    }
                }

                else if (count == "0")
                {
                    HideShow();
                    Finish();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Score()
        {
            if (examtype == "Multiple Choice")
            {
                if (AAnsMC.Checked)
                    ans = AMC.Text;

                else if (BAnsMC.Checked)
                    ans = BMC.Text;

                else if (CAnsMC.Checked)
                    ans = CMC.Text;

                else if (DAnsMC.Checked)
                    ans = DMC.Text;
            }

            else if (examtype == "True/False")
            {
                if (TFTrue.Checked)
                    ans = "True";

                else if (TFFalse.Checked)
                    ans = "False";
            }

            else if (examtype == "True/Identify")
            {
                if (TITrue.Checked)
                    ans = "True";

                else if (TIFalse.Text != "")
                    ans = TIFalse.Text;
            }

            else if (examtype == "Identification")
            {
                if (AnswerIdent.Text != "")
                    ans = AnswerIdent.Text;
            }

            else if (examtype == "Essay")
            {
                if (AnswerEssay.Text != "" && button == "next")
                {
                    ans = AnswerEssay.Text;
                    points = 0;
                }
            }

            AlterTable();

            try
            {
                connected = new MySqlConnection(con);
                cmd.Connection = connected;
                cmd.CommandText = "select * from `result_" + exam.Replace("-", "") + "_" + sub.Replace(" ", "") + "_" + schoolyear + "` where username = '" + username + "'";
                cmd.Connection = connected;
                connected.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    pointsdb = Int32.Parse(dr["Q" + id + ""].ToString());
                }
                connected.Close();
            }

            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (button == "next")
            {
                if (examtype == "Enumeration")
                {
                    try
                    {
                        string itemtype = "";
                        int scoredbdb = 0;

                        connected.Open();
                        cmd.CommandText = "select * from `" + exam.Replace("-", "") + "_" + sub.Replace(" ", "") + "_" + schoolyear + "` where `id` = '" + id + "'";
                        cmd.Connection = connected;
                        MySqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            itemtype = (dr["itemtype"].ToString());
                            scoredbdb = int.Parse(dr["points"].ToString());
                        }
                        connected.Close();

                        if (itemtype == "Single Score")
                        {
                            if (fix == "Yes")
                            {
                                if (EnumA.Text == enuma && EnumB.Text == enumb && EnumC.Text == enumc && EnumD.Text == enumd && EnumE.Text == enume)
                                {
                                    scoredbdb = 1;
                                    totalpoints += scoredbdb;
                                }
                            }

                            else if (fix == "No")
                            {
                                int fixint = 0;
                                foreach (Control ctrl in tableLayoutPanel15.Controls)
                                {
                                    if (ctrl is MemoEdit)
                                    {
                                        MemoEdit c = ctrl as MemoEdit;
                                        string[] enumarray = new string[5] {enuma,enumb,enumc,enumd,enume};
                                        for (int addint = 0; addint < enumarray.Length ;addint++)
                                        {
                                            if(c.Text == enumarray[addint])
                                            {
                                                fixint = 1;
                                                break;
                                            }
                                        }
                                    }
                                }

                                if (fixint == 5)
                                {
                                    scoredbdb = 1;
                                    totalpoints += scoredbdb;
                                }
                            }
                        }

                        else if (itemtype == "Multiple Score")
                        {
                            if (fix == "Yes")
                            {
                                if (EnumA.Text == enuma && EnumB.Text == enumb && EnumC.Text == enumc && EnumD.Text == enumd && EnumE.Text == enume)
                                    totalpoints += scoredbdb;
                            }

                            else if (fix == "No")
                            {
                                int fixint = 0;
                                string[] enumarray = new string[] { enuma, enumb, enumc, enumd, enume };
                                foreach (Control ctrl in tableLayoutPanel15.Controls)
                                {
                                    if (ctrl is MemoEdit)
                                    {
                                        MemoEdit c = ctrl as MemoEdit;
                                        for (int addint = 0; addint < enumarray.Length; addint++)
                                        {
                                            if (c.Text == enumarray[addint])
                                            {
                                                fixint = 1;
                                                break;
                                            }
                                        }
                                    }
                                }

                                if (fixint == 5)
                                {
                                    scoredbdb = points;
                                    points = scoredbdb;
                                    totalpoints += scoredbdb;
                                }

                                else if (fixint == 0)
                                {
                                    scoredbdb = 0;
                                    totalpoints += scoredbdb;
                                }

                                else
                                {
                                    double itemdouble = Convert.ToDouble(fixint) / 5.0;
                                    double ansdouble = itemdouble * Convert.ToDouble(points);
                                    scoredbdb = Convert.ToInt32(Math.Round(ansdouble, MidpointRounding.AwayFromZero));
                                    totalpoints += scoredbdb;
                                }
                            }
                        }

                        connected.Open();
                        cmd.CommandText = "Update `result_" + exam.Replace("-", "") + "_" + sub.Replace(" ", "") + "_" + schoolyear + "` set `Score` = '" + totalpoints + "', `Q" + id +
                        "` = '" + scoredbdb + "' , `EnumerationA" + id + "`  = '" + EnumA.Text + "' , `EnumerationB" + id + "`  = '" + EnumB.Text + "'" +
                        " , `EnumerationC" + id + "`  = '" + EnumC.Text + "' , `EnumerationD" + id + "`  = '" + EnumD.Text + "' , `EnumerationE" + id + "`  = '" + EnumE.Text + "'" +
                        " where username = '" + username + "'";
                        cmd.Connection = connected;
                        cmd.ExecuteReader();
                        connected.Close();
                    }

                    catch (Exception err)
                    {
                        MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else if (examtype != "Enumeration")
                {
                    if (answer != ans && pointsdb != 0)
                        points = 0;

                    else if (answer != ans && pointsdb == 0)
                        points = 0;

                    else if (answer == ans && pointsdb != 0)
                        totalpoints += points;

                    else if (answer == ans && pointsdb == 0)
                        totalpoints += points;

                    try
                    {
                        connected.Open();
                        cmd.CommandText = "Update `result_" + exam.Replace("-", "") + "_" + sub.Replace(" ", "") + "_" + schoolyear + "` set `Score` = '" + totalpoints + "', `Q" + id +
                        "` = '" + points + "' , `AnswerQ" + id + "`  = '" + ans + "' where username = '" + username + "'";
                        cmd.Connection = connected;
                        cmd.ExecuteReader();
                        connected.Close();
                    }

                    catch (Exception err)
                    {
                        MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            else if (button == "prev")
            {
                if (pointsdb == 0 && answer == ans)
                    points = 0;

                else if (pointsdb != 0 && answer != ans)
                {
                    points = 0;
                    totalpoints -= pointsdb;
                }

                else if (pointsdb == 0 && answer != ans)
                    points = 0;

                else if (pointsdb != 0 && answer == ans)
                {
                    points = 0;
                    totalpoints -= pointsdb;
                }
            }

            AAnsMC.Checked = false;
            BAnsMC.Checked = false;
            CAnsMC.Checked = false;
            DAnsMC.Checked = false;
            TITrue.Checked = false;
            TIFalse.Text = "";
            TFTrue.Checked = true;
            TFFalse.Checked = false;
            AnswerIdent.Text = "";
            AnswerEssay.Text = "";
            EnumA.Text = "";
            EnumB.Text = "";
            EnumC.Text = "";
            EnumD.Text = "";
            EnumE.Text = "";
        }

        public void Loading()
        {
            LoadName();
            InsertName();
            Display();
            Last();
            DisplayAnswer();
            Starter.Hide();
            Essential.Show();
            Home.Hide();
        }

        public void Essentials(string Ffullname, string FExam, string FSubject, string FSchoolYear, string FUsername)
        {
            name = Ffullname;
            exam = FExam;
            sub = FSubject;
            schoolyear = FSchoolYear;
            Subtxt.Text = sub;
            Qtype.Text = exam + " Exam";
            username = FUsername;

            try
            {
                connected = new MySqlConnection(con);
                cmd.CommandText = "select * from `schedule_" + exam + "_" + schoolyear + "` where subject = '" + sub + "'";
                cmd.Connection = connected;
                connected.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    End = (Convert.ToDateTime(dr["completeendtime"].ToString()));
                }
                connected.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}