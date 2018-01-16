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

    public partial class BorrowForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source = (local);" + "Initial Catalog =SA45TEAM01ALibrary;" + " Integrated Security = SSPI");

        public BorrowForm()
        {
            InitializeComponent();
        }


        public void FormBorrow()
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select ISBN,Title,Book_ID,Language,Category,Author,Year_of_publication from booklist where (Book_ID not in(select book_id from Issue_Details where Rental_Status='out'))";

            con.Open();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            con.Close();

            for (int i = 1; i < dt.Columns.Count; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    dataGridView1.Rows[j].Cells[i].ReadOnly = true;
                }

            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Query f = new Query();
            DialogResult r = f.ShowDialog();
            if (r == DialogResult.OK)
            {
                if (f.getIDValue.Length > 0)
                    txtID.Text = f.getIDValue;
                if (f.getNameValue.Length > 0)
                txtName.Text = f.getNameValue;
            }

        }


        //Enter Button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con1 = new SqlConnection("Data Source = (local);" + "Initial Catalog =SA45TEAM01ALibrary;" + " Integrated Security = SSPI");
                SqlCommand cm = new SqlCommand("Select * from users where user_ID = " + txtID.Text, con1);
                SqlDataAdapter da = new SqlDataAdapter(cm);
                DataSet ds = new DataSet();
                con1.Open();
                da.Fill(ds, "Users");
                con1.Close();
                txtName.Text = ds.Tables[0].Rows[0][1].ToString();
                tssl1.Text = "Select checkbox for books to borrow and click Submit";
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid ID. Please enter a valid ID");
            }
        }


        private void BorrowForm_Load(object sender, EventArgs e)
        {
            FormBorrow();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FormBorrow();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            int rV = 0;
            foreach (DataGridViewRow dg in dataGridView1.Rows)
            {
                if (Convert.ToBoolean(dg.Cells[0].Value) == true)
                {
                    rV++;
                }
            }
            if (rV > 0 && (txtName.Text.Length > 0))
            {
                DialogResult result = new DialogResult();
                result = MessageBox.Show("Proceed with borrowing?", "Borrowing books", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    SA45TEAM01ALibraryEntities context = new SA45TEAM01ALibraryEntities();

                    using (TransactionScope ts = new TransactionScope())
                    {
                        foreach (DataGridViewRow dgRow in dataGridView1.Rows)
                        {
                            if (dgRow.Cells[0].Value != null)
                            {
                                int selected1 = Convert.ToInt32(dgRow.Cells[3].Value.ToString());
                                int newIssueID = context.Issue_Details.Select(x => x.Issue_ID).Max() + 1;

                                Issue_Details id = new Issue_Details();
                                id.Issue_ID = newIssueID;
                                id.Issue_Date = DateTime.Today.ToString();
                                id.Due_Date = DateTime.Today.AddDays(20).ToString();
                                id.Book_ID = selected1;
                                id.User_ID = Convert.ToInt32(txtID.Text.ToString());
                                id.Rental_Status = "OUT";
                                id.Return_Date = null;

                                context.Issue_Details.Add(id);
                                string uid = txtID.Text;
                                User m = context.Users.Where(x => x.User_ID.ToString() == uid).First();
                                m.Book_due++;
                                context.SaveChanges();
                            }
                        }
                        ts.Complete();
                    }
                    FormBorrow();
                }
            }
            else if (rV > 0)
                MessageBox.Show("Please input a valid user id");
            else
                MessageBox.Show("Please select checkboxes for books to borrow");
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newMForm = new Main();
            newMForm.Closed += (s, args) => this.Close();
            newMForm.Show();
        }
    }
}