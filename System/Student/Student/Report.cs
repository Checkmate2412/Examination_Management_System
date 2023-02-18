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
    public partial class Report : DevExpress.XtraEditors.XtraForm
    {
        private string con;
        private MySqlConnection connected;
        MySqlCommand cmd = new MySqlCommand();
        int id;
        TableLayoutPanel tb = new TableLayoutPanel();
        string name, firstname, schoolyear, username, count, logger;
        string subject = "";
        string countmain = "0";

        public Report()
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

        private void Examtxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Report_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Home_Click(sender, EventArgs.Empty);

            if (e.KeyCode == Keys.F1)
                MessageBox.Show("Escape = Go to Main Menu"
                    , "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Examtxt_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                string find;
                connected.Open();
                cmd.CommandText = "select count(*) from information_schema.tables where table_name= 'schedule_" + Examtxt.Text.ToString().Replace("-", "") +
                    "_" + schoolyear + "' AND TABLE_SCHEMA='examination'";
                cmd.Connection = connected;
                find = cmd.ExecuteScalar().ToString();
                connected.Close();

                if (find == "1")
                {
                    DateTime convert = DateTime.Now, TimeNow = DateTime.Now;
                    connected = new MySqlConnection(con);
                    connected.Open();
                    cmd.CommandText = "select * from `schedule_" + Examtxt.Text.ToString().Replace("-", "") +
                        "_" + schoolyear + "` order by `completeendtime` desc limit 10";

                    cmd.Connection = connected;
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        convert = (Convert.ToDateTime(dr["completeendtime"].ToString()));
                    }

                    connected.Close();

                    if (TimeNow > convert)
                    {
                        Check();
                        tb.Controls.Clear();

                        connected.Open();
                        cmd.CommandText = "select count(*) from information_schema.tables where table_name= 'schedule_" + Examtxt.Text.ToString().Replace("-", "") +
                            "_" + schoolyear + "' AND TABLE_SCHEMA='examination'";
                        cmd.Connection = connected;
                        countmain = cmd.ExecuteScalar().ToString();
                        connected.Close();

                        if (countmain == "1")
                            SubjectLoad();

                        else if (countmain == "0")
                            MessageBox.Show("No Record.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (convert > TimeNow)
                        MessageBox.Show("This examination is ongoing. You can't view this record.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else if (find == "0")
                    MessageBox.Show("No Record.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception err)
            {
                MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Report_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger = "Exit Application";
            Log();
        }

        private void Check()
        {
            try
            {
                connected = new MySqlConnection(con);
                connected.Open();
                cmd.CommandText = "select * from `student_info` where username = '" + username + "'";
                cmd.Connection = connected;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    count = (dr["numberofsubject"].ToString());
                    id = int.Parse(count);
                }
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
            int columncount = 0, rowcount = 1;
            int tbplus = id + 1;
            tb.ColumnCount = 5;

            Label lbtb1 = new Label
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "Subject"
            };

            Label lbtb2 = new Label
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "Total Score"
            };

            Label lbtb3 = new Label
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "Total Items"
            };

            Label lbtb4 = new Label
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "Passing Score"
            };

            Label lbtb5 = new Label
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "Remark"
            };


            tb.Controls.Add(lbtb1, 0, 0);
            tb.Controls.Add(lbtb2, 1, 0);
            tb.Controls.Add(lbtb3, 2, 0);
            tb.Controls.Add(lbtb4, 3, 0);
            tb.Controls.Add(lbtb5, 4, 0);
            tb.RowCount = id;
            tb.Dock = DockStyle.Fill;

            for (int idtab = 1; idtab < tbplus; idtab++)
            {
                tb.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
                tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
                tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
                tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
                tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
                tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
                tb.AutoScroll = true;
                tb.AutoSize = true;

                Label lb1 = new Label();
                Label lb2 = new Label();
                Label lb3 = new Label();
                Label lb4 = new Label();
                Label lb5 = new Label();

                lb1.BackColor = Color.Transparent;
                lb1.Dock = DockStyle.Fill;
                lb1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
                lb1.ForeColor = Color.White;
                lb1.TextAlign = ContentAlignment.MiddleCenter;

                lb2.BackColor = Color.Transparent;
                lb2.Dock = DockStyle.Fill;
                lb2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
                lb2.ForeColor = Color.White;
                lb2.TextAlign = ContentAlignment.MiddleCenter;

                lb3.BackColor = Color.Transparent;
                lb3.Dock = DockStyle.Fill;
                lb3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
                lb3.ForeColor = Color.White;
                lb3.TextAlign = ContentAlignment.MiddleCenter;

                lb4.BackColor = Color.Transparent;
                lb4.Dock = DockStyle.Fill;
                lb4.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
                lb4.ForeColor = Color.White;
                lb4.TextAlign = ContentAlignment.MiddleCenter;

                lb5.BackColor = Color.Transparent;
                lb5.Dock = DockStyle.Fill;
                lb5.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
                lb5.ForeColor = Color.White;
                lb5.TextAlign = ContentAlignment.MiddleCenter;

                connected = new MySqlConnection(con);
                connected.Open();
                cmd.CommandText = "select * from `student_info` where username = '" + username + "'";
                cmd.Connection = connected;
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    subject = (dr["Subject" + idtab + ""].ToString());
                    lb1.Text = subject;
                    lb1.Name = subject;
                }
                connected.Close();
                tb.Controls.Add(lb1, columncount, rowcount);
                columncount++;

                int passingscore = 0;

                connected.Open();
                cmd.CommandText = "select count(*) from information_schema.tables where table_name='" + Examtxt.Text.Replace("-", "") 
                    + "_" + subject.Replace(" ", "") + "_" + schoolyear + "' AND TABLE_SCHEMA='examination'";
                cmd.Connection = connected;
                string count1 = cmd.ExecuteScalar().ToString();
                connected.Close();

                if (count1 == "1")
                {
                    connected.Open();
                    cmd.CommandText = "select * from `" + Examtxt.Text.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "`";
                    cmd.Connection = connected;
                    MySqlDataReader dr1 = cmd.ExecuteReader();

                    while (dr1.Read())
                    {
                        passingscore = int.Parse(dr1["passingscore"].ToString());
                        lb4.Text = (dr1["passingscore"].ToString());
                        lb3.Text = (dr1["totalitems"].ToString());
                    }

                    connected.Close();

                    connected.Open();
                    cmd.CommandText = "select count(*) from information_schema.tables where table_name='result_" + Examtxt.Text.Replace("-", "")
                    + "_" + subject.Replace(" ", "") + "_" + schoolyear + "' AND TABLE_SCHEMA='examination'";
                    cmd.Connection = connected;
                    string count = cmd.ExecuteScalar().ToString();
                    connected.Close();

                    if (count == "1")
                    {
                        string done = "";
                        int score = 0;

                        connected.Open();
                        cmd.CommandText = "select * from `result_" + Examtxt.Text.Replace("-", "") + "_" + subject.Replace(" ", "") + "_" + schoolyear + "` where username = '" + username + "'";
                        cmd.Connection = connected;
                        MySqlDataReader dr2 = cmd.ExecuteReader();

                        while (dr2.Read())
                        {
                            lb2.Text = dr2["score"].ToString();
                            score = int.Parse(dr2["score"].ToString());
                            done = dr2["done"].ToString();
                        }

                        if (done == "Yes")
                        {
                            if (score >= passingscore)
                            {
                                lb5.Text = "Passed";
                                lb5.ForeColor = Color.Green;
                            }

                            else if (score < passingscore)
                            {
                                lb5.Text = "Failed";
                                lb5.ForeColor = Color.Red;
                            }
                        }

                        else if (done == "No")
                        {
                            lb5.Text = "Not Final Score";
                            lb5.ForeColor = Color.Blue;
                        }

                        connected.Close();
                    }

                    else if (count == "0")
                    {
                        lb2.Text = "No Record";
                        lb3.Text = "No Record";
                        lb4.Text = "No Record";
                        lb5.Text = "No Record";
                    }
                }

                else if (count1 != "1")
                {
                    lb2.Text = "No Record";
                    lb3.Text = "No Record";
                    lb4.Text = "No Record";
                    lb5.Text = "No Record";
                }

                tb.Controls.Add(lb2, columncount, rowcount);
                columncount++;
                tb.Controls.Add(lb3, columncount, rowcount);
                columncount++;
                tb.Controls.Add(lb4, columncount, rowcount);
                columncount++;
                tb.Controls.Add(lb5, columncount, rowcount);
                rowcount++;
                columncount = 0;
                OnePanel.Controls.Add(tb);
            }

            tb.BackColor = Color.Transparent;
            tb.Name = "tb";
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

        private void Report_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            Check();
        }

        public void Need(string Gname, string FName, string FUsername, string Fschoolyear)
        {
            name = Gname;
            firstname = FName;
            username = FUsername;
            schoolyear = Fschoolyear;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Clocktxt.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}