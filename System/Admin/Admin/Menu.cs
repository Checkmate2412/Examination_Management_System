using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Lan_Based_Examination
{
    public partial class Menu : DevExpress.XtraEditors.XtraForm
    {
        private string con;
        private MySqlConnection connected;
        MySqlCommand cmd = new MySqlCommand();
        string permission, GName, schoolyear, username, logger;

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

        private void LogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Log-Out?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                logger = "Log-Out";
                Log();
                MainView mv = new MainView();
                mv.Need(schoolyear);
                mv.Show();
                this.Hide();
            }
        }

        private void Log()
        {
            try
            {
                connected.Open();
                cmd.CommandText = "INSERT INTO `administrator_log` (`name`, `username`, `Time`, `Remarks`) " +
                    "VALUES('" + GName + "', '" + username + "', '" + DateTime.Now.ToString() + "', '" + logger + "')";
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

        private void Menu_Load(object sender, EventArgs e)
        {
            KeyPreview = true;

            Greeting.Text = ("Hi " + GName.ToString());

            if (permission == "Professor")
            {
                TeacherPanel.Visible = true;
                AdminPanel.Visible = false;
                ProctorPanel.Visible = false;
            }

            else if (permission == "Administrator")
            {
                AdminPanel.Visible = false;
                AdminPanel.Visible = true;
                ProctorPanel.Visible = false;
            }

            else if (permission == "Proctor")
            {
                ProctorPanel.Visible = false;
                AdminPanel.Visible = false;
                ProctorPanel.Visible = true;
            }

            GetCode();
        }

        public void GetCode()
        {
            try
            {
                connected = new MySqlConnection(con);
                connected.Open();
                cmd.CommandText = "SELECT key_code FROM administrator where username ='" + username + "'";
                cmd.Connection = connected;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Codetxt.Text = "Your Key Code: " + dr["key_code"].ToString();
                }

                connected.Close();
            }

            catch (Exception err)
            {
                MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Codetxt.Text = ("Your Key Code: Error");
            }
        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            try
            {
                logger = "Change keycode.";
                Log();
                connected.Open();
                cmd.CommandText = "UPDATE administrator SET Key_Code = SUBSTRING(MD5(RAND()) FROM 1 FOR 8) WHERE username='" + username + "'";
                cmd.Connection = connected;
                cmd.ExecuteReader();
                connected.Close();
                GetCode();
            }
            catch (Exception err)
            {
                MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminAccount_Click(object sender, EventArgs e)
        {
            AdminAccount AA = new AdminAccount();
            AA.Need(username, GName, permission, schoolyear);
            AA.Show();
            this.Hide();
        }

        private void Students()
        {
            logger = "Entered to Student Account Form";
            Log();
            StudentInfo SI = new StudentInfo();
            SI.Need(username, GName, permission, schoolyear);
            SI.Show();
            this.Hide();
        }

        private void Semester_Click(object sender, EventArgs e)
        {
            logger = "Entered to Semester Subject Form";
            Log();
            SemesterSubject SS = new SemesterSubject();
            SS.Need(username, GName, permission, schoolyear);
            SS.Show();
            this.Hide();
        }

        private void Student_Click(object sender, EventArgs e)
        {
            Students();
        }

        private void AddQuestionTeacher_Click(object sender, EventArgs e)
        {
            logger = "Entered to Questions Form";
            Log();
            Questions question = new Questions();
            question.Need(username, GName, permission, schoolyear);
            question.Show();
            this.Hide();
        }

        private void StudentInfoTeacher_Click(object sender, EventArgs e)
        {
            Students();
        }

        private void Check_Click(object sender, EventArgs e)
        {
            logger = "Entered to Check Form";
            Log();
            Check check = new Check();
            check.Need(username, GName, permission, schoolyear);
            check.Show();
            this.Hide();
        }

        private void ViewScore_Click(object sender, EventArgs e)
        {
            logger = "Entered to Chart Form";
            Log();
            Chart C = new Chart();
            C.Need(username, GName, permission, schoolyear);
            C.Show();
            this.Hide();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger = "Exit Application";
            Log();
        }

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                LogOut_Click(sender, EventArgs.Empty);

            if (AdminPanel.Visible == true && TeacherPanel.Visible == false && ProctorPanel.Visible == false)
            {
                if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1)
                    AdminAccount_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
                    Semester_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.D3)
                    Student_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.D4)
                    LogIn_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.F1)
                    MessageBox.Show("A or Alt + 1 = Go to Administrator Account\nE or Alt + 2 = Go to Semester Subject List" +
                        "\nS or Alt + 3 = Go to Student Account\nG or C or Alt + 4 = Change Code\nEscape = Log Out", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (TeacherPanel.Visible == true && AdminPanel.Visible == false && ProctorPanel.Visible == false)
            {
                if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1)
                    AddQuestionTeacher_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
                    StudentInfoTeacher_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.D3)
                    Check_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.D4)
                    ViewScore_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.D5)
                    LogIn_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.F1)
                    MessageBox.Show("E or Alt + 1 = Go to Add/Edit Examination\nS or Alt + 2 = Go to Student Account" +
                        "\nA or Alt + 3 = Go to Check Answer\nR or Alt + 4 = Go to Records\nG or C or Alt + 5 = Change Code\n" +
                        "Escape = Log Out", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (ProctorPanel.Visible == true && TeacherPanel.Visible == false && AdminPanel.Visible == false)
            {
                if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1)
                    ProctorStudent_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
                    LogIn_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.F1)
                    MessageBox.Show("S or Alt + 1 = Go to Student Account\n\nG or C or Alt + 2 = " +
                        "Change Code\nEscape = Log Out", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ProctorStudent_Click(object sender, EventArgs e)
        {
            Students();
        }

        public void Need(string un, string name, string perm, string sy)
        {
            username = un;
            permission = perm;
            GName = name;
            schoolyear = sy;
        }

        private void Xbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Clocktxt.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}