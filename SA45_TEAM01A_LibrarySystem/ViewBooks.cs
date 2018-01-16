using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using System.Data.SqlClient;
using ClassLibrary3;

namespace SA45_TEAM01A_LibrarySystem
{
    public partial class ViewBooks : Form
    {
        public ViewBooks()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newABForm = new AddBook();
            newABForm.Closed += (s, args) => this.Close();
            newABForm.Show();
        }

        private void ViewBooks_Load(object sender, EventArgs e)
        {
            newDataPlease();
        }

        private void newDataPlease()
        {
            SA45TEAM01ALibraryEntities c = new SA45TEAM01ALibraryEntities();
            var q = from x in c.booklists select new { x.ISBN, x.Title, x.Book_ID, x.Language, x.Category, x.Author, x.Year_of_Publication };
            dataGridView1.DataSource = q.ToList();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //SA45TEAM01ALibraryEntities d = new SA45TEAM01ALibraryEntities();
          
            //int a = int.Parse(Book_ID);
            //booklist b = d.booklists.Where(x => x.Book_ID == a).First();
            //b.Disposed = "Yes";
            //d.SaveChanges();
            //MessageBox.Show("Deleted Successfully");

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
                            int x2 = Convert.ToInt32(dg.Cells[3].Value);
                            var q = context.booklists.Where(x => x.Book_ID == x2).FirstOrDefault();
                            booklist A = q;
                            using (TransactionScope ts = new TransactionScope())
                            {
                                q.Disposed = "Yes";
                                context.SaveChanges();
                                ts.Complete();
                            }
                        }
                    }
                    Messages newM = new Messages();
                    newM.SaveMessage();
                    newDataPlease();
                }
            }
            else
                MessageBox.Show("Please select checkbox(es) to delete first");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            string conS = "data source =(local);integrated security=sspi;initial catalog=SA45TEAM01ALibrary";
            SqlConnection cn = new SqlConnection(conS);
            SqlCommand cm = new SqlCommand();
            SqlDataAdapter adapter;
            DataTable dt;
                     

          cn.Open();
            adapter = new SqlDataAdapter("select ISBN, Title, Book_ID, Language, Category, Author, Year_of_Publication from booklist where ISBN  like '%" + txtSearch.Text + "%' or Title  like '%" + txtSearch.Text + "%' or Book_ID  like '%" + txtSearch.Text + "%' or Language  like '%" + txtSearch.Text + "%' or Category like '%" + txtSearch.Text + "%' or Author like '%" + txtSearch.Text + "%' or Year_of_Publication like '%" + txtSearch.Text + "%' ", cn);
            dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newEBForm = new EditBook();
            newEBForm.Closed += (s, args) => this.Close();
            newEBForm.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            newDataPlease();
        }

        private void btnH_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newBForm = new Main();
            newBForm.Closed += (s, args) => this.Close();
            newBForm.Show();
        }
    }
}
