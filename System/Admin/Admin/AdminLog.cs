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
    public partial class AdminLog : DevExpress.XtraEditors.XtraForm
    {
        private string con;
        private MySqlConnection connected;
        MySqlCommand cmd = new MySqlCommand();
        string username, name, permission, schoolyear, logger, empty = "Yes";

        private void AdminLog_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            dataGridView1.Font = new Font("Microsoft Sans Serif", 16);
            dataGridView1.Font = new Font("Microsoft Sans Serif", 16);
            Fill();
        }

        private void Fill()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();

            try
            {
                connected = new MySqlConnection(con);
                connected.Open();
                cmd.CommandText = "select count(*) from information_schema.tables where table_name='administrator_log' AND TABLE_SCHEMA='examination'";
                cmd.Connection = connected;
                string count = cmd.ExecuteScalar().ToString();
                connected.Close();

                if (count == "1")
                {
                    cmd.CommandText = "select `name`, `username`, `time`, `remarks` from `administrator_log`";
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

                    empty = "No";
                }

                else if (count == "0")
                    MessageBox.Show("Administrator Log is empty.");
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
                    MessageBox.Show("Table Empty.");

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
                            object fileName = "administrator_log";
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

        public void Need(string un, string n, string perm, string sy)
        {
            username = un;
            permission = perm;
            name = n;
            schoolyear = sy;
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            try
            {
                if (empty == "No")
                {
                    logger = "Deleted the records of administrator log.";
                    Log();
                    connected.Open();
                    cmd.CommandText = "truncate table `administrator_log`";
                    cmd.Connection = connected;
                    cmd.ExecuteNonQuery();
                    connected.Close();
                    Fill();
                }

                else if (empty == "Yes")
                    MessageBox.Show("Administrator Log is already empty");
            }

            catch (Exception err)
            {
                MessageBox.Show(err + "\n\nPlease call the administrator for assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Home_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Back?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                logger = "Entered to Admin Account Form";
                Log();
                AdminAccount AC = new AdminAccount();
                AC.Need(username, name, permission, schoolyear);
                AC.Show();
                this.Hide();
            }
        }

        private void AdminLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Home_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.F1)
                MessageBox.Show("Alt + E = Export to Excel\nEsc = Back to Administrator Form\n" +
                    "Delete = Clear All Logs", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else if (e.KeyCode == Keys.Delete)
                Previous_Click(sender, EventArgs.Empty);

            else if (e.KeyCode == Keys.E && e.Modifiers == Keys.Alt)
                Export_Click(sender, EventArgs.Empty);
        }

        private void Xbtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                this.Close();
        }

        private void AdminLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger = "Exit Application";
            Log();
        }

        public AdminLog()
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
                Fill();
            }
            catch (Exception err)
            {
                MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}