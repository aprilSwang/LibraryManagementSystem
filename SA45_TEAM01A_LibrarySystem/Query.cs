using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ClassLibrary3;

namespace SA45_TEAM01A_LibrarySystem
{
    public partial class Query : Form
    {
        int member;

        public int Member
        {
            get
            {
                return member;
            }            
        }
        
        public Query()
        {
            InitializeComponent();
        }

        // Search Icon Button
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = (local);" + "Initial Catalog =SA45TEAM01ALibrary;" + " Integrated Security = True");
            int i = 0;
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select User_id,Name,Email,Phone_no,Book_due,Category from Users where name like '%" + txtSearch.Text + "%'" + "or email like '%" + txtSearch.Text + "%' or phone_no like '%" + txtSearch.Text + "%'";

                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());

                dataGridView1.DataSource = dt;
                for (int i1 = 0; i1 < dt.Columns.Count; i1++)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        dataGridView1.Rows[j].Cells[i1].ReadOnly = true;
                    }
                }

                if (i == 0)
                {
                    MessageBox.Show("Username not found!");
                }
                else
                    tssl1.Text = "Select relevant row and click Select";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // Cancel Button
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;            
        }

        public string getIDValue
        {
            get
            {
                return dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
        }

        public string getNameValue
        {
            get
            {
                return dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            member = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());            
        }

        private void btnSelect_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void linkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Movement logO = new Movement();
            logO.Logout();
            this.Hide();
            var newLForm = new Login();
            newLForm.Closed += (s, args) => this.Close();
            newLForm.Show();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newMForm = new Main();
            newMForm.Closed += (s, args) => this.Close();
            newMForm.Show();
        }
    }
}