using System;
using System.Windows.Forms;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
using System.Reflection;

namespace Lan_Based_Examination
{
    public partial class Check : DevExpress.XtraEditors.XtraForm
    {
        private string con;
        private MySqlConnection connected;
        MySqlCommand cmd = new MySqlCommand();
        TableLayoutPanel tb = new TableLayoutPanel();
        int lastid, id = 1, studscore, studtotalscore, totalscore, numberofsubject, firstnumberdb, lastnumberdb, points, totalitems;
        string permission, name, exam, studans, schoolyear, username, questions, a, b, c, d, examtype,
            item2, enuma, enumb, enumc, enumd, enume, logger, fix = "No";

        private void Check_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Home_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.F1)
                MessageBox.Show("Alt + Left = Previous\nAlt + Right = Next\nEscape = " +
                    "Go to Menu", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else if (e.KeyCode == Keys.Right && e.Modifiers == Keys.Alt && Essential.Visible == true)
                Next_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.Left && e.Modifiers == Keys.Alt && Essential.Visible == true)
                Previous_Click(sender, EventArgs.Empty);
        }

        private void Check_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger = "Exit Application";
            Log();
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (id == 1)
                MessageBox.Show("You reach the first question.");

            else
            {
                id--;
                LoadQuestion();
                StudAns();
                LoadAnswer();
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            Score.ReadOnly = true;

            if (int.Parse(Score.Text) > points)
            {
                MessageBox.Show("The total points in this item is " + points + " only.");
                Score.ReadOnly = false;
            }

            else
            {
                if (examtype == "Essay" && Score.Text == "")
                {
                    MessageBox.Show("No Score. Please fill it up");
                    Score.ReadOnly = false;
                }

                else if (examtype == "Essay" && Score.Text != "")
                {
                    int essayscore;

                    if (int.Parse(Score.Text) > studscore)
                    {
                        essayscore = int.Parse(Score.Text) - studscore;
                        totalscore = studtotalscore + essayscore;
                        EssayPointsUpdate(essayscore);
                    }

                    else if (studscore > int.Parse(Score.Text))
                    {
                        essayscore = studscore - int.Parse(Score.Text);
                        totalscore = studtotalscore - essayscore;
                        EssayPointsUpdate(essayscore);
                    }

                    id++;
                    LoadAnswer();
                    LoadQuestion();
                    Finish();
                    StudAns();
                }

                else
                {
                    id++;
                    LoadQuestion();
                    LoadAnswer();
                    Finish();
                    StudAns();
                }
            }
        }

        private void Score_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Numbers only.");
            }
        }

        public void Need(string un, string n, string perm, string sy)
        {
            username = un;
            permission = perm;
            name = n;
            schoolyear = sy; }

        private void Subtxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            Examtxt.Enabled = true;
            Examtxt.SelectedIndex = -1;
            Clear();
        }

        private void Finish()
        {
            try
            {
                if (id > lastid)
                {
                    id = lastid;
                    connected = new MySqlConnection(con);
                    cmd.CommandText = "select * from `result_" + exam.Replace("-", "") + "_"
                        + Subtxt.Text.Replace(" ", "") + "_" + schoolyear + "` where name = '" + Nametxt.Text + "' && professor = '" + name + "'";
                    cmd.Connection = connected;
                    connected.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        studtotalscore = int.Parse(dr["score"].ToString());
                    }
                    connected.Close();

                    connected.Open();
                    cmd.CommandText = "Update `result_" + exam.Replace("-", "") + "_" + Subtxt.Text.Replace(" ", "") + "_" + schoolyear + "` set `Done` = 'Yes' " +
                        "where name = '" + Nametxt.Text + "' && professor = '" + name + "'";
                    cmd.Connection = connected;
                    cmd.ExecuteNonQuery();
                    connected.Close();

                    MessageBox.Show("Checking Complete.");
                    MessageBox.Show("Total Score: " + studtotalscore.ToString() + " / " + totalitems.ToString());
                    logger = "Finish checking the answer of " + Nametxt.Text + ".\n" + Examtxt.Text + " Examination of " + Subtxt.Text + "";
                    Log();

                    if (examtype == "Essay" || examtype == "Identification" || examtype == "True/Identify")
                        Score.ReadOnly = true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadQuestion()
        {
            try
            {
                connected = new MySqlConnection(con);
                cmd.Connection = connected;
                cmd.CommandText = "select * from `" + exam.Replace("-", "") + "_" + Subtxt.Text.Replace(" ", "") + "_" + schoolyear + "` where id = '" + id + "'";
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
                    fix = dr["fixenumeration"].ToString();
                    examtype = (dr["questiontype"].ToString());
                    points = (Int32.Parse(dr["points"].ToString()));
                    totalitems = (Int32.Parse(dr["totalitems"].ToString()));
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

        private void Clear()
        {
            Nametxt.Properties.Items.Clear();
            Essay.Visible = false;
            Identification.Visible = false;
            TrueFalse.Visible = false;
            TrueIdentify.Visible = false;
            MultipleChoice.Visible = false;
            Enumeration.Visible = false;
            Nametxt.Enabled = false;
            DMC.Text = "";
            CMC.Text = "";
            BMC.Text = "";
            AMC.Text = "";
            EnumA.Text = "";
            EnumB.Text = "";
            EnumC.Text = "";
            EnumD.Text = "";
            EnumE.Text = "";
            QuestionMC.Text = "";
            QuestionTF.Text = "";
            QuestionTI.Text = "";
            QuestionIdent.Text = "";
            QuestionEnum.Text = "";
            TIFalse.Text = "";
            QuestionEssay.Text = "";
            AnswerIdent.Text = "";
            TFFalse.Checked = false;
            TFTrue.Checked = false;
            TITrue.Checked = false;
            Nametxt.Properties.Items.Clear();
            Essential.Visible = false;
            Score.Text = "";
        }

        private string Verify(MySqlConnection connected)
        {
            connected = new MySqlConnection(con);
            connected.Open();
            cmd.CommandText = "select count(*) from information_schema.tables where table_name = 'result_" + exam.Replace("-", "") + "_" + Subtxt.Text.Replace(" ", "") + "_" +
                schoolyear + "' AND TABLE_SCHEMA='examination'";
            cmd.Connection = connected;
            string count = cmd.ExecuteScalar().ToString();
            connected.Close();
            return count;
        }

        private void Nametxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            id = 1;
            logger = "Checking the answer of " + Nametxt.Text + ".\n" + Examtxt.Text + " Examination of " + Subtxt.Text + "";
            Log();
            LoadAnswer();
            LoadQuestion();
            Finish();
            StudAns();
            Essential.Visible = true ;
        }

        private void LoadAnswer()
        {
            Score.Text = studscore.ToString();

            if (examtype == "Multiple Choice")
            {
                AAnsMC.ForeColor = Color.White;
                BAnsMC.ForeColor = Color.White;
                CAnsMC.ForeColor = Color.White;
                DAnsMC.ForeColor = Color.White;

                if (studans == AMC.Text)
                {
                    AAnsMC.Checked = true;
                    AAnsMC.ForeColor = Color.Red;
                }

                else if (studans == BMC.Text)
                {
                    BAnsMC.Checked = true;
                    AAnsMC.ForeColor = Color.Red;
                }

                else if (studans == CMC.Text)
                {
                    CAnsMC.Checked = true;
                    AAnsMC.ForeColor = Color.Red;
                }

                else if (studans == DMC.Text)
                {
                    DAnsMC.Checked = true;
                    AAnsMC.ForeColor = Color.Red;
                }

                Score.ReadOnly = true;
            }

            else if (examtype == "Enumeration")
            {
                try
                {
                    connected = new MySqlConnection(con);
                    cmd.CommandText = "select * from `result_" + exam.Replace("-", "") + "_"
                        + Subtxt.Text.Replace(" ", "") + "_" + schoolyear + "` where name = '" + Nametxt.Text + "' && professor = '" + name + "'";
                    cmd.Connection = connected;
                    connected.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        try
                        {
                            if (examtype == "Enumeration" && id <= lastid)
                            {
                                enuma = (dr["enumerationa" + id + ""].ToString());
                                enumb = (dr["enumerationb" + id + ""].ToString());
                                enumc = (dr["enumerationc" + id + ""].ToString());
                                enumd = (dr["enumerationd" + id + ""].ToString());
                                enume = (dr["enumeratione" + id + ""].ToString());
                                EnumA.Text = enuma;
                                EnumB.Text = enumb;
                                EnumC.Text = enumc;
                                EnumD.Text = enumd;
                                EnumE.Text = enume;
                            }

                            else if (examtype != "Enumeration" && id <= lastid)
                            {
                                studans = dr["AnswerQ" + id + ""].ToString();
                            }

                            studscore = int.Parse(dr["Q" + id + ""].ToString());
                            studtotalscore = int.Parse(dr["score"].ToString());
                            TS.Text = studtotalscore.ToString();
                        }
                        catch (IndexOutOfRangeException)
                        {
                            MessageBox.Show("Done");
                        }
                    }

                    connected.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Score.ReadOnly = false;
            }

            else if (examtype == "True/False")
            {
                if (studans == TFTrue.Text)
                    TFTrue.Checked = true;

                else if (studans == TFFalse.Text)
                    TFFalse.Checked = true;

                Score.ReadOnly = false;
            }

            else if (examtype == "True/Identify")
            {
                if (studans == TITrue.Text)
                {
                    TITrue.Checked = true;
                    TIFalse.Text = "";
                }

                else
                {
                    TIFalse.Text = studans;
                    TITrue.Checked = false;
                }

                Score.ReadOnly = false;
            }

            else if (examtype == "Identification")
            {
                AnswerIdent.Text = studans;
                Score.ReadOnly = false;
            }

            else if (examtype == "Essay")
            {
                AnswerEssay.Text = studans;
                Score.ReadOnly = false;
            }
        }

        private void EssayPointsUpdate(int essayscore)
        {
            connected = new MySqlConnection(con);
            connected.Open();
            cmd.CommandText = "Update `result_" + exam.Replace("-", "") + "_" + Subtxt.Text.Replace(" ", "") + "_" + schoolyear + "` set `Q" + id + "` = " +
            "'" + int.Parse(Score.Text) + "', `Score` = '" + totalscore + "' where name = '" + Nametxt.Text + "' && professor = '" + name + "'";
            cmd.Connection = connected;
            cmd.ExecuteNonQuery();
            connected.Close();
        }

        private void StudAns()
        {
            try
            {
                connected = new MySqlConnection(con);
                cmd.CommandText = "select * from `result_" + exam.Replace("-", "") + "_"
                    + Subtxt.Text.Replace(" ", "") + "_" + schoolyear + "` where name = '" + Nametxt.Text + "' && professor = '" + name + "'";
                cmd.Connection = connected;
                connected.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    try
                    {
                        if (examtype == "Enumeration" && id <= lastid)
                        {
                            enuma = dr["EnumerationA" + id + ""].ToString();
                            enumb = dr["EnumerationB" + id + ""].ToString();
                            enumc = dr["EnumerationC" + id + ""].ToString();
                            enumd = dr["EnumerationD" + id + ""].ToString();
                            enume = dr["EnumerationE" + id + ""].ToString();
                        }

                        else if (examtype != "Enumeration" && id <= lastid)
                            studans = dr["AnswerQ" + id + ""].ToString();

                        studscore = int.Parse(dr["Q" + id + ""].ToString());
                        studtotalscore = int.Parse(dr["score"].ToString());
                        TS.Text = studtotalscore.ToString();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        MessageBox.Show("End of the Examination.");
                    }
                }

                connected.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadAnswer();
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

        private void Examtxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                id = 1;
                exam = Examtxt.Text;
                string count = Verify(connected);

                if (count == "0")
                {
                    if (Examtxt.SelectedIndex != -1 && Examtxt.Enabled == true)
                    {
                        MessageBox.Show("Record not exist.");
                        Nametxt.Properties.Items.Clear();
                    }
                    Clear();
                }

                else if (count == "1")
                {
                    Nametxt.Properties.Items.Clear();
                    connected = new MySqlConnection(con);
                    cmd.CommandText = "select * from `result_" + exam.Replace("-", "") + "_" + Subtxt.Text.Replace(" ", "") + "_" + schoolyear + "` where professor = '" + name + "'";
                    cmd.Connection = connected;
                    connected.Open();
                    MySqlDataReader dr1 = cmd.ExecuteReader();

                    while (dr1.Read())
                    {
                        Nametxt.Properties.Items.Add(dr1["name"].ToString());
                    }

                    connected.Close();
                    Nametxt.Enabled = true;
                    LastID();
                    LoadQuestion();
                }
            }

            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Clocktxt.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
       
        private void Check_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            AAnsMC.ForeColor = Color.White;
            BAnsMC.ForeColor = Color.White;
            CAnsMC.ForeColor = Color.White;
            DAnsMC.ForeColor = Color.White;
            SubjectLoad();
        }

        private void SubjectLoad()
        {
            int addtb = 0;
            connected = new MySqlConnection(con);
            cmd.CommandText = "select * from `administrator` where username = '" + username + "'";
            cmd.Connection = connected;
            connected.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                numberofsubject = int.Parse(dr["numberofsubject"].ToString());

                do
                {
                    addtb++;
                    Subtxt.Properties.Items.Add(dr["subject" + addtb + ""].ToString());

                    if (addtb == 1)
                    {
                        Subtxt.Enabled = false;
                        Subtxt.Text = dr["subject" + addtb + ""].ToString();
                    }

                    else
                    {
                        Subtxt.Enabled = true;
                        Subtxt.SelectedIndex = -1;
                    }

                } while (numberofsubject > addtb);

            }
            connected.Close();
        }

        public Check()
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

        private void LastID()
        {
            cmd.CommandText = "select id from `" + exam.Replace("-", "") + "_" + Subtxt.Text.Replace(" ", "") + "_" + schoolyear +
                "` order by id desc limit 1"; ;
            cmd.Connection = connected;
            connected.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                lastid = (Int32.Parse(dr["id"].ToString()));
            }
            connected.Close();
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