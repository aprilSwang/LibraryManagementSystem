using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary3;

namespace SA45_TEAM01A_LibrarySystem
{
    public partial class EditBook : Form
    {
        string newTitle, newAuthor, newGenre, newLG, newISBN;
        int? newYP;
        int startupID;

        public EditBook()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            SA45TEAM01ALibraryEntities d = new SA45TEAM01ALibraryEntities();
            try
            {
                int a = int.Parse(mtxtBID.Text);
                var qty = from x in d.booklists where x.Book_ID == a select x;

                string isbn = qty.Single().ISBN;
                string title = qty.Single().Title;
                int bookid = qty.Single().Book_ID;
                string lang = qty.Single().Language;
                string categ = qty.Single().Category;
                string author = qty.Single().Author;
                int? yop = qty.Single().Year_of_Publication;

                txtTitle.Text = title;
                txtAuthor.Text = author;
                cmbYear.Text = yop.ToString();
                txtGenre.Text = categ;
                txtLanguage.Text = lang;
                txbISBN.Text = isbn;

                panelTB.Visible = true;
                panelBTN.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid ID entered");
            }
            if (txtTitle.Text.Length > 0)
                mtxtBID.Enabled = false;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newBForm = new ViewBooks();
            newBForm.Closed += (s, args) => this.Close();
            newBForm.Show();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newEBForm = new EditBook();
            newEBForm.Closed += (s, args) => this.Close();
            newEBForm.Show();
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

        private void Save_Click(object sender, EventArgs e)
        {
            newAuthor = txtAuthor.Text;
            newTitle = txtAuthor.Text;
            newYP = Convert.ToInt32(cmbYear.SelectedText);
            newGenre = txtGenre.Text;
            newLG = txtLanguage.Text;
            newISBN = txbISBN.Text;

            int a = int.Parse(mtxtBID.Text);
            SA45TEAM01ALibraryEntities d = new SA45TEAM01ALibraryEntities();
            booklist b = d.booklists.Where(x => x.Book_ID == a).First();

            if ((b.Author != newAuthor) || (b.Title != newTitle) || (b.Year_of_Publication != newYP) || (b.Category != newGenre) || (b.Language != newLG) || (b.ISBN != newISBN))
            {
                b.Author = newAuthor;
                b.Title = newTitle;
                b.Year_of_Publication = newYP;
                b.Category = newGenre;
                b.Language = newLG;
                b.ISBN = newISBN;
                d.SaveChanges();

                Messages A = new Messages();
                A.SaveMessage();
            }
            else
                MessageBox.Show("Please make edits in order to Save or click Cancel to Return to Books Menu");
        }

        private void EditBook_Load(object sender, EventArgs e)
        {
            for (int i = 1700; i <= DateTime.Now.Year; i++)
            {
                ComboBox item = new ComboBox();
                cmbYear.Items.Add(i.ToString());
            }
        }

        private void mtxtBID_Click(object sender, EventArgs e)
        {
            mtxtBID.SelectionStart = 0;
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
