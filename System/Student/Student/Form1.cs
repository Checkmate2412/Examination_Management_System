using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Student_Examination
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private string con;
        private MySqlConnection connected;
        MySqlCommand cmd = new MySqlCommand();
        string fullname, firstname, schoolyear;

        public Form1()
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

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Xbtn_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.Enter)
                LogIn_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.F1)
                MessageBox.Show("Enter or Alt + L = Log-In\nEscape = Exit", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int Login(string username, string password)
        {
            try
            {
                connected = new MySqlConnection(con);
                connected.Open();
                cmd.CommandText = "Select * from student_info where username ='" + username + "' and password ='" + password + "'";
                cmd.Connection = connected;
                MySqlDataReader login = cmd.ExecuteReader();

                int count = 0;

                if (login.Read())
                {
                    count++;
                    return count;
                }

                else
                {
                    return 2;
                }
            }

            catch (Exception err)
            {
                MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 3;
            }

        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            string username = Utxt.Text;
            string password = Ptxt.Text;

            if (username == "" || password == "")
                MessageBox.Show("Please fill up all the fields.", "Fill up", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else if (username != "" && password != "")
            {
                if (username.Substring(username.Length - 1) == "\\" || username.Substring(username.Length - 1) == "'"
                    || password.Substring(password.Length - 1) == "\\" || password.Substring(password.Length - 1) == "'")
                    MessageBox.Show("Quatation Mark and Apostrophe are not allowed at the end of the input.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                else
                {
                    int check = Login(username, password);

                    if (check == 1)
                    {
                        try
                        {
                            connected = new MySqlConnection(con);
                            connected.Open();
                            cmd.CommandText = "SELECT * FROM `student_info` where username='" + username + "'";
                            cmd.Connection = connected;
                            MySqlDataReader dr = cmd.ExecuteReader();

                            while (dr.Read())
                            {
                                fullname = dr["name"].ToString();
                                firstname = dr["firstname"].ToString();
                                schoolyear = dr["schoolyearstart"].ToString() + "-" + dr["schoolyearend"].ToString();
                            }
                            connected.Close();

                            connected = new MySqlConnection(con);
                            connected.Open();
                            cmd.CommandText = "select count(*) from information_schema.tables where table_name = 'student_log' AND TABLE_SCHEMA='examination'";
                            cmd.Connection = connected;
                            string count = cmd.ExecuteScalar().ToString();
                            connected.Close();

                            if (count == "0")
                            {
                                connected.Open();
                                cmd.CommandText = "create table `examination`.`student_log` ( `name` VARCHAR(200) NOT NULL , `username` VARCHAR(200) NOT NULL , `Time` " +
                                    "VARCHAR(200) NOT NULL , `Remarks` VARCHAR(200) NOT NULL ) ENGINE = InnoDB;";
                                cmd.Connection = connected;
                                cmd.ExecuteReader();
                                connected.Close();
                            }

                            connected.Open();
                            cmd.Connection = connected;
                            cmd.CommandText = "INSERT INTO `student_log` (`name`, `username`, `Time`, `Remarks`) " +
                                "VALUES('" + fullname + "', '" + username + "', '" + DateTime.Now.ToString() + "', 'Log-In')";
                            cmd.Connection = connected;
                            cmd.ExecuteNonQuery();
                            connected.Close();

                            MessageBox.Show("Hello, " + firstname, "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Menu menu = new Menu();
                            menu.Essentials(fullname, firstname, username, schoolyear);
                            menu.Show();
                            this.Hide();
                        }

                        catch (Exception err)
                        {
                            MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (check == 2)
                        MessageBox.Show("Incorrect Username/Password", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else if (check == 3)
                        MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
