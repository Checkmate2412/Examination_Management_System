using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;

namespace Student_Examination
{
    public partial class Menu : DevExpress.XtraEditors.XtraForm
    {
        private string con;
        private MySqlConnection connected;
        MySqlCommand cmd = new MySqlCommand();
        string name, firstname, username, schoolyear, logger;

        public Menu()
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

        private void Menu_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            Gtxt.Text = "Hi " + firstname + ".";
        }

        private void Exam_Click(object sender, EventArgs e)
        {
            logger = "Entered Take Exam Form";
            Log();
            Exam E = new Exam();
            E.Need(name, firstname, username, schoolyear);
            E.Show();
            this.Hide();
        }

        private void EditInfo_Click(object sender, EventArgs e)
        {
            logger = "Entered Student Info Form";
            Log();
            StudentInfo SI = new StudentInfo();
            SI.Need(name, firstname, username, schoolyear);
            SI.Show();
            this.Hide();
        }

        private void Report_Click(object sender, EventArgs e)
        {
            logger = "Entered Report Form";
            Log();
            Report report = new Report();
            report.Need(name, firstname, username, schoolyear);
            report.Show();
            this.Hide();
        }

        private void Log()
        {
            try
            {
                connected = new MySqlConnection(con);
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

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                LogOut_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1)
                Exam_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
                EditInfo_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.D3)
                Report_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.F1)
                MessageBox.Show("T or Alt + 1 = Take Exam\nE or Alt + 2 = Go to Edit Student Information" +
                    "\nR or Alt + 3 = Go to Report\nEscape = Log Out", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger = "Exit Application";
            Log();
        }

        private void Xbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                this.Close();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Log-Out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                logger = "Log-Out";
                Log();
                Form1 SIF = new Form1();
                SIF.Show();
                this.Hide();
            }
        }

        public void Essentials(string Ffullname, string Ffirstname, string FUsername, string Fschoolyear)
        {
            name = Ffullname;
            firstname = Ffirstname;
            username = FUsername;
            schoolyear = Fschoolyear;
        }
    }
}