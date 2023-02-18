using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Lan_Based_Examination
{
    public partial class MainView : DevExpress.XtraEditors.XtraForm
    {
        private string con;
        private MySqlConnection connected;
        MySqlCommand cmd = new MySqlCommand();
        string name, permission, schoolyear = "", username, password;

        public MainView()
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

        public void Need(string sy)
        {
            schoolyear = sy;
        }

        private double DateDiff(string date, string username)
        {
            try
            {
                DateTime today = DateTime.ParseExact(date, "MM/dd/yyyy", null);
                connected = new MySqlConnection(con);
                connected.Open();
                cmd.CommandText = "SELECT date FROM administrator where username ='" + username + "'";
                cmd.Connection = connected;
                MySqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                string dbdate = dr["date"].ToString();
                DateTime dtdb = DateTime.ParseExact(dbdate, "MM/dd/yyyy", null);
                double diff = (dtdb - today).TotalDays;
                connected.Close();
                return diff;
            }

            catch (Exception err)
            {
                MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
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

        private void Enter_Click(object sender, EventArgs e)
        {
            if (SYE.Text.Length != 4 || SYS.Text.Length != 4)
                MessageBox.Show("The school year format is yyyy-yyyy. \n\nExample: 2012-2013", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else if (SYE.Text.Length == 4 && SYS.Text.Length == 4)
            {
                int start = int.Parse(SYS.Text);
                int end = int.Parse(SYE.Text);
                int endminus = end - 1;

                if (start != endminus)
                    MessageBox.Show("Please fix the school year.", "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else if (start == endminus)
                {
                    schoolyear = SYS.Text + "-" + SYE.Text;
                    AlterTable();
                    ShowMenu();
                }
            }
        }

        private void AlterTable()
        {
            try
            {
                connected = new MySqlConnection(con);
                connected.Open();
                cmd.CommandText = "select count(*) from information_schema.tables where table_name = 'administrator_log' AND TABLE_SCHEMA='examination'";
                cmd.Connection = connected;
                string count = cmd.ExecuteScalar().ToString();
                connected.Close();

                if (count == "0")
                {
                    connected.Open();
                    cmd.CommandText = "create table `examination`.`administrator_log` ( `name` VARCHAR(200) NOT NULL , `username` VARCHAR(200) NOT NULL , `Time` " +
                        "VARCHAR(200) NOT NULL , `Remarks` VARCHAR(200) NOT NULL ) ENGINE = InnoDB;";
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

        private void SYS_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void SYE_KeyPress(object sender, KeyPressEventArgs e)
        {
            KP(sender, e);
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            KeyPreview = true;

            if (schoolyear != "")
                CheckPanel.Visible = true;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (schoolyear != "")
                CheckPanel.Visible = true;

            else if (schoolyear == "")
                CheckPanel.Visible = false;

            Utxt.Text = "";
            Ptxt.Text = "";
            SYE.Text = "";
            SYS.Text = "";
            logo.Visible = true;
            LIPanel.Visible = true;
            SYPanel.Visible = false;
        }

        private void MainView_KeyDown(object sender, KeyEventArgs e)
        {
            if (SYPanel.Visible == true)
            {
                if (e.KeyCode == Keys.Escape)
                    Back_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.Enter)
                    Enter_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.F1)
                    MessageBox.Show("Enter or Alt + E = Enter\nEscape or Alt + B = Back", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (LIPanel.Visible == true)
            {
                string CheckVisible = "";

                if (CheckPanel.Visible == true)
                    CheckVisible = "\nAlt + C = Check the Change School Year";

                if (e.KeyCode == Keys.Escape)
                    Xbtn_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.Enter)
                    LogIn_Click(sender, EventArgs.Empty);

                else if (e.KeyCode == Keys.F1)
                    MessageBox.Show("Enter or Alt + L = Log-In\nEscape = Exit " + CheckVisible + "", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int Login(string username, string password)
        {
            try
            {
                string date = DateTime.Now.ToString("MM/dd/yyyy");
                connected = new MySqlConnection(con);
                connected.Open();
                cmd.CommandText = "Select * from administrator where username ='" + username + "' and password ='" + password + "'";
                cmd.Connection = connected;
                MySqlDataReader login = cmd.ExecuteReader();

                if (login.Read())
                {
                    double Dd = Math.Abs(DateDiff(date, username));

                    if (Dd >= 1)
                    {
                        try
                        {
                            connected.Open();
                            cmd.CommandText = "UPDATE administrator SET date = '" + date + "' WHERE username='" + username + "'";
                            cmd.Connection = connected;
                            cmd.ExecuteReader();
                            connected.Close();
                            connected.Open();
                            cmd.CommandText = "UPDATE administrator SET Key_Code = SUBSTRING(MD5(RAND()) FROM 1 FOR 8) WHERE username='" + username + "'";
                            cmd.Connection = connected;
                            cmd.ExecuteReader();
                        }

                        catch (Exception err)
                        {
                            MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return 0;
                    }

                    else
                        connected.Close();
                        return 0;
                }

                else
                    connected.Close();
                    return 1;

            }
            catch (Exception err)
            {
                MessageBox.Show(err + ".");
                return 2;
            }
        }

        private void ShowMenu()
        {
            connected = new MySqlConnection(con);
            connected.Open();
            cmd.CommandText = "SELECT * FROM administrator where username='" + username + "'";
            cmd.Connection = connected;
                MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                name = dr["name"].ToString();
                permission = dr["permission"].ToString();
            }

            connected.Close();

            connected.Open();
            cmd.Connection = connected;
            cmd.CommandText = "INSERT INTO `administrator_log` (`name`, `username`, `Time`, `Remarks`) " +
                "VALUES('" + name + "', '" + username + "', '" + DateTime.Now.ToString() + "', 'Log-In')";
            cmd.Connection = connected;
            cmd.ExecuteNonQuery();
            connected.Close();

            MessageBox.Show("Welcome, " + name, "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Menu menu = new Menu();
            menu.Need(username, name, permission, schoolyear);
            menu.Show();
            this.Hide();
        }

        private void KP(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            {
                if (!Char.IsDigit(chr) && chr != 8)
                    e.Handled = true;
            }
        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            username = Utxt.Text;
            password = Ptxt.Text;

            if (username == "" || password == "")
                MessageBox.Show("Please fill up all the fields.", "Fill up", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else if (username != "" && password != "")
            {
                if (username.Substring(username.Length - 1) == "\\" || username.Substring(username.Length - 1) == "'"
                    || password.Substring(password.Length - 1) == "\\" || password.Substring(password.Length - 1) == "'")
                    MessageBox.Show("Quotation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else
                {
                    int check = Login(username, password);

                    if (check == 0)
                    {
                        if (schoolyear != "")
                        {
                            if (Check.Checked == true)
                            {
                                CheckPanel.Visible = false;
                                logo.Visible = false;
                                LIPanel.Visible = false;
                                SYPanel.Visible = true;
                            }

                            else if (Check.Checked == false)
                                ShowMenu();
                        }

                        else if (schoolyear == "")
                        {
                            CheckPanel.Visible = false;
                            logo.Visible = false;
                            LIPanel.Visible = false;
                            SYPanel.Visible = true;
                        }
                    }

                    else if (check == 1)
                        MessageBox.Show("Incorrect Username/Password", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else if (check == 2)
                        MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}