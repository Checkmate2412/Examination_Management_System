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
    public partial class Exam : DevExpress.XtraEditors.XtraForm
    {
        private string con;
        private MySqlConnection connected;
        MySqlCommand cmd = new MySqlCommand();
        int id;
        TableLayoutPanel tb = new TableLayoutPanel();
        string name, firstname, schoolyear, username, count, logger;
        string subject = "", date = "", datetime = "";
        string countmain = "0";
        int counter = 0;

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

        private void Xbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                this.Close();
        }

        public Exam()
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

        private void Exam_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger = "Exit Application";
            Log();
        }

        private void Exam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Home_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.F1)
                MessageBox.Show("Escape = Go to Main Menu", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Examtxt_SelectedIndexChanged_1(object sender, EventArgs e)
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
                MessageBox.Show("No Schedule.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (countmain == "1")
                counter++;

            if (countmain == "1" && counter == 60)
            {
                RefreshControl();
                counter = 0;
            }
        }

        private void Exam_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            Check();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            string sub = ((Button)sender).Tag.ToString();
            logger = "Taking Examination: " + Examtxt.Text + " Examination of " + sub + ", " + schoolyear + "";
            Log();
            Properties.Examination exam = new Properties.Examination();
            exam.Show();
            exam.Essentials(name, Examtxt.SelectedItem.ToString(), sub, schoolyear, username);
            this.Hide();
        }

        private void RefreshControl()
        {
            Check();
            tb.Controls.Clear();
            SubjectLoad();
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
            DateTime TimeStart = DateTime.Now, TimeEnd = DateTime.Now;
            int columncount = 0, rowcount = 1;
            int tbplus = id + 1;
            tb.ColumnCount = 4;

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
                Text = "Date"
            };

            Label lbtb3 = new Label
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "Time"
            };

            Label lbtb4 = new Label
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "Status"
            };

            tb.Controls.Add(lbtb1, 0, 0);
            tb.Controls.Add(lbtb2, 1, 0);
            tb.Controls.Add(lbtb3, 2, 0);
            tb.Controls.Add(lbtb4, 3, 0);
            tb.RowCount = id;
            tb.Dock = DockStyle.Fill;

            for (int idtab = 1; idtab < tbplus; idtab++)
            {
                tb.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
                tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
                tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
                tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
                tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
                tb.AutoScroll = true;
                tb.AutoSize = true;

                Label lb1 = new Label();
                Label lb2 = new Label();
                Label lb3 = new Label();
                Button btn = new Button
                {
                    Anchor = AnchorStyles.None,
                    Font = new Font("Microsoft Sans Serif", 10F),
                    Location = new Point(926, 131),
                    ForeColor = Color.Black,
                    Name = subject + "status",
                    Size = new Size(103, 38)
                };

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

                try
                {
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

                    cmd.CommandText = "select * from `schedule_" + Examtxt.Text.ToString().Replace("-", "") + "_" + schoolyear + "` where subject = '" + subject + "'";
                    cmd.Connection = connected;
                    connected.Open();
                    MySqlDataReader dr1 = cmd.ExecuteReader();

                    while (dr1.Read())
                    {
                        date = (dr1["date"].ToString());
                        datetime = (dr1["time"].ToString() + "-" + dr1["endtime"].ToString());
                        TimeStart = (Convert.ToDateTime(dr1["completetime"].ToString()));
                        TimeEnd = (Convert.ToDateTime(dr1["completeendtime"].ToString()));

                        lb2.Text = date;
                        lb2.Name = subject + "date";
                        lb3.Text = datetime;
                        lb3.Name = subject + "time";
                    }
                    connected.Close();

                    if (lb2.Text == "")
                    {
                        lb2.Text = "Not Available";
                        TimeEnd = DateTime.Now;
                        TimeStart = DateTime.Now;
                        btn.Enabled = false;
                        btn.Text = "Not Available";
                    }

                    if (lb3.Text == "")
                    {
                        lb3.Text = "Not Available";
                        TimeEnd = DateTime.Now;
                        TimeStart = DateTime.Now;
                        btn.Enabled = false;
                        btn.Text = "Not Available";
                    }

                    DateTime Now = DateTime.Now;

                    if (lb2.Text != "" && lb3.Text != "")
                    {
                        if (Now >= TimeStart && Now < TimeEnd)
                        {
                            btn.Enabled = true;
                            btn.Text = "Ongoing";
                        }

                        else if (Now > TimeEnd && Now > TimeStart && (lb2.Text != "Not Available" || lb3.Text != "Not Available"))
                        {
                            btn.Enabled = false;
                            btn.Text = "Time Finish";
                        }

                        else if (Now < TimeStart)
                        {
                            btn.Enabled = false;
                            btn.Text = "Wait For Time";
                        }

                        else if (lb2.Text == "Not Available" || lb3.Text == "Not Available")
                        {
                            btn.Text = "Not Available";
                            btn.Enabled = false;
                        }
                    }

                    tb.Controls.Add(lb2, columncount, rowcount);
                    columncount++;
                    tb.Controls.Add(lb3, columncount, rowcount);
                    columncount++;
                }

                catch (Exception err)
                {
                    MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                btn.Tag = subject;
                btn.Click += Btn_Click;
                tb.Controls.Add(btn, columncount, rowcount);
                rowcount++;
                columncount = 0;
                OnePanel.Controls.Add(tb);
            }

            tb.BackColor = Color.Transparent;
            tb.Name = "tb";
        }
    }
}