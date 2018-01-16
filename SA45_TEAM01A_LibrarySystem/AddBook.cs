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
using ClassLibrary3;

namespace SA45_TEAM01A_LibrarySystem
{
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
        }

        private void AddBook_Load(object sender, EventArgs e)
        {
            for (int i = 1700; i <= DateTime.Now.Year; i++)
            {
                ComboBox item = new ComboBox();
                cmbYear.Items.Add(i.ToString());
            }
        }

        private int getSInputs()
        {
            int x;
            x = txtTitle.Text.Length + txtLanguage.Text.Length + txtAuthor.Text.Length + txtGenre.Text.Length + txtISBN.Text.Length;
            return x;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (getSInputs() > 0)
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SA45TEAM01ALibraryEntities c = new SA45TEAM01ALibraryEntities();
                    booklist a = new booklist();
                    a.ISBN = txtTitle.Text.ToString();
                    a.Title = txtTitle.Text.ToString();
                    a.Language = txtLanguage.Text.ToString();
                    a.Category = txtGenre.Text.ToString();
                    a.Author = txtAuthor.Text.ToString();
                    a.Year_of_Publication = Convert.ToInt32(cmbYear.SelectedText);//Convert.ToInt32(cmbYear.Text);
                    c.booklists.Add(a);
                    c.SaveChanges();
                    ts.Complete();
                }

                Messages A = new Messages();
                A.SaveMessage();
            }
            else
                MessageBox.Show("Please Add in Relevant info before Adding new Books");

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newVBForm = new ViewBooks();
            newVBForm.Closed += (s, args) => this.Close();
            newVBForm.Show();
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

        private void btnH_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newMForm = new Main();
            newMForm.Closed += (s, args) => this.Close();
            newMForm.Show();
        }
    }
}
