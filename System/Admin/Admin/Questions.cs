using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Word = Microsoft.Office.Interop.Word;

namespace Lan_Based_Examination
{
    public partial class Questions : DevExpress.XtraEditors.XtraForm
    {
        private string con;
        private MySqlConnection connected;
        MySqlCommand cmd = new MySqlCommand();
        int firstnumber, lastnumber, totalitems, points, id, i, firstnumberdb, lastnumberdb;
        string questions, a, b, c, d, answer, examtype, username, name, exam, how = "", item, item2,
            ans, AnsMC, permission, dateslot, timeslot, endslot, schoolyear, subject, enuma, 
            enumb, enumc, enumd, enume, fix = "no", logger, buttonstats = "";

        public Questions()
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

        private void Questions_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            AAnsMC.ForeColor = Color.White;
            BAnsMC.ForeColor = Color.White;
            CAnsMC.ForeColor = Color.White;
            DAnsMC.ForeColor = Color.White;
            TFTrue.ForeColor = Color.White;
            TFFalse.ForeColor = Color.White;
            TimeSlot.ForeColor = Color.White;
            DateSlot.ForeColor = Color.White;
            EndSlot.ForeColor = Color.White;
            TimeSlot.BackColor = Color.FromArgb(35, 35, 35);
            DateSlot.BackColor = Color.FromArgb(35, 35, 35);
            EndSlot.BackColor = Color.FromArgb(35, 35, 35);
            SubjectLoad();
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

        private void Xbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                this.Close();
        }

        private void MCbtn_Click(object sender, EventArgs e)
        {
            examtype = "Multiple Choice";
            CheckEnum.Visible = false;
            HideShow();
        }

        private void TFbtn_Click(object sender, EventArgs e)
        {
            examtype = "True/False";
            CheckEnum.Visible = false;
            HideShow();
        }

        private void TIbtn_Click(object sender, EventArgs e)
        {
            examtype = "True/Identify";
            CheckEnum.Visible = false;
            HideShow();
        }

        private void Ibtn_Click(object sender, EventArgs e)
        {
            examtype = "Identification";
            CheckEnum.Visible = false;
            HideShow();
        }

        private void Ebtn_Click(object sender, EventArgs e)
        {
            examtype = "Essay";
            CheckEnum.Visible = false;
            HideShow();
        }

        private void SingleItem_Click(object sender, EventArgs e)
        {
            SI();
            item = "Single Score";
            item2 = "Single Score";
        }

