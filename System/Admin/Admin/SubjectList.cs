using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Lan_Based_Examination
{
    public partial class SubjectList : DevExpress.XtraEditors.XtraForm
    {
        private string con;
        private MySqlConnection connected;
        MySqlCommand cmd = new MySqlCommand();
        string status, idtb, logger;
        int id, idint;

        public SubjectList()
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

        private void Delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Delete this subject?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    status = "insert";
                    connected = new MySqlConnection(con);
                    cmd.CommandText = "select * from subject where subject = '" + SL.Text + "'";
                    cmd.Connection = connected;
                    connected.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        idtb = (dr["id"].ToString());
                        idint = Int32.Parse(idtb);
                    }

                    connected.Close();

                    cmd.CommandText = "delete from subject where subject = '" + SL.Text + "'";
                    cmd.Connection = connected;
                    connected.Open();
                    cmd.ExecuteNonQuery();
                    connected.Close();

                    connected.Open();
                    cmd.CommandText = "select count(*) from subject";
                    cmd.Connection = connected;
                    string count = cmd.ExecuteScalar().ToString();
                    int intcount = Int32.Parse(count);
                    connected.Close();

                    int idminus = idint;
                    do
                    {
                        idint++;
                        connected.Open();
                        cmd.CommandText = "Update subject set `id` = '" + idminus + "' where id = '" + idint + "'";
                        cmd.Connection = connected;
                        cmd.ExecuteNonQuery();
                        connected.Close();
                        idminus++;

                    } while (idint == intcount);

                    MessageBox.Show("Deleted");
                    Clear();
                }

                catch (Exception err)
                {
                    MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddUpdate_Click(object sender, EventArgs e)
        {
            if (SN.Text == "" || SC.Text == "" || SU.Text == "")
                MessageBox.Show("Please enter the values.");

            else
            {
                if (status == "insert")
                    InsertSubject();

                else if (status == "update")
                    UpdateSubject();
            }
        }

        private void SL_SelectedIndexChanged(object sender, EventArgs e)
        {
            status = "update";
            Delete.Enabled = true;
            AddUpdate.Text = "Update";

            try
            {
                connected = new MySqlConnection(con);
                cmd.CommandText = "select * from subject where subject = '" + SL.Text + "'";
                cmd.Connection = connected;
                connected.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    idtb = (dr["id"].ToString());
                    idint = Int32.Parse(idtb);
                    SN.Text = dr["subject"].ToString();
                    SC.Text = dr["subject_code"].ToString();
                    SU.Text = dr["units"].ToString();
                }
                connected.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SU_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Numbers only.");
            }
        }

        private void CBoxUpdate()
        {
            SL.Properties.Items.Clear();
            connected = new MySqlConnection(con);
            cmd.CommandText = "select * from subject";
            cmd.Connection = connected;
            connected.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SL.Properties.Items.Add(dr["subject"].ToString());
            }

            connected.Close();
        }

        private void SubjectList_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            status = "insert";
            CBoxUpdate();
        }

        private void UpdateSubject()
        {
            connected.Open();
            cmd.CommandText = "Update subject set `subject_code` = '" + SC.Text + "', `units` = '" + SU.Text + "'" +
                ",`subject` = '" + SN.Text + "' where id = " + idtb + "";
            cmd.Connection = connected;
            cmd.ExecuteNonQuery();
            connected.Close();
            MessageBox.Show("Updated");
            Clear();
        }

        private string Count()
        {
            connected = new MySqlConnection(con);
            connected.Open();
            cmd.CommandText = "select count(*) from subject where subject ='" + SN.Text + "'";
            cmd.Connection = connected;
            string count = cmd.ExecuteScalar().ToString();
            connected.Close();
            return count;
        }

        public void Check()
        {
            connected = new MySqlConnection(con);
            cmd.CommandText = "select * from subject order by id desc limit 1";
            cmd.Connection = connected;
            connected.Open();
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                id = (Int32.Parse(dr["id"].ToString()));
            }
            connected.Close();
        }

        private void SubjectList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                MessageBox.Show("Alt + 1 = Add or Update the Subject Information\nAlt + 2 = Clear All the Fields\nAlt + 3 or " +
                    "Delete = Delete the Subject Information", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            else if ((e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1) && e.Modifiers == Keys.Alt)
                AddUpdate_Click(sender, EventArgs.Empty);

            else if ((e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2) && e.Modifiers == Keys.Alt)
                Clearbtn_Click(sender, EventArgs.Empty);

            else if (((e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3) && e.Modifiers == Keys.Alt) || e.KeyCode == Keys.Delete)
                Delete_Click(sender, EventArgs.Empty);
        }

        private void InsertSubject()
        {
            string count = Count();

            if (count == "1")
            {
                string sn = "", sc = "", su = "";

                try
                {
                    connected = new MySqlConnection(con);
                    cmd.CommandText = "select * from subject";
                    cmd.Connection = connected;
                    connected.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        sn = (dr["subject"].ToString());
                        sc = (dr["subject_code"].ToString());
                        su = (dr["units"].ToString());
                    }

                    connected.Close();

                    DialogResult dialogResult = MessageBox.Show("This subject is already listed.\n\nSubject Name: " + sn + "" +
                    "\n Subject Code: " + sc + "\n Unit/s: " + su + "\n\nOverwrite it?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        UpdateSubject();
                    }
                }

                catch (Exception err)
                {
                    MessageBox.Show(err + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("Please call the administrator for immediate assistance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (count == "0")
            {
                Check();
                id++;
                logger = "Inserted an subject: " + SN.Text + "";
                connected.Open();
                cmd.Connection = connected;
                cmd.CommandText = "INSERT INTO subject(`id`, `subject`, `subject_code`, `units`) " +
                "VALUES('" + id + "', '" + SN.Text + "','" + SC.Text + "','" + SU.Text + "')";
                cmd.Connection = connected;
                cmd.ExecuteNonQuery();
                connected.Close();
                MessageBox.Show("Saved");
                Clear();
            }
        }

        private void Clear()
        {
            SN.Enabled = true;
            CBoxUpdate();
            SL.SelectedIndex = -1;
            SN.Text = "";
            SC.Text = "";
            SU.Text = "";
            status = "insert";
            AddUpdate.Text = "Add";
            Delete.Enabled = false;
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}