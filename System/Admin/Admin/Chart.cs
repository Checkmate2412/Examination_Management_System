using DevExpress.XtraCharts;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Lan_Based_Examination
{
    public partial class Chart : DevExpress.XtraEditors.XtraForm
    {
        private string con;
        private MySqlConnection connected;
        MySqlCommand cmd = new MySqlCommand();
        ComboBox cb = new ComboBox();
        ComboBox cb1 = new ComboBox();
        TableLayoutPanel tb = new TableLayoutPanel();
        string username, name, permission, schoolyear, AC, BC, CC, DC, Answer, QT, Question, 
            firstnumber, lastnumber, itemtype, order, label, logger;
        int numberofsubject, A, B, C, D, id, number = 1, TFT, TFF, TIT, TII, TIO, IC, IW,
            ENE, EE, iddup, count, numbercount, totaltake, passingscore = 0, passstud = 0;

        private void Chart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Home_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.F1)
                MessageBox.Show("Alt + E = Export the Students' Record\nAlt + Left = " +
                    "Previous\nAlt + Right = Next\nEscape = Go to Menu", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Alt && Essential.Visible == true)
                Export_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.Right && e.Modifiers == Keys.Alt && Essential.Visible == true)
                Next_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.Left && e.Modifiers == Keys.Alt && Essential.Visible == true)
                Previous_Click(sender, EventArgs.Empty);
        }

        private void Chart_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger = "Exit Application";
            Log();
        }

        private void Log()
        {
            try
            {
                connected.Open();
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

        private void Export_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Columns.Count == 0 && dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Table Empty. Please select an examination.");
                }

                else
                {
                    try
                    {
                        object appMissing = Missing.Value;
                        Excel._Application app = new Excel.Application();
                        Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                        Excel._Worksheet worksheet = null;
                        worksheet = workbook.Sheets["Sheet1"];
                        worksheet = workbook.ActiveSheet;
                        worksheet.Name = "Records";

                        try
                        {
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
                            }

                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {

                                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                                {

                                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();

                                    else
                                        worksheet.Cells[i + 2, j + 1] = "";
                                }
                            }

                            worksheet.Columns.AutoFit();

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
                            
                            object fileName = "" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear + "";
                            app.DisplayAlerts = false;
                            workbook.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookDefault, appMissing, Password);
                            object filePath = app.ActiveWorkbook.Path + "\\" + fileName + ".xlsx";
                            MessageBox.Show(filePath.ToString());
                            workbook.Close();
                            MessageBox.Show("Workbook Export Successfully. The workbook password is also your password in this system.");
                            Process.Start(filePath.ToString());
                            logger = "Exported an Excel file: " + fileName.ToString() + ".xlsx";
                            Log();
                        }

                        catch (Exception err)
                        {
                            MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        finally
                        {
                            workbook = null;
                            worksheet = null;
                        }
                    }

                    catch (Exception err)
                    {
                        MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            try
            {
                panel2.Visible = false;
                number = number - 1;
                if (number == 0)
                {
                    number = 1;
                    MessageBox.Show("This is the first page.");
                }

                else if (number > id && number <= iddup)
                {
                    if (number == iddup)
                    {
                        order = "asc";
                        label = "Top 10 Lowest Score";
                    }

                    else
                    {
                        order = "desc";
                        label = "Top 10 Highest Score";
                    }

                    CountStudent();
                    Ranking();
                }

                else 
                {
                    FillUp();
                }

                panel2.Visible = true;
            }

            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            try
            {
                panel2.Visible = false;
                number = number + 1;
                if (number <= id)
                    FillUp();

                else if (number > id && number <= iddup)
                {
                    if (number == iddup)
                    {
                        order = "asc";
                        label = "Top 10 Lowest Score";
                    }

                    else
                    {
                        order = "desc";
                        label = "Top 10 Highest Score";
                    }

                    CountStudent();
                    Ranking();
                }

                else if (number > id && number > iddup)
                {
                    number = number - 1;
                    MessageBox.Show("This is the last page.");
                }
                panel2.Visible = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void CountStudent()
        {
            cb.Items.Clear();
            connected.Open();

            cmd.CommandText = "select count(*) from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear +"` where professor = '" + name + "'";
            cmd.Connection = connected;
            count = int.Parse(cmd.ExecuteScalar().ToString());
            connected.Close();

            if (count < 10)
            {
                numbercount = count;
            }

            else if (count >= 10)
            {
                numbercount = 10;
            }

            cmd.CommandText = "select * from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear + 
                "` where professor = '" + name + "' order by Score " + order + " limit " + numbercount + "";
            cmd.Connection = connected;
            connected.Open();
            MySqlDataReader dr1 = cmd.ExecuteReader();

            while (dr1.Read())
            {
                cb.Items.Add(dr1["Name"].ToString());
            }
            connected.Close();
        }

        private void Ranking()
        {
            try
            {
                tb.Controls.Clear();
                panel2.Controls.Clear();

                Label lbtb1 = new Label();
                lbtb1.BackColor = Color.Transparent;
                lbtb1.Dock = DockStyle.Fill;
                lbtb1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
                lbtb1.ForeColor = Color.White;
                lbtb1.TextAlign = ContentAlignment.MiddleCenter;
                lbtb1.Text = "Rank";

                Label lbtb2 = new Label();
                lbtb2.BackColor = Color.Transparent;
                lbtb2.Dock = DockStyle.Fill;
                lbtb2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
                lbtb2.ForeColor = Color.White;
                lbtb2.TextAlign = ContentAlignment.MiddleCenter;
                lbtb2.Text = "Name";

                Label lbtb3 = new Label();
                lbtb3.BackColor = Color.Transparent;
                lbtb3.Dock = DockStyle.Fill;
                lbtb3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
                lbtb3.ForeColor = Color.White;
                lbtb3.TextAlign = ContentAlignment.MiddleCenter;
                lbtb3.Text = "Year";

                Label lbtb4 = new Label();
                lbtb4.BackColor = Color.Transparent;
                lbtb4.Dock = DockStyle.Fill;
                lbtb4.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
                lbtb4.ForeColor = Color.White;
                lbtb4.TextAlign = ContentAlignment.MiddleCenter;
                lbtb4.Text = "Course";

                Label lbtb5 = new Label();
                lbtb5.BackColor = Color.Transparent;
                lbtb5.Dock = DockStyle.Fill;
                lbtb5.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
                lbtb5.ForeColor = Color.White;
                lbtb5.TextAlign = ContentAlignment.MiddleCenter;
                lbtb5.Text = "Score";

                Panel panel = new Panel();
                panel.Size = new Size(800, 50);
                panel.Dock = DockStyle.Top;
                panel.BackColor = Color.Transparent;

                Label lb = new Label();
                lb.BackColor = Color.Transparent;
                lb.Dock = DockStyle.Fill;
                lb.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
                lb.ForeColor = Color.White;
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Text = label;
                lb.Dock = DockStyle.Fill;
                panel.Controls.Add(lb);
                panel2.Controls.Add(panel);

                int columncount = 0, rowcount = 2;
                tb.ColumnCount = 5;
                tb.RowCount = 11;
                int minuscount = numbercount - 1;
                int add = 1;

                tb.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
                tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
                tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
                tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
                tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));

                tb.Controls.Add(lbtb1, 0, 1);
                tb.Controls.Add(lbtb2, 1, 1);
                tb.Controls.Add(lbtb3, 2, 1);
                tb.Controls.Add(lbtb4, 3, 1);
                tb.Controls.Add(lbtb5, 4, 1);

                for (int idtab = 0; idtab <= minuscount; idtab++)
                {
                    tb.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));

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
                    cmd.CommandText = "select * from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" +
                        schoolyear + "` where name = '" + cb.GetItemText(cb.Items[idtab].ToString()) + "' && professor = '" + name + "'";
                    cmd.Connection = connected;
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        lb1.Text = add.ToString();
                        lb2.Text = cb.GetItemText(cb.Items[idtab].ToString());
                        lb3.Text = dr["Year"].ToString();
                        lb4.Text = dr["Course"].ToString();
                        lb5.Text = dr["Score"].ToString();
                    }
                    connected.Close();

                    tb.Controls.Add(lb1, columncount, rowcount);
                    columncount++;
                    tb.Controls.Add(lb2, columncount, rowcount);
                    columncount++;
                    tb.Controls.Add(lb3, columncount, rowcount);
                    columncount++;
                    tb.Controls.Add(lb4, columncount, rowcount);
                    columncount++;
                    tb.Controls.Add(lb5, columncount, rowcount);
                    rowcount++;
                    columncount = 0;
                    add++;
                }

                tb.AutoScroll = true;
                tb.AutoSize = true;
                panel2.Controls.Add(tb);
                tb.BackColor = Color.Transparent;
                tb.Name = "tb";
            }

            catch (Exception err)
            {
                MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Chart()
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

        private void Subject_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel2.Visible = false;
            Exam.Enabled = true;
            Exam.SelectedIndex = -1;
            panel2.Controls.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            Essential.Visible = false;
            Students.Visible = false;
            Range.Visible = false;
        }

        public void Need(string un, string n, string perm, string sy)
        {
            username = un;
            permission = perm;
            name = n;
            schoolyear = sy;
        }

        private void Xbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            Clocktxt.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dataGridView1.Font = new Font("Microsoft Sans Serif", 16);
            dataGridView1.Font = new Font("Microsoft Sans Serif", 16);
            SubjectLoad();
        }

        private void FillUp()
        {
            try
            {
                string check = "", check1 = "";
                panel2.Controls.Clear();
                ChartControl DoughnutChart = new ChartControl();
                DoughnutChart.AnimationStartMode = ChartAnimationMode.OnDataChanged;
                ChartTitle chartTitle1 = new ChartTitle();
                Series series1 = new Series("Series 1", ViewType.Doughnut);
                DoughnutChart.Dock = DockStyle.Fill;

                cmd.CommandText = "select * from `" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear + "` where id = " + number + "";
                cmd.Connection = connected;
                connected.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    itemtype = dr["itemtype"].ToString();
                    firstnumber = dr["number"].ToString();
                    lastnumber = dr["lastnumber"].ToString();
                    Question = dr["Questions"].ToString();
                    AC = dr["A"].ToString();
                    BC = dr["B"].ToString();
                    CC = dr["C"].ToString();
                    DC = dr["D"].ToString();
                    Answer = dr["Answer"].ToString();
                    QT = dr["QuestionType"].ToString();
                }
                connected.Close();

                if (QT == "Multiple Choice")
                {
                    connected.Open();
                    cmd.CommandText = "select count(*) from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear +
                        "` WHERE `AnswerQ" + number + "` = '" + AC + "' && `professor` = '" + name + "'";
                    cmd.Connection = connected;
                    A = int.Parse(cmd.ExecuteScalar().ToString());
                    connected.Close();

                    connected.Open();
                    cmd.CommandText = "select count(*) from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear +
                        "` WHERE `AnswerQ" + number + "` = '" + BC + "' && `professor` = '" + name + "'";
                    cmd.Connection = connected;
                    B = int.Parse(cmd.ExecuteScalar().ToString());
                    connected.Close();

                    connected.Open();
                    cmd.CommandText = "select count(*) from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear +
                        "` WHERE `AnswerQ" + number + "` = '" + CC + "' && `professor` = '" + name + "'";
                    cmd.Connection = connected;
                    C = int.Parse(cmd.ExecuteScalar().ToString());
                    connected.Close();

                    connected.Open();
                    cmd.CommandText = "select count(*) from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear +
                        "` WHERE `AnswerQ" + number + "` = '" + DC + "' && `professor` = '" + name + "'";
                    cmd.Connection = connected;
                    D = int.Parse(cmd.ExecuteScalar().ToString());
                    connected.Close();

                    series1.Points.AddPoint("A", A);
                    series1.Points.AddPoint("B", B);
                    series1.Points.AddPoint("C", C);
                    series1.Points.AddPoint("D", D);

                }

                else if (QT == "True/False")
                {
                    connected.Open();
                    cmd.CommandText = "select count(*) from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear +
                        "` WHERE `AnswerQ" + number + "` = 'True' && `professor` = '" + name + "'";
                    cmd.Connection = connected;
                    TFT = int.Parse(cmd.ExecuteScalar().ToString());
                    connected.Close();

                    connected.Open();
                    cmd.CommandText = "select count(*) from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear +
                        "` WHERE `AnswerQ" + number + "` = 'False' && `professor` = '" + name + "'";
                    cmd.Connection = connected;
                    TFF = int.Parse(cmd.ExecuteScalar().ToString());
                    connected.Close();

                    series1.Points.AddRange(
                        new SeriesPoint("True", TFT),
                        new SeriesPoint("False", TFF));
                }

                else if (QT == "True/Identify")
                {
                    check = Answer;
                    connected.Open();
                    cmd.CommandText = "select count(*) from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear +
                        "` WHERE `AnswerQ" + number + "` = " + Answer + " && `professor` = '" + name + "'";
                    cmd.Connection = connected;
                    TII = int.Parse(cmd.ExecuteScalar().ToString());
                    connected.Close();

                    connected.Open();
                    cmd.CommandText = "select count(*) from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear +
                        "` WHERE `AnswerQ" + number + "` = 'True' && `professor` = '" + name + "'";
                    cmd.Connection = connected;
                    TIT = int.Parse(cmd.ExecuteScalar().ToString());
                    connected.Close();

                    connected.Open();
                    cmd.CommandText = "select count(*) from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear +
                        "` WHERE `AnswerQ" + number + "` != 'True' && `AnswerQ" + number + "` != " + Answer + " && `professor` = '" + name + "'";
                    cmd.Connection = connected;
                    TIO = int.Parse(cmd.ExecuteScalar().ToString());
                    connected.Close();

                    if (Answer == "True")
                        series1.Points.AddRange(
                            new SeriesPoint("True", TIT),
                            new SeriesPoint("Other Answers", TIO));

                    else if (Answer != "True" && Answer == check)
                        series1.Points.AddRange(
                            new SeriesPoint(Answer, TII),
                            new SeriesPoint("True", TIT),
                            new SeriesPoint("Other Answers", TIO));
                }

                else if (QT == "Identification")
                {
                    check1 = Answer;
                    connected.Open();
                    cmd.CommandText = "select count(*) from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear +
                        "` WHERE `AnswerQ" + number + "` = '" + Answer + "' && `professor` = '" + name + "'";
                    cmd.Connection = connected;
                    IC = int.Parse(cmd.ExecuteScalar().ToString());
                    connected.Close();

                    connected.Open();
                    cmd.CommandText = "select count(*) from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear +
                        "` WHERE `AnswerQ" + number + "` != '" + Answer + "' && `professor` = '" + name + "'";
                    cmd.Connection = connected;
                    IW = int.Parse(cmd.ExecuteScalar().ToString());
                    connected.Close();

                    series1.Points.AddRange(
                        new SeriesPoint(Answer, IC),
                        new SeriesPoint("Other Answers", IW));
                }

                else if (QT == "Essay")
                {
                    check1 = Answer;
                    connected.Open();
                    cmd.CommandText = "select count(*) from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear +
                        "` WHERE `AnswerQ" + number + "` != '' && `Q" + number + "` != '0' && `professor` = '" + name + "'";
                    cmd.Connection = connected;
                    ENE = int.Parse(cmd.ExecuteScalar().ToString());
                    connected.Close();

                    connected.Open();
                    cmd.CommandText = "select count(*) from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear +
                        "` WHERE `AnswerQ" + number + "` = '' && `Q" + number + "` = '0' && `professor` = '" + name + "'";
                    cmd.Connection = connected;
                    EE = int.Parse(cmd.ExecuteScalar().ToString());
                    connected.Close();

                    series1.Points.AddRange(
                        new SeriesPoint("Have Score", ENE),
                        new SeriesPoint("No Score", EE));
                }

                else if (QT == "Enumeration")
                {
                    check1 = Answer;
                    connected.Open();
                    cmd.CommandText = "select count(*) from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear +
                        "` WHERE `Q" + number + "` != '0' && `professor` = '" + name + "'";
                    cmd.Connection = connected;
                    ENE = int.Parse(cmd.ExecuteScalar().ToString());
                    connected.Close();

                    connected.Open();
                    cmd.CommandText = "select count(*) from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear +
                        "` WHERE `Q" + number + "` = '0' && `professor` = '" + name + "'";
                    cmd.Connection = connected;
                    EE = int.Parse(cmd.ExecuteScalar().ToString());
                    connected.Close();

                    series1.Points.AddRange(
                        new SeriesPoint("Have Score", ENE),
                        new SeriesPoint("No Score", EE));
                }

                series1.Label.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
                series1.Label.TextPattern = "{A}: {V}({VP:p0})";
                series1.LegendTextPattern = "{A}";
                DoughnutChart.Legend.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
                DoughnutChart.Legend.MarkerMode = LegendMarkerMode.Marker;
                DoughnutChart.Legend.Title.Text = "Legends:";
                DoughnutChart.Legend.Title.Visible = true;
                DoughnutChart.Legend.Title.Alignment = StringAlignment.Near;
                DoughnutChart.Legend.AlignmentVertical = LegendAlignmentVertical.Center;
                DoughnutChart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                DoughnutChart.Series.Add(series1);
                chartTitle1.Font = new Font("Microsoft Sans Serif", 11.75F, FontStyle.Regular, GraphicsUnit.Point);
                chartTitle1.WordWrap = true;

                if (itemtype == "Single Score")
                {
                    chartTitle1.Text = "Question <b>" + firstnumber + ": " + Question + "</b>";
                }
                
                else if (itemtype == "Multiple Score")
                {
                    chartTitle1.Text = "Question <b>" + firstnumber + "-" + lastnumber + ": " + Question + "</b>";
                }

                PieTotalLabel totalLabel = ((DoughnutSeriesView)DoughnutChart.Series["Series 1"].View).TotalLabel;
                totalLabel.Visible = true;
                //totalLabel.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point);

                if (QT == "Multiple Choice")
                {
                    if (AC == Answer)
                        totalLabel.TextPattern = "Answer\nA\n\n" + A.ToString() + " student/s is/are\ncorrect in this\nquestion";

                    else if (BC == Answer)
                        totalLabel.TextPattern = "Answer\nB\n\n" + B.ToString() + " student/s is/are\ncorrect in this\nquestion";

                    else if (CC == Answer)
                        totalLabel.TextPattern = "Answer\nC\n\n" + C.ToString() + " student/s is/are\ncorrect in this\nquestion";

                    else if (DC == Answer)
                        totalLabel.TextPattern = "Answer\nD\n\n" + D.ToString() + " student/s is/are\ncorrect in this\nquestion";
                }

                else if (QT == "True/False")
                {
                    if (Answer == "True")
                        totalLabel.TextPattern = "Answer\nTrue\n\n" + TFT.ToString() + " student/s is/are\ncorrect in this\nquestion";

                    else if (Answer == "False")
                        totalLabel.TextPattern = "Answer\nFalse\n\n" + TFF.ToString() + " student/s is/are\ncorrect in this\nquestion";
                }

                else if (QT == "True/Identify")
                {
                    if (Answer == "True")
                        totalLabel.TextPattern = "Answer\nTrue\n\n" + TIT.ToString() + " student/s is/are\ncorrect in this\nquestion";

                    else if (Answer != "True" && Answer == check)
                        totalLabel.TextPattern = "Answer\n" + Answer + "\n\n" + TII.ToString() + " student/s is/are\ncorrect in this\nquestion";

                    else if (Answer != check && Answer != "True")
                        totalLabel.TextPattern = "Answer\nOther Answers\n\n" + TIO.ToString() + " student/s is/are\ncorrect in this\nquestion";
                }

                else if (QT == "Identification")
                {
                    if (Answer == check1)
                        totalLabel.TextPattern = "Answer\n" + Answer + "\n\n" + IC.ToString() + " student/s is/are\ncorrect in this\nquestion";

                    else if (Answer != check1)
                        totalLabel.TextPattern = "Answer\nOther Answers\n\n" + IW.ToString() + " student/s is/are\ncorrect in this\nquestion";
                }

                else if (QT == "Essay")
                    totalLabel.TextPattern = ENE.ToString() + "/" + (ENE + EE).ToString() + "\n students have score \nin this question.";

                else if (QT == "Enumeration")
                    totalLabel.TextPattern = ENE.ToString() + "/" + (ENE + EE).ToString() + "\n students have score \nin this question.";

                DoughnutChart.Titles.Add(chartTitle1);
                panel2.Controls.Add(DoughnutChart);
            }

            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LastID()
        {
            cmd.CommandText = "select id from `" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear + "` order by id desc limit 1"; ;
            cmd.Connection = connected;
            connected.Open();
            MySqlDataReader dr1 = cmd.ExecuteReader();

            while (dr1.Read())
            {
                id = (Int32.Parse(dr1["id"].ToString()));
                iddup = id + 2;
            }
            connected.Close();
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
                    Subject.Properties.Items.Add(dr["subject" + addtb + ""].ToString());

                    if (addtb == 1)
                        Subject.Text = dr["subject" + addtb + ""].ToString();

                    else
                        Subject.SelectedIndex = -1;

                } while (numberofsubject > addtb);

            }
            connected.Close();
        }

        private void Comparison()
        {
            cmd.CommandText = "select * from `" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear + "`";
            cmd.Connection = connected;
            connected.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                passingscore = (Int32.Parse(dr["passingscore"].ToString()));
            }
            connected.Close();

            connected = new MySqlConnection(con);
            cmd.CommandText = "select count(*) from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") 
                + "_" + schoolyear + "` where professor = '" + name + "'";
            cmd.Connection = connected;
            connected.Open();
            int count = int.Parse(cmd.ExecuteScalar().ToString());
            connected.Close();

            cb1.Items.Clear();
            cmd.CommandText = "select * from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear +
            "` where professor = '" + name + "'";
            cmd.Connection = connected;
            connected.Open();
            MySqlDataReader dr1 = cmd.ExecuteReader();

            while (dr1.Read())
            {
                cb1.Items.Add(dr1["score"].ToString());
            }
            connected.Close();

            for (int addtb = 0; addtb < cb1.Items.Count; addtb++)
            {
                int cbint = int.Parse(cb1.Items[addtb].ToString());

                if (cbint >= passingscore)
                    passstud = passstud + 1;
            }

            Range.Text = passstud.ToString() + "/" + count.ToString() + " pass this examination.";
        }

        private void Exam_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connected = new MySqlConnection(con);
                cmd.CommandText = "select count(*) from information_schema.tables where table_name = 'result_" + Exam.Text.Replace("-", "")
                    + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear + "' AND TABLE_SCHEMA='examination'";
                cmd.Connection = connected;
                connected.Open();
                string count = cmd.ExecuteScalar().ToString();
                connected.Close();

                if (count == "0")
                {
                    if (Exam.Text != "")
                    {
                        passstud = 0;
                        panel2.Controls.Clear();
                        dataGridView1.Columns.Clear();
                        dataGridView1.Refresh();
                        Essential.Visible = false;
                        panel2.Visible = false;
                        Students.Visible = false;
                        Range.Visible = false;
                        MessageBox.Show("Record not exist.");
                    }
                }

                else if (count == "1")
                {
                    number = 1;
                    Comparison();
                    LastID();
                    FillUp();

                    connected.Open();
                    cmd.CommandText = "select count(*) from `result_" + Exam.Text.Replace("-", "") + "_" + Subject.Text.Replace(" ", "") + "_" + schoolyear + "`";
                    cmd.Connection = connected;
                    totaltake = int.Parse(cmd.ExecuteScalar().ToString());
                    connected.Close();

                    Students.Visible = true;
                    Students.Text = totaltake.ToString() + " student/s take this examination.";

                    connected = new MySqlConnection(con);
                    cmd.CommandText = "select `name`, `gender`, `course`, `year`, `section`, `score` from `result_" + Exam.Text.Replace("-", "") + "_"
                        + Subject.Text.Replace(" ", "") + "_" + schoolyear + "`";
                    cmd.Connection = connected;
                    connected.Open();

                    using (MySqlDataAdapter msda = new MySqlDataAdapter(cmd))
                    {
                        using (DataTable DT = new DataTable())
                        { 
                            msda.Fill(DT);
                            dataGridView1.DataSource = DT;
                        }
                    }

                    connected.Close();
                    panel2.Visible = true;
                    Essential.Visible = true;
                    Range.Visible = true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}