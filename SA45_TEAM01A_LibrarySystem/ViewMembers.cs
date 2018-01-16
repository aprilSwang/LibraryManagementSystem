using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; //assume added in 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using ClassLibrary3;

namespace SA45_TEAM01A_LibrarySystem
{
    public partial class ViewMembers : Form
    {
        public ViewMembers()
        {
            InitializeComponent();
        }

        private void ViewMembers_Load(object sender, EventArgs e)
        {
            SA45TEAM01ALibraryEntities context = new SA45TEAM01ALibraryEntities();
            var q = context.Users.Where(x => x.Status != "Inactive").Select(x => new { x.User_ID, x.Name, x.Email, x.Phone_no, x.Book_due, x.Category, x.Status });
            dataGridView1.DataSource = q.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Add a New Member";
            this.Hide();
            var newAMForm = new AddMember();
            newAMForm.Closed += (s, args) => this.Close();
            newAMForm.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh_click();
        }

        private void btnRefresh_click()
        {
            SA45TEAM01ALibraryEntities context = new SA45TEAM01ALibraryEntities();
            var q = context.Users.Where(x => x.Status != "Inactive").Select(x => new { x.User_ID, x.Name, x.Email, x.Phone_no, x.Book_due, x.Category, x.Status });
            dataGridView1.DataSource = q.ToList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int rV = 0;
            foreach (DataGridViewRow dg in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(dg.Cells[0].Value) == true)
                {
                    rV++;
                }
            }
            if (rV > 0)
            {
                DialogResult dr = MessageBox.Show("Confirm Deletion for these row(s)?", "Warning!", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    SA45TEAM01ALibraryEntities context = new SA45TEAM01ALibraryEntities();
                    foreach (DataGridViewRow dg in dataGridView1.Rows)
                    {
                        if (Convert.ToBoolean(dg.Cells[0].Value) == true)
                        {
                            int x2 = Convert.ToInt32(dg.Cells[1].Value);
                            var q = context.Users.Where(x => x.User_ID == x2).FirstOrDefault();
                            User A = q;
                            using (TransactionScope ts = new TransactionScope())
                            {
                                q.Status = "Inactive";
                                context.SaveChanges();
                                ts.Complete();
                            }
                        }
                    }
                    Messages newM = new Messages();
                    newM.SaveMessage();
                    btnRefresh_click();
                }
            }
            else
            {
                this.Hide();
                var newDMForm = new DeleteMember();
                newDMForm.Closed += (s, args) => this.Close();
                newDMForm.Show();

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rV = 0;
            foreach (DataGridViewRow dg in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(dg.Cells[0].Value) == true)
                {
                    rV++;
                }
            }
            if (rV > 1)
            {
                MessageBox.Show("Only 1 user can be selected at a time for edits. Please try again.");
            }
            else if (rV == 1)
            {
                foreach (DataGridViewRow dg in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(dg.Cells[0].Value) == true)
                    {
                        int x = Convert.ToInt32(dg.Cells[1].Value);
                        this.Hide();
                        var newEMForm = new Edit_Member();
                        newEMForm.setStartupID = x;
                        newEMForm.Closed += (s, args) => this.Close();
                        newEMForm.Show();
                    }
                }
            }
            else
            {
                this.Hide();
                var newEMForm = new Edit_Member();
                newEMForm.Closed += (s, args) => this.Close();
                newEMForm.Show();

            }
            rV = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string conS = "data source =(local);integrated security=sspi;initial catalog=SA45TEAM01ALibrary";
            SqlConnection cn = new SqlConnection(conS);
            SqlCommand cm = new SqlCommand();
            SqlDataAdapter adapter;
            DataTable dt;

            cn.Open();
            adapter = new SqlDataAdapter("select user_id,name,email,Phone_no,book_due,category from users where (user_ID like '%" + txtSearch.Text + "%' or email like '%" + txtSearch.Text + "%' or phone_no like '%" + txtSearch.Text + "%') and not (status = 'inactive')", cn);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //int x = 0;
            //foreach (DataGridViewRow dg in dataGridView1.Rows)
            //{
            //    if (dg.Cells[0].Value!=null)
            //    {
            //        x++;
            //    }
            //}
            //if (x > 0)
            //    btnEdit.Enabled = false;
            //else
            //    btnEdit.Enabled = true;

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newMForm = new Main();
            newMForm.Closed += (s, args) => this.Close();
            newMForm.Show();
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
    }
}
