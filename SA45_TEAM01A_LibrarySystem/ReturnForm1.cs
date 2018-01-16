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
using System.Transactions;
using ClassLibrary3;

namespace SA45_TEAM01A_LibrarySystem
{
    public partial class ReturnForm1 : Form
    {

        public ReturnForm1()
        {
            InitializeComponent();
        }
        SA45TEAM01ALibraryEntities context = new SA45TEAM01ALibraryEntities();

        public void FormRefresh()
        {
            string conS = "data source =(local);integrated security=sspi;initial catalog=SA45TEAM01ALibrary";
            SqlConnection cn = new SqlConnection(conS);
            SqlCommand cm = new SqlCommand();
            SqlDataAdapter adapter;
            DataTable dt;

            cn.Open();
            adapter = new SqlDataAdapter("select id.issue_id,id.book_id,bl.title,id.user_id,u.name,id.issue_date,id.due_date from issue_details id, booklist bl,users u where id.user_id=u.user_id and id.book_id=bl.book_id and id.rental_status='out' order by id.issue_id", cn);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DateTime dateDue = Convert.ToDateTime(dataGridView1.Rows[i].Cells[7].Value);
                if ((dateDue - DateTime.Today).TotalDays < 5)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
            }

            toolStripStatusLabel2.Text = "List of borrowed books.";

        }
        private void ReturnForm1_Load(object sender, EventArgs e)
        {
            FormRefresh();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string conS = "data source =(local);integrated security=sspi;initial catalog=SA45TEAM01ALibrary";
            SqlConnection cn = new SqlConnection(conS);
            SqlCommand cm = new SqlCommand();
            SqlDataAdapter adapter;
            DataTable dt;

            cn.Open();
            adapter = new SqlDataAdapter("select id.issue_id,id.book_id,bl.title,id.user_id,u.name,id.issue_date,id.due_date from issue_details id, booklist bl, users u where (id.book_id=bl.book_id and id.user_id=u.user_id) and (id.book_ID like '%" + txtSearch.Text + "%' or id.user_ID like '%" + txtSearch.Text + "%' or id.issue_id like '%" + txtSearch.Text + "%' or bl.title like '%" + txtSearch.Text + "%' or u.name like '%" + txtSearch.Text + "%')", cn);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            bool isBlank = true;
            foreach (DataGridViewRow dgRow in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell CbxCell = (DataGridViewCheckBoxCell)dgRow.Cells[0];
                if (Convert.ToBoolean(CbxCell.Value) == false)
                {
                    isBlank = true;
                }
                else
                {
                    isBlank = false; break;
                }
            }

            if (isBlank == true)
            {
                MessageBox.Show("Select books first");
            }
            else
            {
                DialogResult result = new DialogResult();
                result = MessageBox.Show("Are Books received?", "Receiving Books", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgRow1 in dataGridView1.Rows)
                    {

                        if (Convert.ToBoolean(dgRow1.Cells[0].Value))
                        {
                            using (TransactionScope ts = new TransactionScope())
                            {
                                string sID = dgRow1.Cells[1].Value.ToString();
                                string uID = dgRow1.Cells[4].Value.ToString();

                                Issue_Details id = context.Issue_Details.Where(x => x.Issue_ID.ToString() == sID && x.User_ID.ToString() == uID).First();
                                id.Rental_Status = "IN";
                                id.Return_Date = DateTime.Today.ToString();

                                User u = context.Users.Where(x => x.User_ID.ToString() == uID).First();
                                u.Book_due--;

                                context.SaveChanges();
                                ts.Complete();
                            }
                        }

                        toolStripStatusLabel2.Text = "Changes Updated.";
                    }
                }
                else
                {
                    FormRefresh();
                }
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            FormRefresh();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FormRefresh();
        }
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.IsBalloon = true;
            tt.InitialDelay = 0;
            tt.ShowAlways = true;
            tt.SetToolTip(txtSearch, "Enter memberID/issueID/bookID");
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            //tt.Dispose();
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newMForm = new Main();
            newMForm.Closed += (s, args) => this.Close();
            newMForm.Show();
        }

        private void linkLogout_LinkClicked(object sender, EventArgs e)
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