        private void MultipleItem_Click(object sender, EventArgs e)
        {
            MI();
            item = "Multiple Score";
            item2 = "Multiple Score";
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (id == 1)
            {
                MessageBox.Show("You reach the first question");
            }

            else
            {
                try
                {
                    buttonstats = "prev";
                    item = "";
                    id--;
                    Display();
                }

                catch (Exception err)
                {
                    MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if ((Identification.Visible == true || TrueFalse.Visible == true || TrueIdentify.Visible == true ||
                Essay.Visible == true || MultipleChoice.Visible == true || Enumeration.Visible == true) && (SingleScoreMC.Visible == true ||
                SingleScoreIdent.Visible == true || SingleScoreTI.Visible == true || SingleScoreTF.Visible == true
                || SingleScoreEssay.Visible == true || SingleScoreEnum.Visible == true || MultipleScoreEssay.Visible == true || MultipleScoreIdent.Visible == true
                || MultipleScoreTF.Visible == true || MultipleScoreMC.Visible == true || MultipleScoreTI.Visible == true || MultipleScoreEnum.Visible == true))
            {
                if (examtype == "Multiple Choice")
                {
                    string MCA = AMC.Text;
                    string MCB = BMC.Text;
                    string MCC = CMC.Text;
                    string MCD = DMC.Text;
                    string MCQ = QuestionMC.Text;

                    if (AAnsMC.Checked == false && BAnsMC.Checked == false && CAnsMC.Checked == false && DAnsMC.Checked == false)
                        MessageBox.Show("Please choose an answer.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MCA == "" || MCB == "" || MCC == "" || MCD == "")
                        MessageBox.Show("Please fill up all the choices.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MCQ.Replace(" ", "") == "")
                        MessageBox.Show("The question is empty.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MCA != "" && MCB != "" && MCC != "" && MCD != "" && MCQ.Replace(" ", "") != "")
                        if (MCA.Substring(MCA.Length - 1) == "\\" || MCA.Substring(MCA.Length - 1) == "'"
                        || MCB.Substring(MCB.Length - 1) == "\\" || MCB.Substring(MCB.Length - 1) == "'"
                        || MCC.Substring(MCC.Length - 1) == "\\" || MCC.Substring(MCC.Length - 1) == "'"
                        || MCD.Substring(MCD.Length - 1) == "\\" || MCD.Substring(MCD.Length - 1) == "'"
                        || MCQ.Substring(MCQ.Length - 1) == "\\" || MCQ.Substring(MCQ.Length - 1) == "'")
                            MessageBox.Show("Quatation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        else
                        {
                            buttonstats = "next";
                            CheckEnum.Visible = false;
                            StartInsert();
                        }
                }

                else if (examtype == "True/False")
                {
                    string TFQ = QuestionTF.Text;

                    if (TFTrue.Checked == false && TFFalse.Checked == false)
                        MessageBox.Show("Please choose an answer.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (TFQ.Replace(" ", "") == "")
                        MessageBox.Show("The question is empty.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    if (TFQ != "" && (TFTrue.Checked == true || TFFalse.Checked == true))
                    {
                        if (TFQ.Substring(TFQ.Length - 1) == "\\" || TFQ.Substring(TFQ.Length - 1) == "'")
                            MessageBox.Show("Quatation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    
                        else
                        { 
                            buttonstats = "next";
                            CheckEnum.Visible = false;
                            StartInsert();
                        }
                    }
                }

                else if (examtype == "Identification")
                {
                    string IAns = AnswerIdent.Text;
                    string IdentQ = QuestionIdent.Text;

                    if (IAns == "")
                        MessageBox.Show("Please answer the question.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (IdentQ.Replace(" ", "") == "")
                        MessageBox.Show("The question is empty.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    if (IAns != "" && IdentQ != "")
                    {
                        if (IAns.Substring(IAns.Length - 1) == "\\" || IAns.Substring(IAns.Length - 1) == "'"
                        || IdentQ.Substring(IdentQ.Length - 1) == "\\" || IdentQ.Substring(IdentQ.Length - 1) == "'")
                            MessageBox.Show("Quatation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                              
                        else
                        { 
                            buttonstats = "next";
                            CheckEnum.Visible = false;
                            StartInsert();
                        }
                    }
                }

                else if (examtype == "True/Identify")
                {
                    string TIAns = TIFalse.Text;
                    string TIQ = QuestionTI.Text;

                    if (TIQ == "")
                        MessageBox.Show("The question is empty.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (TITrue.Checked == false && TIAns == "")
                        MessageBox.Show("Please answer the question.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if ((TITrue.Checked == true && TIAns == "") || (TITrue.Checked == false && TIAns != ""))
                    {
                        if (TITrue.Checked == false && TIAns != "")
                        {
                            if (TIAns.Substring(TIAns.Length - 1) == "\\" || TIAns.Substring(TIAns.Length - 1) == "'"
                            || TIQ.Substring(TIQ.Length - 1) == "\\" || TIQ.Substring(TIQ.Length - 1) == "'")
                                MessageBox.Show("Quatation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            else
                            {
                                buttonstats = "next";
                                CheckEnum.Visible = false;
                                StartInsert();
                            }
                        }

                        else if (TITrue.Checked == true && TIAns == "")
                        {

                            if (TIQ.Substring(TIQ.Length - 1) == "\\" || TIQ.Substring(TIQ.Length - 1) == "'")
                                MessageBox.Show("Quatation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            else
                            {
                                buttonstats = "next";
                                CheckEnum.Visible = false;
                                StartInsert();
                            }
                        }
                    }
                }

                else if (examtype == "Essay")
                {
                    string EQ = QuestionEssay.Text;

                    if (EQ == "")
                        MessageBox.Show("The question is empty.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (EQ != "")
                    {
                        if (EQ.Substring(EQ.Length - 1) == "\\" || EQ.Substring(EQ.Length - 1) == "'")
                            MessageBox.Show("Quatation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        else
                        {
                            buttonstats = "next";
                            CheckEnum.Visible = false;
                            StartInsert();
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
                    string EQ = QuestionEnum.Text;

                    if (EA == "" || EB == "" || EC == "" || ED == "" || EE == "")
                        MessageBox.Show("Please fill up all the fields.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (EQ.Replace(" ", "") == "")
                        MessageBox.Show("The question is empty.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (EA != "" && EB != "" && EC != "" && ED != "" && EE != "" && EQ.Replace(" ", "") != "")
                    {
                        if (EA.Substring(EA.Length - 1) == "\\" || EA.Substring(EA.Length - 1) == "'"
                        || EB.Substring(EB.Length - 1) == "\\" || EB.Substring(EB.Length - 1) == "'"
                        || EC.Substring(EC.Length - 1) == "\\" || EC.Substring(EC.Length - 1) == "'"
                        || ED.Substring(ED.Length - 1) == "\\" || ED.Substring(ED.Length - 1) == "'"
                        || EE.Substring(EE.Length - 1) == "\\" || EE.Substring(EE.Length - 1) == "'"
                        || EQ.Substring(EQ.Length - 1) == "\\" || EQ.Substring(EQ.Length - 1) == "'")
                            MessageBox.Show("Quatation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        else
                        { 
                            buttonstats = "next";
                            CheckEnum.Visible = false;
                            StartInsert();
                        }
                    }
                }
            }

            else if (Identification.Visible == false && TrueFalse.Visible == false && TrueIdentify.Visible == false &&
                Essay.Visible == false && MultipleChoice.Visible == false && Enumeration.Visible == false)
            {
                MessageBox.Show("Please select the type of exam.");
            }

            else if (SingleScoreMC.Visible == false && SingleScoreIdent.Visible == false && SingleScoreTI.Visible == false
                && SingleScoreTF.Visible == false && SingleScoreEssay.Visible == false && SingleScoreEnum.Visible == false && MultipleScoreEssay.Visible == false
                && MultipleScoreIdent.Visible == false && MultipleScoreTF.Visible == false && MultipleScoreMC.Visible == false
                && MultipleScoreTI.Visible == false && MultipleScoreEnum.Visible == false)
            {
                MessageBox.Show("Please select if the queston is single item or multiple item.");
            }

            else
            {
                MessageBox.Show("Please select the type of exam and select if the queston is single item or multiple item.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Clocktxt.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void CreateShower_Click(object sender, EventArgs e)
        {
            StartPanel.Hide();
            CreatePanel.Show();
            Export.Hide();
        }

        private void EditShower_Click(object sender, EventArgs e)
        {
            EditPanel.Show();
            StartPanel.Hide();
            Export.Hide();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            exam = EditExam.Text;

            if (exam == "" && EditSubject.Text == "")
                MessageBox.Show("Please fill up the fields.");

            else if (exam == "")
                MessageBox.Show("Please choose an examination.");

            else if (EditSubject.Text == "")
                MessageBox.Show("Please choose a subject.");

            else if (exam != "" && EditSubject.Text != "")
            {
                subject = EditSubject.Text;

                try
                {
                    connected = new MySqlConnection(con);
                    string count = Verify();

                    if (count == "0")
                        MessageBox.Show("This examination doesn't exist.");

                    else if (count == "1")
                    {
                        EditSubject.TabStop = false;
                        EditExam.TabStop = false;

                        cmd.CommandText = "select id from `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` order by id desc limit 1"; ;
                        cmd.Connection = connected;
                        connected.Open();
                        MySqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            i = (Int32.Parse(dr["id"].ToString()));
                        }
                        i = i + 1;

                                                connected.Close();
                        UpperPanel.Hide();
                        logger = "Editing an examination: " + EditExam.Text + " Examination of " + EditSubject.Text + ".";
                        Log();
                        id = 1;
                        how = "edit";
                        Display();
                        Types.Show();
                        Item.Show();
                        Essential.Show();
                        DateTimePanel.Hide();
                        EditPanel.Hide();
                        MinItemEssay.Text = "1";
                        MinItemIdent.Text = "1";
                        MinItemTI.Text = "1";
                        MinItemTF.Text = "1";
                        MinItemMC.Text = "1";
                        MinItemEnum.Text = "1";
                        ScoreMC.Text = "1";
                        ScoreIdent.Text = "1";
                        ScoreTI.Text = "1";
                        ScoreTF.Text = "1";
                        ScoreEssay.Text = "1";
                        ScoreEnum.Text = "1";
                    }
                }

                catch (Exception err)
                {
                    MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditBack_Click(object sender, EventArgs e)
        {
            EditPanel.Hide();
            StartPanel.Show();
            Export.Show();
        }

        private void TI_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void Create_Click(object sender, EventArgs e)
        {

            if (TI.Text == "" && CreateExam.Text == "" && CreateSubject.Text == "")
                MessageBox.Show("Please fill up the fields.");

            else if (CreateExam.Text == "")
                MessageBox.Show("Please choose an examination.");

            else if (TI.Text == "")
                MessageBox.Show("Please fill up the total items.");

            else if (CreateSubject.Text == "")
                MessageBox.Show("Please select a subject.");

            else if (TI.Text != "" && CreateExam.Text != "" && CreateSubject.Text != "")
            {
                CreateSubject.TabStop = false;
                CreateExam.TabStop = false;
                TI.TabStop = false;
                exam = CreateExam.Text;
                id = 1;
                subject = CreateSubject.Text;
                exam = CreateExam.Text;
                totalitems = int.Parse(TI.Text);

                try
                {
                    how = "create";
                    string count = Verify();

                    if (count == "0")
                        CreateTable();

                    else if (count == "1")
                    {
                        DialogResult dialogResult = MessageBox.Show("This examination already have questions. Do you want to overwrite it?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.Yes)
                        {
                            DialogResult dialogResult1 = MessageBox.Show("Are you sure about this?", "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dialogResult1 == DialogResult.Yes)
                            {
                                logger = "Deleting an examination: " + CreateExam.Text + " Examination of " + CreateSubject.Text + ".";
                                Log();
                                connected.Open();
                                cmd.CommandText = "drop table `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "`";
                                cmd.Connection = connected;
                                cmd.ExecuteReader();
                                MessageBox.Show("Deleted successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                count = "0";
                                connected.Close();
                                CreateTable();
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CreateBack_Click(object sender, EventArgs e)
        {
            CreatePanel.Hide();
            StartPanel.Show();
            Export.Show();
        }

        private void ScoreTI_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void MinItemTI_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void MaxItemTI_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void ScoreTF_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void Questions_KeyDown(object sender, KeyEventArgs e)
        {
            if (how != "")
            {
                if (DateTimePanel.Visible == false)
                {
                    if ((e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1) && e.Modifiers == Keys.Alt)
                        MCbtn_Click(sender, EventArgs.Empty);

                    else if ((e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2) && e.Modifiers == Keys.Alt)
                        TFbtn_Click(sender, EventArgs.Empty);

                    else if ((e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3) && e.Modifiers == Keys.Alt)
                        TIbtn_Click(sender, EventArgs.Empty);

                    else if ((e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4) && e.Modifiers == Keys.Alt)
                        Ibtn_Click(sender, EventArgs.Empty);

                    else if ((e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5) && e.Modifiers == Keys.Alt)
                        Ebtn_Click(sender, EventArgs.Empty);

                    else if ((e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6) && e.Modifiers == Keys.Alt)
                        Enumbtn_Click(sender, EventArgs.Empty);

                    else if (e.KeyCode == Keys.Up && e.Modifiers == Keys.Alt)
                        SingleItem_Click(sender, EventArgs.Empty);

                    else if (e.KeyCode == Keys.Down && e.Modifiers == Keys.Alt)
                        MultipleItem_Click(sender, EventArgs.Empty);

                    else if (e.KeyCode == Keys.Left && e.Modifiers == Keys.Alt)
                        Previous_Click(sender, EventArgs.Empty);

                    else if (e.KeyCode == Keys.Right && e.Modifiers == Keys.Alt)
                        Next_Click(sender, EventArgs.Empty);

                    else if (e.KeyCode == Keys.Delete)
                        Clearbtn_Click(sender, EventArgs.Empty);

                    else if (e.KeyCode == Keys.F1)
                        MessageBox.Show("Alt + 1 = Multiple Choice\nAlt + 2 = True/False" +
                            "\nAlt + 3 = True/Identify\nAlt + 4 = Identification\nAlt + 5 = Essay" +
                            "\nAlt + 6 = Enumeration\nAlt + Up Arrow = Single Item\nAlt + Down Arrow = Multiple Items" +
                            "\nAlt + Right Arrow = Save/Update/Next\nAlt + Left Arrow = Previous\n" +
                            "\nDelete = Clear All Fields\n\nNote: You can't close the application until you " +
                            "finish creating/updating the examination", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else if (DateTimePanel.Visible == true)
                    if (e.KeyCode == Keys.F1)
                        MessageBox.Show("Alt + D = Done Button", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (how == "")
            {
                if (StartPanel.Visible == true)
                {
                    if (e.KeyCode == Keys.F1)
                        MessageBox.Show("Alt + C = Create\nAlt + E = Edit" +
                            "\nAlt + X = Export to Word\nEscape = Go to Main Menu" +
                            "", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else if (e.KeyCode == Keys.X && e.Modifiers == Keys.Alt)
                        Export_Click(sender, EventArgs.Empty);
                }

                else if (ExportWord.Visible == true)
                {
                    if (e.KeyCode == Keys.F1)
                        MessageBox.Show("Alt + E = Export\nAlt + B = Back" +
                            "\nEscape = Go to Main Menu" +
                            "", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else if (CreatePanel.Visible == true)
                {
                    if (e.KeyCode == Keys.F1)
                        MessageBox.Show("Alt + C = Create\nAlt + B = Back" +
                            "\nEscape = Go to Main Menu" +
                            "", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else if (EditPanel.Visible == true)
                {
                    if (e.KeyCode == Keys.F1)
                        MessageBox.Show("Alt + E = Edit\nAlt + B = Back" +
                            "\nEscape = Go to Main Menu" +
                            "", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (e.KeyCode == Keys.Escape && UpperPanel.Visible == true)
                    Home_Click(sender, EventArgs.Empty);
            }
        }

        private void Questions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (how != "")
            {
                MessageBox.Show("You must finish creating/editing the examination.");
                e.Cancel = true;
            }
        }

        private void MinItemTF_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void MaxItemTF_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void Export_Click(object sender, EventArgs e)
        {
            StartPanel.Hide();
            ExportWord.Show();
            Export.Hide();
        }

        private void ExportBack_Click(object sender, EventArgs e)
        {
            StartPanel.Show();
            ExportWord.Hide();
            Export.Show();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ExportSubject.Text == "" && ExportExam.Text == "")
                {
                    MessageBox.Show("Please fill up all choices.");
                }

                else if (ExportSubject.Text != "" && ExportExam.Text != "")
                {
                    connected = new MySqlConnection(con);
                    connected.Open();
                    cmd.CommandText = "select count(*) from information_schema.tables where table_name='" + ExportExam.Text.Replace("-", "") + "_" + 
                        ExportSubject.Text.Replace(" ", "") + "_" + schoolyear + "' AND TABLE_SCHEMA='examination'";
                    cmd.Connection = connected;
                    string count = cmd.ExecuteScalar().ToString();
                    connected.Close();

                    if (count == "0")
                        MessageBox.Show("This examination doesn't exist.");

                    else if (count == "1")
                    {
                        int lastid = 0, ide, firstnumberdb = 0, lastnumberdb = 0, totalitems = 0;
                        string questions = "", a = "", b = "", c = "", d = "", examtype = "", item2 = "", lastexamtype = "";

                        connected = new MySqlConnection(con);
                        cmd.CommandText = "select id from `" + ExportExam.Text.Replace("-", "") + "_" + ExportSubject.Text.Replace(" ", "") + "_" + schoolyear +
                        "` order by id desc limit 1"; ;
                        cmd.Connection = connected;
                        connected.Open();
                        MySqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            lastid = (Int32.Parse(dr["id"].ToString()));
                            lastid = lastid + 1;
                        }
                        connected.Close();

                        Word._Application app = new Word.Application();
                        app.WindowState = Word.WdWindowState.wdWindowStateMaximize;
                        Word.Document appDoc = app.Documents.Add();
                        app.ActiveDocument.PageSetup.LeftMargin = (float)36;
                        app.ActiveDocument.PageSetup.RightMargin = (float)36;

                        object appMissing = Missing.Value;
                        object endFlag = "\\endofdoc";
                        Word.Range wordRange = appDoc.Bookmarks.get_Item(ref endFlag).Range;
                        Word.Table appTable = appDoc.Tables.Add(wordRange, 2, 2, ref appMissing, Word.WdAutoFitBehavior.wdAutoFitWindow);
                        appTable.ApplyStyleDirectFormatting("Table Grid");
                        appTable.Cell(1, 1).Range.Text = "Name:";
                        appTable.Cell(2, 1).Range.Text = "Year and Section:";
                        appTable.Cell(1, 2).Range.Text = "Date of taking this exam:";
                        appTable.Cell(2, 2).Range.Text = "Score:";
                        appTable.Range.Bold = 1;

                        for (ide = 1; ide < lastid; ide++)
                        {
                            string numberstring = "", choices = "", underline = "", title = "";

                            connected = new MySqlConnection(con);
                            cmd.CommandText = "select * from `" + ExportExam.Text.Replace("-", "") + "_" + ExportSubject.Text.Replace(" ", "") + "_" + schoolyear + "` where id = '" + ide + "'";
                            cmd.Connection = connected;
                            connected.Open();
                            MySqlDataReader dr1 = cmd.ExecuteReader();

                            while (dr1.Read())
                            {
                                firstnumberdb = (Int32.Parse(dr1["number"].ToString()));
                                lastnumberdb = (Int32.Parse(dr1["lastnumber"].ToString()));
                                questions = (dr1["questions"].ToString());
                                a = (dr1["a"].ToString());
                                b = (dr1["b"].ToString());
                                c = (dr1["c"].ToString());
                                d = (dr1["d"].ToString());
                                examtype = (dr1["questiontype"].ToString());
                                totalitems = (Int32.Parse(dr1["totalitems"].ToString()));
                                item2 = (dr1["itemtype"].ToString());
                            }

                            connected.Close();

                            if (item2 == "Multiple Score")
                                numberstring = firstnumberdb.ToString() + "-" + lastnumberdb.ToString();

                            else if (item2 == "Single Score")
                                numberstring = firstnumberdb.ToString();

                            if (examtype == "Multiple Choice")
                            {
                                choices = "\n\tA. " + a + "\n\tB. " + b + "\n\tC. " + c + "\n\tD. " + d + "";
                                underline = "_______";
                            }

                            else if (examtype == "True/False")
                            {
                                choices = "";
                                underline = "_______";
                            }

                            else if (examtype == "True/Identify")
                            {
                                choices = "";
                                underline = "_______";
                            }

                            else if (examtype == "Identification")
                            {
                                choices = "";
                                underline = "_______";
                            }

                            else if (examtype == "Essay")
                            {
                                choices = "\n\t\n\n\n\n\n\n\n\n";
                                underline = "";
                            }

                            else if (examtype == "Enumeration")
                            {
                                choices = "\n\tA.\n\tB.\n\tC.\n\tD.\n\tE.";
                                underline = "";
                            }

                            Word.Paragraph appParagraph2;
                            appParagraph2 = appDoc.Paragraphs.Add();
                            Word.Paragraph appParagraph;
                            appParagraph = appDoc.Paragraphs.Add();

                            if (lastexamtype == "Essay")
                            {
                                if (examtype != "Essay")
                                {
                                    if (lastexamtype != examtype)
                                    {
                                        title = examtype;
                                        appParagraph2.Range.Words.Last.InsertBreak(Word.WdBreakType.wdSectionBreakContinuous);
                                        appParagraph2.Range.PageSetup.TextColumns.SetCount(1);
                                        appParagraph2.Range.Bold = 1;
                                        appParagraph2.Range.Text = title.ToUpper();
                                        appParagraph2.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                                    }

                                    appParagraph.Range.Words.Last.InsertBreak(Word.WdBreakType.wdSectionBreakContinuous);

                                    if (examtype == "True/Identify" || examtype == "True/False" || examtype == "Identification")
                                    {
                                        appParagraph2.Range.PageSetup.TextColumns.SetCount(1);
                                        appParagraph2.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                                    }

                                    else
                                    {
                                        appParagraph.Range.PageSetup.TextColumns.SetCount(2);
                                        appParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                }
                            }

                            else if (lastexamtype != "Essay")
                            {
                                if (examtype == "Essay")
                                {
                                    title = examtype;
                                    appParagraph2.Range.Words.Last.InsertBreak(Word.WdBreakType.wdSectionBreakContinuous);
                                    appParagraph2.Range.PageSetup.TextColumns.SetCount(1);
                                    appParagraph2.Range.Bold = 1;
                                    appParagraph2.Range.Text = title.ToUpper();
                                    appParagraph2.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                                    appParagraph.Range.Words.Last.InsertBreak(Word.WdBreakType.wdSectionBreakContinuous);
                                    appParagraph.Range.PageSetup.TextColumns.SetCount(1);
                                    appParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                                }

                                else if (lastexamtype != examtype)
                                {
                                    if (lastexamtype != examtype)
                                    {
                                        title = examtype;
                                        appParagraph2.Range.Words.Last.InsertBreak(Word.WdBreakType.wdSectionBreakContinuous);
                                        appParagraph2.Range.PageSetup.TextColumns.SetCount(1);
                                        appParagraph2.Range.Bold = 1;
                                        appParagraph2.Range.Text = title.ToUpper();
                                        appParagraph2.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                                    }

                                    appParagraph.Range.Words.Last.InsertBreak(Word.WdBreakType.wdSectionBreakContinuous);
                                    if (examtype == "True/Identify" || examtype == "True/False" || examtype == "Identification")
                                    {
                                        appParagraph2.Range.PageSetup.TextColumns.SetCount(1);
                                        appParagraph2.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                                    }

                                    else
                                    {
                                        appParagraph.Range.PageSetup.TextColumns.SetCount(2);
                                        appParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                                    }
                                }
                            }

                            appParagraph.Range.Text = underline + numberstring + ". " + questions + choices;
                            appParagraph.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                            lastexamtype = examtype;
                        }

                        Word.Paragraph appParagraph1;
                        appParagraph1 = appDoc.Paragraphs.Add();
                        appParagraph1.Range.Words.Last.InsertBreak(Word.WdBreakType.wdSectionBreakContinuous);
                        appParagraph1.Range.PageSetup.TextColumns.SetCount(1);
                        appParagraph1.Range.Text = "\n\n";
                        appParagraph1.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                        object Password = "";

                        connected = new MySqlConnection(con);
                        cmd.CommandText = "Select * from administrator where username ='" + username + "'";
                        cmd.Connection = connected;
                        connected.Open();
                        MySqlDataReader dr6 = cmd.ExecuteReader();
                        while (dr6.Read())
                        {
                            Password = dr6["password"].ToString(); ;
                        }

                        connected.Close();
                        app.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                        object fileName = "" + ExportExam.Text.Replace("-", "") + "_" + ExportSubject.Text.Replace(" ", "") + "_" + schoolyear + "";
                        appDoc.SaveAs(ref fileName, ref appMissing, ref appMissing, ref Password);
                        object filePath = app.ActiveDocument.Path + "\\" + fileName + ".docx";
                        appDoc.Close();
                        MessageBox.Show("Document Export Successfully. The document password is also your password in this system.");
                        Process.Start(filePath.ToString());
                        logger = "Exported a Word File: " + fileName.ToString() + ".docx";
                        Log();
                    }
                }
            }

            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Questions_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger = "Exit Application";
            Log();
        }

        private void MaxItemIdent_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void PassingScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void ScoreEnum_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void MaxItemEnum_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void MinItemEnum_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void Enumbtn_Click(object sender, EventArgs e)
        {
            CheckEnum.Visible = true;
            examtype = "Enumeration";
            HideShow();
        }

        private void MinItemIdent_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void ScoreIdent_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void ScoreEssay_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void MaxItemEssay_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void MinItemEssay_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void ScoreMC_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void MinItemMC_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void MaxItemMC_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
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

        private void DateTimeDone_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                dateslot = DateSlot.Value.ToString("MM/dd/yyyy");
                timeslot = TimeSlot.Value.ToString("hh:mm tt");
                endslot = EndSlot.Value.ToString("hh:mm tt");

                if (PassingScore.Text != "")
                {
                    if (totalitems > int.Parse(PassingScore.Text) || totalitems == int.Parse(PassingScore.Text))
                    {
                        try
                        {
                            connected.Open();
                            cmd.CommandText = "Update `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` set `PassingScore` = " +
                                               "'" + PassingScore.Text + "'";
                            cmd.Connection = connected;
                            cmd.ExecuteNonQuery();
                            connected.Close();

                            connected = new MySqlConnection(con);
                            connected.Open();
                            cmd.CommandText = "select count(*) from information_schema.tables where table_name='schedule_" + exam.Replace("-", "") + "_" + schoolyear + "' AND TABLE_SCHEMA='examination'";
                            Console.WriteLine(1);
                            cmd.Connection = connected;
                            string count = cmd.ExecuteScalar().ToString();
                            
                            connected.Close();

                            if (count == "0")
                            {
                                connected = new MySqlConnection(con);
                                connected.Open();
                                cmd.CommandText = "create table `schedule_" + exam.Replace("-", "") + "_" + schoolyear + "` ( `subject` VARCHAR(99) NOT NULL ,  " +
                                    "`date` VARCHAR(99) NOT NULL,  `time` VARCHAR(99) NOT NULL , `endtime` VARCHAR(99) NOT NULL, `completetime` VARCHAR(99) NOT NULL" +
                                    ", `completeendtime` VARCHAR(99) NOT NULL)";
                                cmd.Connection = connected;
                                cmd.ExecuteNonQuery();
                                connected.Close();

                                connected = new MySqlConnection(con);
                                cmd.CommandText = "INSERT INTO `schedule_" + exam.Replace("-", "") + "_" + schoolyear + "` (`subject`, `date`, `time`, `endtime`, `completetime`" +
                                      ", `completeendtime`) VALUES('" + subject + "', '" + dateslot + "', '" + timeslot + "', '" + endslot + "', " +
                                      "'" + timeslot + " " + dateslot + "', '" + endslot + " " + dateslot + "')";
                                connected.Open();
                                cmd.Connection = connected;
                                cmd.ExecuteNonQuery();
                                connected.Close();
                            }
                            else if (count == "1")
                            {
                                connected = new MySqlConnection(con);
                                connected.Open();
                                cmd.CommandText = "select count(*) from `schedule_" + exam.Replace("-", "") + "_" + schoolyear + "" +
                                    "` where subject ='" + subject + "'";
                                cmd.Connection = connected;
                                string count1 = cmd.ExecuteScalar().ToString();
                                connected.Close();

                                if (count1 == "1")
                                {
                                    connected = new MySqlConnection(con);
                                    cmd.CommandText = "Update `schedule_" + exam.Replace("-", "") + "_" + schoolyear + "` set `Date` = " +
                                       "'" + dateslot + "', `time` =  '" + timeslot + "' , `endtime` =  '" + endslot + "'" +
                                       ", `completetime` =  '" + timeslot + " " + dateslot + "', `completeendtime` = '" + endslot + " " + dateslot + "'" +
                                       " where subject = '" + subject + "'";
                                    connected.Open();
                                    cmd.Connection = connected;
                                    cmd.ExecuteNonQuery();
                                    connected.Close();
                                }

                                else if (count1 == "0")
                                {
                                    connected = new MySqlConnection(con);
                                    cmd.CommandText = "INSERT INTO `schedule_" + exam.Replace("-", "") + "_" + schoolyear + "` (`subject`, `date`, `time`, `endtime`, `completetime`" +
                                        ", `completeendtime`) VALUES('" + subject + "', '" + dateslot + "', '" + timeslot + "', '" + endslot + "', " +
                                        "'" + timeslot + " " + dateslot + "', '" + endslot + " " + dateslot + "')";
                                    connected.Open();
                                    cmd.Connection = connected;
                                    cmd.ExecuteNonQuery();
                                    connected.Close();
                                }
                            }
                        }

                        catch (Exception err)
                        {
                            MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if (how == "create")
                        {
                            logger = "Finish creating an examination: " + CreateExam.Text + " Examination of " + CreateSubject.Text + ".";
                            MessageBox.Show("Examination created.");
                        }

                        else if (how == "edit")
                        {
                            logger = "Finish overwriting an examination: " + CreateExam.Text + " Examination of " + CreateSubject.Text + ".";
                            MessageBox.Show("Examination overwrote.");
                        }

                        CreateSubject.TabStop = true;
                        CreateExam.TabStop = true;
                        TI.TabStop = true; 
                        EditSubject.TabStop = true;
                        EditExam.TabStop = true;

                        Log();
                        how = "";
                        PassingScore.Text = "";
                        DateTimePanel.Hide();
                        StartPanel.Show();
                        Export.Show();
                        UpperPanel.Show();
                    }

                    else if (int.Parse(PassingScore.Text) > totalitems)
                    {
                        MessageBox.Show("Your passing score is higher than your total items. Your total items is " + totalitems + " only.");
                    }
                }

                else if (PassingScore.Text == "")
                {
                    MessageBox.Show("Please input the passing score.");
                }
            }
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

        private void Finish()
        {
            int TIi = totalitems;

            if (buttonstats == "next" && i == id)
            {
                MaxItemMC.Text = "";
                MaxItemTF.Text = "";
                MaxItemTI.Text = "";
                MaxItemIdent.Text = "";
                MaxItemEssay.Text = "";
                MaxItemEnum.Text = "";
                Clear();
            }

            if (int.Parse(ScoreMC.Text) > TIi || int.Parse(MinItemMC.Text) > TIi ||
            int.Parse(ScoreEssay.Text) > TIi || int.Parse(MinItemEssay.Text) > TIi ||
            int.Parse(ScoreTF.Text) > TIi || int.Parse(MinItemTF.Text) > TIi ||
            int.Parse(ScoreTI.Text) > TIi || int.Parse(MinItemTI.Text) > TIi ||
            int.Parse(ScoreIdent.Text) > TIi || int.Parse(MinItemIdent.Text) > TIi ||
            int.Parse(ScoreEnum.Text) > TIi || int.Parse(MinItemEnum.Text) > TIi)
            {
                int iddb = id - 1;

                while (iddb < i)
                {
                    connected = new MySqlConnection(con);
                    connected.Open();
                    cmd.CommandText = "DELETE FROM `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` WHERE " +
                        "`id` = '" + i + "';";
                    cmd.Connection = connected;
                    cmd.ExecuteReader();
                    connected.Close();
                    i--;
                }

                if (how == "create")
                {
                    TimeSlot.Value.ToString(DateTime.Now.ToString("hh:mm tt"));
                    EndSlot.Value.ToString(DateTime.Now.ToString("hh:mm tt"));
                    DateSlot.Value.ToString(DateTime.Now.ToString("MM/dd/yyyy"));
                }

                else if (how == "edit")
                {
                    string timeslotdb = "", endtimeslotdb = "", datedb = "";

                    cmd.CommandText = "select * from `schedule_" + exam.Replace("-", "") + "_" + schoolyear + "` where subject = '" + subject + "'";
                    cmd.Connection = connected;
                    connected.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        timeslotdb = (dr["time"].ToString());
                        endtimeslotdb = (dr["endtime"].ToString());
                        datedb = (dr["date"].ToString());
                    }

                    ShowNum();
                    connected.Close();

                    TimeSlot.Value = Convert.ToDateTime(timeslotdb);
                    EndSlot.Value = Convert.ToDateTime(endtimeslotdb);
                    DateSlot.Value = Convert.ToDateTime(datedb);
                }

                DateTimePanel.Show();
                Identification.Hide();
                MultipleChoice.Hide();
                TrueFalse.Hide();
                CheckEnum.Hide();
                TrueIdentify.Hide();
                Enumeration.Hide();
                Types.Hide();
                Item.Hide();
                Essential.Hide();
                Essay.Hide();
                TI.Text = "";
                CreateExam.SelectedItem = -1;
                EditExam.SelectedItem = -1;
                CheckEnum.Visible = false;
            }


            else if (examtype == "Enumeration")
            {
                CheckEnum.Visible = true;
                Fix.Checked = false;
            }

            else if (examtype != "Enumeration")
            {
                CheckEnum.Visible = false;
                Fix.Checked = false;
            }
        }

        private void ShowNum()
        {
            if (item2 == "Multiple Score")
                MI();

            else if (item2 == "Single Score")
                SI();

            if (item == "Multiple Score" || item == "Single Score")
            {
                lastnumber = lastnumber + 1;

                if ((i != id && how == "create") || (i != id && how == "edit"))
                {
                    int MaxNumber = lastnumber + (points - 1);
                    ScoreMC.Text = lastnumber.ToString();
                    ScoreTF.Text = lastnumber.ToString();
                    ScoreTI.Text = lastnumber.ToString();
                    ScoreIdent.Text = lastnumber.ToString();
                    ScoreEssay.Text = lastnumber.ToString();
                    ScoreEnum.Text = lastnumber.ToString();
                    MinItemMC.Text = lastnumber.ToString();
                    MinItemTF.Text = lastnumber.ToString();
                    MinItemTI.Text = lastnumber.ToString();
                    MinItemEssay.Text = lastnumber.ToString();
                    MinItemIdent.Text = lastnumber.ToString();
                    MinItemEnum.Text = lastnumber.ToString();

                    if (item2 == "Multiple Score")
                    {
                        MaxItemMC.Text = MaxNumber.ToString();
                        MaxItemTF.Text = MaxNumber.ToString();
                        MaxItemTI.Text = MaxNumber.ToString();
                        MaxItemIdent.Text = MaxNumber.ToString();
                        MaxItemEssay.Text = MaxNumber.ToString();
                        MaxItemEnum.Text = MaxNumber.ToString();
                        item = "Multiple Score";
                    }

                    else if (item2 == "Single Score")
                    {
                        MaxItemMC.Text = "";
                        MaxItemTF.Text = "";
                        MaxItemTI.Text = "";
                        MaxItemIdent.Text = "";
                        MaxItemEssay.Text = "";
                        MaxItemEnum.Text = "";
                        item = "Single Score";
                    }
                }

                else if ((i == id && how == "create") || (i == id && how == "edit"))
                {
                    ScoreMC.Text = lastnumber.ToString();
                    ScoreTF.Text = lastnumber.ToString();
                    ScoreTI.Text = lastnumber.ToString();
                    ScoreIdent.Text = lastnumber.ToString();
                    ScoreEssay.Text = lastnumber.ToString();
                    ScoreEnum.Text = lastnumber.ToString();
                    MinItemMC.Text = lastnumber.ToString();
                    MinItemTF.Text = lastnumber.ToString();
                    MinItemTI.Text = lastnumber.ToString();
                    MinItemEssay.Text = lastnumber.ToString();
                    MinItemIdent.Text = lastnumber.ToString();
                    MinItemEnum.Text = lastnumber.ToString();

                    if (item2 == "Single Score")
                    {
                        lastnumber = lastnumber + 1;
                        MaxItemMC.Text = lastnumber.ToString();
                        MaxItemTF.Text = lastnumber.ToString();
                        MaxItemTI.Text = lastnumber.ToString();
                        MaxItemIdent.Text = lastnumber.ToString();
                        MaxItemEssay.Text = lastnumber.ToString();
                        MaxItemEnum.Text = lastnumber.ToString();
                        item = "Single Score";
                    }

                    else if (item2 == "Multiple Score")
                    {
                        lastnumberdb = lastnumber + 1;
                        MaxItemMC.Text = lastnumberdb.ToString();
                        MaxItemTF.Text = lastnumberdb.ToString();
                        MaxItemTI.Text = lastnumberdb.ToString();
                        MaxItemIdent.Text = lastnumberdb.ToString();
                        MaxItemEssay.Text = lastnumberdb.ToString();
                        MaxItemEnum.Text = lastnumberdb.ToString();
                        item = "Multiple Score";
                    }
                }
            }

            else
            {
                ScoreMC.Text = firstnumberdb.ToString();
                ScoreTF.Text = firstnumberdb.ToString();
                ScoreTI.Text = firstnumberdb.ToString();
                ScoreIdent.Text = firstnumberdb.ToString();
                ScoreEssay.Text = firstnumberdb.ToString();
                ScoreEnum.Text = firstnumberdb.ToString();
                MinItemMC.Text = firstnumberdb.ToString();
                MinItemTF.Text = firstnumberdb.ToString();
                MinItemTI.Text = firstnumberdb.ToString();
                MinItemEssay.Text = firstnumberdb.ToString();
                MinItemEnum.Text = firstnumberdb.ToString();
                MinItemIdent.Text = firstnumberdb.ToString();
                MaxItemMC.Text = lastnumberdb.ToString();
                MaxItemTF.Text = lastnumberdb.ToString();
                MaxItemTI.Text = lastnumberdb.ToString();
                MaxItemIdent.Text = lastnumberdb.ToString();
                MaxItemEssay.Text = lastnumberdb.ToString();
                MaxItemEnum.Text = lastnumberdb.ToString();

                if (item2 == "Multiple Score")
                    item = "Multiple Score";

                else if (item2 == "Single Score")
                    item = "Single Score";
            }
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

        private void Display()
        {
            cmd.CommandText = "select * from `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` where id = '" + id + "'";
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
                answer = (dr["answer"].ToString());
                fix = (dr["fixenumeration"].ToString());
                points = (Int32.Parse(dr["points"].ToString()));
                totalitems = (Int32.Parse(dr["totalitems"].ToString()));
                examtype = (dr["questiontype"].ToString());
                item2 = (dr["itemtype"].ToString());
                name = (dr["preparedby"].ToString());
            }

            ShowNum();
            connected.Close();
            CheckEnum.Visible = false;
            Fix.Checked = false;

            if (examtype == "Multiple Choice")
            {
                QuestionMC.Text = questions;
                AMC.Text = a;
                BMC.Text = b;
                CMC.Text = c;
                DMC.Text = d;

                if (answer == a)
                    AAnsMC.Checked = true;

                else if (answer == b)
                    BAnsMC.Checked = true;

                else if (answer == c)
                    CAnsMC.Checked = true;

                else if (answer == d)
                    BAnsMC.Checked = true;
            }

            else if (examtype == "True/False")
            {
                QuestionTF.Text = questions;

                if (answer == "True")
                    TFTrue.Checked = true;

                else if (answer == "False")
                    TFFalse.Checked = true;
            }

            else if (examtype == "True/Identify")
            {
                QuestionTI.Text = questions;

                if (answer == "True")
                    TITrue.Checked = true;

                else if (answer != "True")
                    TIFalse.Text = answer;
            }

            else if (examtype == "Identification")
            {
                QuestionIdent.Text = questions;
                AnswerIdent.Text = answer;
            }

            else if (examtype == "Essay")
                QuestionEssay.Text = questions;

            else if (examtype == "Enumeration")
            {
                QuestionEnum.Text = questions;
                CheckEnum.Visible = true;

                if (fix == "Yes")
                    Fix.Checked = true;

                else if (fix != "Yes")
                    Fix.Checked = false;

                EnumA.Text = enuma;
                EnumB.Text = enumb;
                EnumC.Text = enumc;
                EnumD.Text = enumd;
                EnumE.Text = enume;
            }

            HideShow();
        }

        private void MI()
        {
            MultipleScoreTI.Show();
            MultipleScoreMC.Show();
            MultipleScoreTF.Show();
            MultipleScoreIdent.Show();
            MultipleScoreEssay.Show();
            MultipleScoreEnum.Show();
            SingleScoreMC.Hide();
            SingleScoreTF.Hide();
            SingleScoreTI.Hide();
            SingleScoreIdent.Hide();
            SingleScoreEssay.Hide();
            SingleScoreEnum.Show();
        }

        private void SI()
        {
            MultipleScoreTI.Hide();
            MultipleScoreMC.Hide();
            MultipleScoreTF.Hide();
            MultipleScoreIdent.Hide();
            MultipleScoreEssay.Hide();
            MultipleScoreEnum.Hide();
            SingleScoreMC.Show();
            SingleScoreTF.Show();
            SingleScoreTI.Show();
            SingleScoreIdent.Show();
            SingleScoreEssay.Show();
            SingleScoreEnum.Show();
        }

        private int NumChecker(int min, int max)
        {
            if (min > max && (item == "Multiple Score"))
            {
                MessageBox.Show("Your first number is higher than the second number.");
                return 0;
            }

            else if (max > totalitems)
            {
                MessageBox.Show("Your total items is " + totalitems + " only.");
                return 1;
            }

            else if (min == max && (item == "Multiple Score"))
            {
                MessageBox.Show("Your first number and second number are the same.");
                return 3;
            }

            else
            {
                return 4;
            }
        }

        private void Clear()
        {
            DMC.Text = "";
            CMC.Text = "";
            BMC.Text = "";
            AMC.Text = "";
            EnumD.Text = "";
            EnumC.Text = "";
            EnumB.Text = "";
            EnumA.Text = "";
            EnumE.Text = "";
            QuestionEnum.Text = "";
            QuestionMC.Text = "";
            QuestionTF.Text = "";
            QuestionTI.Text = "";
            QuestionIdent.Text = "";
            TIFalse.Text = "";
            QuestionEssay.Text = "";
            AnswerIdent.Text = "";
            TFFalse.Checked = false;
            TFTrue.Checked = false;
            TITrue.Checked = false;
            AAnsMC.Checked = false;
            BAnsMC.Checked = false;
            CAnsMC.Checked = false;
            DAnsMC.Checked = false;
        }

        private void SubjectLoad()
        {
            int numberofsubject;
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
                    EditSubject.Properties.Items.Add(dr["subject" + addtb + ""].ToString());
                    CreateSubject.Properties.Items.Add(dr["subject" + addtb + ""].ToString());
                    ExportSubject.Properties.Items.Add(dr["subject" + addtb + ""].ToString());

                    if (addtb == 1)
                    {
                        EditSubject.Text = dr["subject" + addtb + ""].ToString();
                        CreateSubject.Text = dr["subject" + addtb + ""].ToString();
                        ExportSubject.Text = dr["subject" + addtb + ""].ToString();
                    }

                    else
                    {
                        EditSubject.SelectedIndex = -1;
                        CreateSubject.SelectedIndex = -1;
                        ExportSubject.SelectedIndex = -1;
                    }

                } while (numberofsubject > addtb);

            }
            connected.Close();
            EditSubject.Enabled = true;
        }

        public void Need(string un, string Gname, string Permission, string sy)
        {
            username = un;
            name = Gname;
            permission = Permission;
            schoolyear = sy;
        }

        private void CreateTable()
        {
            UpperPanel.Hide();
            logger = "Creating an examination: " + CreateExam.Text + " Examination of " + CreateSubject.Text + ".";
            Log();
            connected = new MySqlConnection(con);
            i = 1;
            connected.Open();
            firstnumber = 1;
            cmd.CommandText = "create table `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` (" +
                " ID INT NOT NULL, Number INT NULL, LastNumber INT NULL, Questions TEXT NOT NULL, A TEXT NOT NULL," +
                " B TEXT NOT NULL, C TEXT NOT NULL, D TEXT NOT NULL, EnumerationA TEXT NOT NULL, EnumerationB TEXT NOT NULL, " +
                "EnumerationC TEXT NOT NULL, EnumerationD TEXT NOT NULL, EnumerationE TEXT NOT NULL, FixEnumeration VARCHAR(3) NOT NULL," +
                " Answer TEXT NULL, Points INT NOT NULL, TotalItems INT NOT NULL, PassingScore INT NOT NULL, QuestionType VARCHAR(255) NOT NULL," +
                " ItemType VARCHAR(255) NOT NULL, PreparedBy VARCHAR(255) NOT NULL, PRIMARY KEY(ID));";
            cmd.Connection = connected;
            cmd.ExecuteReader();
            connected.Close();
            Types.Show();
            Item.Show();
            Essential.Show();
            DateTimePanel.Hide();
            CreatePanel.Hide();
            MinItemEssay.Text = "1";
            MinItemIdent.Text = "1";
            MinItemTI.Text = "1";
            MinItemTF.Text = "1";
            MinItemMC.Text = "1";
            MinItemEnum.Text = "1";
            ScoreMC.Text = "1";
            ScoreIdent.Text = "1";
            ScoreTI.Text = "1";
            ScoreTF.Text = "1";
            ScoreEssay.Text = "1";
            ScoreEnum.Text = "1";
        }

        public void MCstart(string AnsMC)
        {
            if ((i == id && how == "create") || (i == id && how == "edit"))
            {
                connected = new MySqlConnection(con);
                connected.Open();
                cmd.CommandText = "INSERT INTO `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` (`ID`, `Number`, `LastNumber`," +
                    "`Questions`, `A`, `B`, `C`, `D`, `Answer`, `Points`, `TotalItems`, `QuestionType`, `ItemType`, `PreparedBy`) VALUES('" + id
                    + "', '" + firstnumber + "',  '" + lastnumber + "', '" + QuestionMC.Text + "','"
                    + AMC.Text + "','" + BMC.Text + "','" + CMC.Text + "','" + DMC.Text + "','" + AnsMC + "','" + points + "','" + totalitems + "','"
                    + examtype + "','" + item + "','" + name + "')";
                cmd.Connection = connected;
                cmd.ExecuteNonQuery();
                i++;
                id++;
                MessageBox.Show("Saved");
                connected.Close();
                Display();
                Finish();
                MaxItemMC.Text = "";
                MaxItemTF.Text = "";
                MaxItemTI.Text = "";
                MaxItemIdent.Text = "";
                MaxItemEssay.Text = "";
                MaxItemEnum.Text = "";
                AAnsMC.Checked = false;
                BAnsMC.Checked = false;
                CAnsMC.Checked = false;
                DAnsMC.Checked = false;
                TFTrue.Checked = false;
                TFFalse.Checked = false;
                TITrue.Checked = false;
                Clear();
            }

            else if ((i != id && how == "create") || (i != id && how == "edit"))
            {
                
                connected = new MySqlConnection(con);
                connected.Open();
                cmd.CommandText = "Update `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` set `Number` = " +
                    "'" + firstnumber + "', `LastNumber` = '" + lastnumber + "', `Questions` = '" + QuestionMC.Text + "' " +
                    ", `A` = '" + AMC.Text + "', `B` = '" + BMC.Text + "', `C` = '" + CMC.Text + "', `D` = '" + DMC.Text + "'" +
                    ", `Answer` = '" + AnsMC + "', `Points` = '" + points + "', `TotalItems` = '" + totalitems + "'" +
                    ", `QuestionType` = '" + examtype + "', `ItemType` = '" + item + "', `PreparedBy` = '" + name + "'" +
                    " where id = '" + id + "'";
                cmd.Connection = connected;
                cmd.ExecuteNonQuery();
                id++;
                connected.Close();
                MessageBox.Show("Updated");
                Display();
                Finish();
            }
        }

        public void StartInsert()
        {
            try
            {
                if (examtype == "Multiple Choice")
                {
                    if (item == "Multiple Score" && MaxItemMC.Text == "")
                        MessageBox.Show("Please input a second number");

                    else
                    {
                        if (item2 == "Multiple Score")
                        {
                            firstnumber = int.Parse(MinItemMC.Text);
                            ScoreMC.Text = firstnumber.ToString();

                            if (item == "Multiple Score")
                            {
                                lastnumber = int.Parse(MaxItemMC.Text);
                                points = (lastnumber - firstnumber) + 1;
                            }

                            else if (item == "Single Score")
                            {
                                lastnumber = firstnumber;
                                points = 1;
                            }
                        }

                        else if (item2 == "Single Score")
                        {
                            firstnumber = int.Parse(ScoreMC.Text);
                            MinItemMC.Text = firstnumber.ToString();

                            if (item == "Single Score")
                            {
                                lastnumber = firstnumber;
                                points = 1;
                            }

                            else if (item == "Multiple Score")
                            {
                                lastnumber = int.Parse(MaxItemMC.Text);
                                points = (lastnumber - firstnumber) + 1;
                            }
                        }

                        int numcheck = NumChecker(firstnumber, lastnumber);

                        if (numcheck == 4)
                        {
                            if (AAnsMC.Checked)
                            {
                                AnsMC = AMC.Text.ToString();
                                MCstart(AnsMC);
                            }

                            else if (BAnsMC.Checked)
                            {
                                AnsMC = BMC.Text.ToString();
                                MCstart(AnsMC);
                            }

                            else if (CAnsMC.Checked)
                            {
                                AnsMC = CMC.Text.ToString();
                                MCstart(AnsMC);
                            }

                            else if (DAnsMC.Checked)
                            {
                                AnsMC = DMC.Text.ToString();
                                MCstart(AnsMC);
                            }

                            else
                                MessageBox.Show("Choose an answer");
                        }
                    }

                }

                else if (examtype == "True/False")
                {
                    if (item == "Multiple Score" && MaxItemTF.Text == "")
                        MessageBox.Show("Please input a second number");

                    else
                    {
                        if (item2 == "Multiple Score")
                        {
                            firstnumber = int.Parse(MinItemTF.Text);
                            ScoreTF.Text = firstnumber.ToString();

                            if (item == "Multiple Score")
                            {
                                lastnumber = int.Parse(MaxItemTF.Text);
                                points = (lastnumber - firstnumber) + 1;
                            }

                            else if (item == "Single Score")
                            {
                                lastnumber = firstnumber;
                                points = 1;
                            }
                        }

                        else if (item2 == "Single Score")
                        {
                            firstnumber = int.Parse(ScoreTF.Text);
                            MinItemTF.Text = firstnumber.ToString();

                            if (item == "Single Score")
                            {
                                lastnumber = firstnumber;
                                points = 1;
                            }

                            else if (item == "Multiple Score")
                            {
                                lastnumber = int.Parse(MaxItemTF.Text);
                                points = (lastnumber - firstnumber) + 1;
                            }
                        }

                        if (TFTrue.Checked)
                            ans = "True";

                        else if (TFFalse.Checked)
                            ans = "False";

                        int numcheck = NumChecker(firstnumber, lastnumber);

                        if (numcheck == 4)
                        {
                            if ((i == id) && (how == "create" || how == "edit"))
                            {
                                connected = new MySqlConnection(con);
                                connected.Open();
                                cmd.CommandText = "INSERT INTO `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` (`ID`, `Number`, " +
                                "`LastNumber`, `Questions`,  `Answer`, `Points`, `TotalItems`, `QuestionType`, `ItemType`, `PreparedBy`) " +
                                "VALUES('" + id + "', '" + firstnumber + "', '" + lastnumber + "','" + QuestionTF.Text + "','" + ans + "','" +
                                points + "', '" + totalitems + "','" + examtype + "','" + item + "','" + name + "')";
                                cmd.Connection = connected;
                                cmd.ExecuteNonQuery();
                                i++;
                                id++;
                                MessageBox.Show("Saved");
                                connected.Close();
                                Display();
                                Finish();
                                MaxItemMC.Text = "";
                                MaxItemTF.Text = "";
                                MaxItemTI.Text = "";
                                MaxItemIdent.Text = "";
                                MaxItemEssay.Text = "";
                                MaxItemEnum.Text = "";
                                AAnsMC.Checked = false;
                                BAnsMC.Checked = false;
                                CAnsMC.Checked = false;
                                DAnsMC.Checked = false;
                                TFTrue.Checked = false;
                                TFFalse.Checked = false;
                                TITrue.Checked = false;
                                Clear();
                            }
                            else if ((i != id) && (how == "create" || how == "edit"))
                            {                                
                                connected = new MySqlConnection(con);
                                connected.Open();
                                cmd.CommandText = "Update `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` set `Number` = " +
                                    "'" + firstnumber + "', `LastNumber` = '" + lastnumber + "', `Questions` = '" + QuestionTF.Text + "' " +
                                    ", `Answer` = '" + ans + "', `Points` = '" + points + "', `TotalItems` = '" + totalitems + "'" +
                                    ", `QuestionType` = '" + examtype + "', `ItemType` = '" + item + "', `PreparedBy` = '" + name + "' " +
                                    "where id = '" + id + "'";
                                cmd.Connection = connected;
                                cmd.ExecuteNonQuery();
                                connected.Close();
                                id++;
                                MessageBox.Show("Updated");
                                Display();
                                Finish();
                            }
                        }
                    }
                }

                else if (examtype == "True/Identify")
                {
                    if (item == "Multiple Score" && MaxItemTI.Text == "")
                        MessageBox.Show("Please input a second number");

                    else
                    {
                        if (TITrue.Checked == false && TIFalse.Text == "")
                            MessageBox.Show("Choose/Type your answer.");

                        else if (TITrue.Checked == false && TIFalse.Enabled == true && TIFalse.Text == "")
                            MessageBox.Show("Type your answer.");

                        else
                        {
                            if (TITrue.Checked == true)
                                ans = "True";

                            else if (TITrue.Checked == false)
                                ans = TIFalse.Text.ToString();

                            if (item2 == "Multiple Score")
                            {
                                firstnumber = int.Parse(MinItemTI.Text);
                                ScoreTI.Text = firstnumber.ToString();

                                if (item == "Multiple Score")
                                {
                                    lastnumber = int.Parse(MaxItemTI.Text);
                                    points = (lastnumber - firstnumber) + 1;
                                }

                                else if (item == "Single Score")
                                {
                                    lastnumber = firstnumber;
                                    points = 1;
                                }
                            }

                            else if (item2 == "Single Score")
                            {
                                firstnumber = int.Parse(ScoreTI.Text);
                                MinItemTI.Text = firstnumber.ToString();

                                if (item == "Single Score")
                                {
                                    lastnumber = firstnumber;
                                    points = 1;
                                }

                                else if (item == "Multiple Score")
                                {
                                    lastnumber = int.Parse(MaxItemTI.Text);
                                    points = (lastnumber - firstnumber) + 1;
                                }
                            }

                            int numcheck = NumChecker(firstnumber, lastnumber);

                            if (numcheck == 4)
                            {
                                if ((i == id) && (how == "create" || how == "edit"))
                                {
                                    connected = new MySqlConnection(con);
                                    connected.Open();
                                    cmd.CommandText = "INSERT INTO `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` (`ID`, " +
                                    "`Number`, `LastNumber`, `Questions`, `Answer`, `Points`, `TotalItems`, `QuestionType`, `ItemType`, " +
                                    "`PreparedBy`) VALUES('" + id + "', '" + firstnumber + "', '" + lastnumber + "','" + QuestionTI.Text +
                                    "','" + ans + "','" + points + "','" + totalitems + "','" + examtype + "','" + item + "','" + name + "')";
                                    cmd.Connection = connected;
                                    cmd.ExecuteNonQuery();
                                    i++;
                                    id++;
                                    MessageBox.Show("Saved");
                                    connected.Close();
                                    Display();
                                    Finish();
                                    MaxItemMC.Text = "";
                                    MaxItemTF.Text = "";
                                    MaxItemTI.Text = "";
                                    MaxItemIdent.Text = "";
                                    MaxItemEssay.Text = "";
                                    MaxItemEnum.Text = "";
                                    AAnsMC.Checked = false;
                                    BAnsMC.Checked = false;
                                    CAnsMC.Checked = false;
                                    DAnsMC.Checked = false;
                                    TFTrue.Checked = false;
                                    TFFalse.Checked = false;
                                    TITrue.Checked = false;
                                    Clear();
                                }

                                else if ((i != id) && (how == "create" || how == "edit"))
                                {
                                    
                                    connected = new MySqlConnection(con);
                                    connected.Open();
                                    cmd.CommandText = "Update `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` set `Number` = " +
                                        "'" + firstnumber + "', `LastNumber` = '" + lastnumber + "', `Questions` = '" + QuestionTI.Text + "' " +
                                        ", `Answer` = '" + ans + "', `Points` = '" + points + "', `TotalItems` = '" + totalitems + "'" +
                                        ", `QuestionType` = '" + examtype + "', `ItemType` = '" + item + "', `PreparedBy` = '" + name + "'" +
                                        " where id = '" + id + "'";
                                    cmd.Connection = connected;
                                    cmd.ExecuteNonQuery();
                                    connected.Close();
                                    id++;
                                    MessageBox.Show("Updated");
                                    Display();
                                    Finish();
                                }
                                TITrue.Checked = false;
                            }
                        }
                    }
                }

                else if (examtype == "Identification")
                {
                    if (item == "Multiple Score" && MaxItemIdent.Text == "")
                        MessageBox.Show("Please input a second number");

                    else
                    {
                        if (item2 == "Multiple Score")
                        {
                            firstnumber = int.Parse(MinItemIdent.Text);
                            ScoreIdent.Text = firstnumber.ToString();

                            if (item == "Multiple Score")
                            {
                                lastnumber = int.Parse(MaxItemIdent.Text);
                                points = (lastnumber - firstnumber) + 1;
                            }

                            else if (item == "Single Score")
                            {
                                lastnumber = firstnumber;
                                points = 1;
                            }
                        }

                        else if (item2 == "Single Score")
                        {
                            firstnumber = int.Parse(ScoreIdent.Text);
                            MinItemIdent.Text = firstnumber.ToString();

                            if (item == "Single Score")
                            {
                                lastnumber = firstnumber;
                                points = 1;
                            }

                            else if (item == "Multiple Score")
                            {
                                lastnumber = int.Parse(MaxItemIdent.Text);
                                points = (lastnumber - firstnumber) + 1;
                            }
                        }

                        int numcheck = NumChecker(firstnumber, lastnumber);

                        if (numcheck == 4)
                        {
                            if ((i == id) && (how == "create" || how == "edit"))
                            {
                                connected = new MySqlConnection(con);
                                connected.Open();
                                cmd.CommandText = "INSERT INTO `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` (`ID`, `Number`, `LastNumber`," +
                                "`Questions`, `Answer`, `Points`, `TotalItems`, `QuestionType`, `ItemType`, `PreparedBy`) " + "VALUES('" + id + "', '" + firstnumber
                                + "', '" + lastnumber + "','" + QuestionIdent.Text + "','" + AnswerIdent.Text + "', '" + points + "', '" + totalitems + "', " +
                                "'" + examtype + "', '" + item + "','" + name + "')";
                                cmd.Connection = connected;
                                cmd.ExecuteNonQuery();
                                i++;
                                id++;
                                MessageBox.Show("Saved");
                                connected.Close();
                                Display(); 
                                Finish();
                                MaxItemMC.Text = "";
                                MaxItemTF.Text = "";
                                MaxItemTI.Text = "";
                                MaxItemIdent.Text = "";
                                MaxItemEssay.Text = "";
                                MaxItemEnum.Text = "";
                                AAnsMC.Checked = false;
                                BAnsMC.Checked = false;
                                CAnsMC.Checked = false;
                                DAnsMC.Checked = false;
                                TFTrue.Checked = false;
                                TFFalse.Checked = false;
                                TITrue.Checked = false;
                                Clear();
                            }

                            else if ((i != id) && (how == "create" || how == "edit"))
                            {
                                
                                connected = new MySqlConnection(con);
                                connected.Open();
                                cmd.CommandText = "Update `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` set `Number` = " +
                                "'" + firstnumber + "', `LastNumber` = '" + lastnumber + "', `Questions` = '" + QuestionIdent.Text + "'" +
                                ", `Answer` = '" + AnswerIdent.Text + "', `Points` = '" + points + "', `TotalItems` = '" + totalitems + "', " +
                                "`QuestionType` = '" + examtype + "', `ItemType` = '" + item + "', `PreparedBy` = '" + name + "'" +
                                " where id = '" + id + "'";
                                cmd.Connection = connected;
                                cmd.ExecuteNonQuery();
                                connected.Close();
                                id++;
                                MessageBox.Show("Updated");
                                Display();
                                Finish();
                            }

                            string test;

                            if (Fix.Checked == true)
                                test = "Yes";

                            else
                                test = "No";

                            connected.Open();
                            cmd.CommandText = "Update `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` set `fixenumeration` = " +
                            "'" + test + "'";
                            cmd.Connection = connected;
                            cmd.ExecuteNonQuery();
                            connected.Close();
                        }
                    }
                }

                else if (examtype == "Essay")
                {
                    if (item == "Multiple Score" && MaxItemEssay.Text == "")
                        MessageBox.Show("Please input a second number");

                    else
                    {
                        if (item2 == "Multiple Score")
                        {
                            firstnumber = int.Parse(MinItemEssay.Text);
                            ScoreEssay.Text = firstnumber.ToString();

                            if (item == "Multiple Score")
                            {
                                lastnumber = int.Parse(MaxItemEssay.Text);
                                points = (lastnumber - firstnumber) + 1;
                            }

                            else if (item == "Single Score")
                            {
                                lastnumber = firstnumber;
                                points = 1;
                            }
                        }

                        else if (item2 == "Single Score")
                        {
                            firstnumber = int.Parse(ScoreEssay.Text);
                            MinItemEssay.Text = firstnumber.ToString();

                            if (item == "Single Score")
                            {
                                lastnumber = firstnumber;
                                points = 1;
                            }

                            else if (item == "Multiple Score")
                            {
                                lastnumber = int.Parse(MaxItemEssay.Text);
                                points = (lastnumber - firstnumber) + 1;
                            }
                        }

                        int numcheck = NumChecker(firstnumber, lastnumber);

                        if (numcheck == 4)
                        {
                            if ((i == id) && (how == "create" || how == "edit"))
                            {
                                connected = new MySqlConnection(con);
                                connected.Open();
                                cmd.CommandText = "INSERT INTO `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` (`ID`, `Number`, `LastNumber`," +
                                "`Questions`, `Answer`, `Points`, `TotalItems`, `QuestionType`, `ItemType`, `PreparedBy`) " + "VALUES('" + id + "', '" + firstnumber + "', '"
                                + lastnumber + "','" + QuestionEssay.Text + "', ' ' ,'" + points + "','" + totalitems + "','" + examtype + "','" + item + "','"
                                + name + "')";
                                cmd.Connection = connected;
                                cmd.ExecuteNonQuery();
                                i++;
                                id++;
                                MessageBox.Show("Saved");
                                connected.Close();
                                Display();
                                Finish();
                                MaxItemMC.Text = "";
                                MaxItemTF.Text = "";
                                MaxItemTI.Text = "";
                                MaxItemIdent.Text = "";
                                MaxItemEssay.Text = "";
                                MaxItemEnum.Text = "";
                                AAnsMC.Checked = false;
                                BAnsMC.Checked = false;
                                CAnsMC.Checked = false;
                                DAnsMC.Checked = false;
                                TFTrue.Checked = false;
                                TFFalse.Checked = false;
                                TITrue.Checked = false;
                                Clear();
                            }

                            else if ((i != id) && (how == "create" || how == "edit"))
                            {
                                
                                connected = new MySqlConnection(con);
                                connected.Open();
                                cmd.CommandText = "Update `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` set `Number` = " +
                                "'" + firstnumber + "', `LastNumber` = '" + lastnumber + "', `Questions` = '" + QuestionEssay.Text + "', `Answer` = ''," +
                                "`Points` = '" + points + "', `TotalItems` = '" + totalitems + "', `QuestionType` = '" + examtype + "', " +
                                "`ItemType` = '" + item + "', `PreparedBy` = '" + name + "', `PreparedBy` = '" + name + "' where id = '" + id + "'";
                                cmd.Connection = connected;
                                cmd.ExecuteNonQuery();
                                connected.Close();
                                id++;
                                MessageBox.Show("Updated");
                                Display();
                                Finish();
                            }
                        }
                    }
                }

                else if (examtype == "Enumeration")
                {
                    if (item == "Multiple Score" && MaxItemEnum.Text == "")
                        MessageBox.Show("Please input a second number");

                    else
                    {
                        if (item2 == "Multiple Score")
                        {
                            firstnumber = int.Parse(MinItemEnum.Text);
                            ScoreEnum.Text = firstnumber.ToString();

                            if (item == "Multiple Score")
                            {
                                lastnumber = int.Parse(MaxItemEnum.Text);
                                points = (lastnumber - firstnumber) + 1;
                            }

                            else if (item == "Single Score")
                            {
                                lastnumber = firstnumber;
                                points = 1;
                            }
                        }

                        else if (item2 == "Single Score")
                        {
                            firstnumber = int.Parse(ScoreEnum.Text);
                            MinItemEnum.Text = firstnumber.ToString();

                            if (item == "Single Score")
                            {
                                lastnumber = firstnumber;
                                points = 1;
                            }

                            else if (item == "Multiple Score")
                            {
                                lastnumber = int.Parse(MaxItemEnum.Text);
                                points = (lastnumber - firstnumber) + 1;
                            }
                        }

                        int numcheck = NumChecker(firstnumber, lastnumber);

                        if (numcheck == 4)
                        {
                            if (Fix.Checked == true)
                                fix = "Yes";

                            else
                                fix = "No";

                            if ((i == id) && (how == "create" || how == "edit"))
                            {
                                connected = new MySqlConnection(con);
                                connected.Open();
                                cmd.CommandText = "INSERT INTO `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` (`ID`, `Number`, `LastNumber`," +
                                "`Questions`, `EnumerationA`, `EnumerationB`, `EnumerationC`, `EnumerationD`, `EnumerationE`, " +
                                "`Points`, `TotalItems`, `QuestionType`, `ItemType`, `PreparedBy`, `FixEnumeration`) " + "VALUES('" + id + "', '" + firstnumber + "', '"
                                + lastnumber + "','" + QuestionEnum.Text + "', '" + EnumA.Text + "', '" + EnumB.Text + "', '" + EnumC.Text + "', '" + 
                                EnumD.Text + "', '" + EnumE.Text + "','" + points + "','" + totalitems + "','" + examtype + "','" + item + "','"
                                + name + "','" + fix + "')";
                                cmd.Connection = connected;
                                cmd.ExecuteNonQuery();
                                i++;
                                id++;
                                MessageBox.Show("Saved");
                                connected.Close();
                                Display();
                                Finish();
                                MaxItemMC.Text = "";
                                MaxItemTF.Text = "";
                                MaxItemTI.Text = "";
                                MaxItemIdent.Text = "";
                                MaxItemEssay.Text = "";
                                MaxItemEnum.Text = "";
                                AAnsMC.Checked = false;
                                BAnsMC.Checked = false;
                                CAnsMC.Checked = false;
                                DAnsMC.Checked = false;
                                TFTrue.Checked = false;
                                TFFalse.Checked = false;
                                TITrue.Checked = false;
                                Clear();
                            }

                            else if ((i != id) && (how == "create" || how == "edit"))
                            {
                                
                                connected = new MySqlConnection(con);
                                connected.Open();
                                cmd.CommandText = "Update `" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` set `Number` = " +
                                "'" + firstnumber + "', `LastNumber` = '" + lastnumber + "', `Questions` = '" + QuestionEnum.Text + "', `Answer` = ''," +
                                "`Points` = '" + points + "', `TotalItems` = '" + totalitems + "', `QuestionType` = '" + examtype + "', " +
                                "`ItemType` = '" + item + "', `PreparedBy` = '" + name + "', `EnumerationA` = '" + EnumA.Text + "', `EnumerationB` = '" + EnumB.Text
                                + "', `EnumerationC` = '" + EnumC.Text + "', `EnumerationD` = '" + EnumD.Text + "', `EnumerationE` = '" + EnumE.Text + "'" +
                                ", `FixEnumeration` = '" + fix + "' where id = '" + id + "'";
                                cmd.Connection = connected;
                                cmd.ExecuteNonQuery();
                                connected.Close();
                                id++;
                                MessageBox.Show("Updated");
                                Display();
                                Finish();
                            }

                            fix = "No";
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Verify()
        {
            connected = new MySqlConnection(con);
            connected.Open();
            cmd.CommandText = "select count(*) from information_schema.tables where table_name='" + exam.Replace("-", "") + "_" + subject.Replace(" ", "") +
                "_" + schoolyear + "' AND TABLE_SCHEMA='examination'";
            cmd.Connection = connected;
            string count = cmd.ExecuteScalar().ToString();
            connected.Close();
            return count;
        }
    }
}