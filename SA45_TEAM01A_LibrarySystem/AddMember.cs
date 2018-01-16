using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Transactions;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary3;

namespace SA45_TEAM01A_LibrarySystem
{
    public partial class AddMember : Form
    {
        public AddMember()
        {
            InitializeComponent();
        }

        private void mtxtMN_Click(object sender, EventArgs e)
        {
            mtxtMN.SelectionStart = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Length < 1 && ((txtEmail.Text.Length < 5) || (mtxtMN.Text.Length < 8)))
            {
                MessageBox.Show("Requires at least a valid name and contact");
            }
            else
            {
                SA45TEAM01ALibraryEntities context = new SA45TEAM01ALibraryEntities();
                User newUser = new User();
                using (TransactionScope ts = new TransactionScope())
                {
                    newUser.Name = txtTitle.Text;
                    newUser.Email = txtEmail.Text;
                    newUser.Phone_no = int.Parse(mtxtMN.Text);
                    newUser.Category = cmbMemType.Text;

                    context.Users.Add(newUser);
                    context.SaveChanges();
                    ts.Complete();
                }

                Messages A = new Messages();
                A.SaveMessage();
                txtTitle.Clear();
                txtEmail.Clear();
                mtxtMN.Clear();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newVMForm = new ViewMembers();
            newVMForm.Closed += (s, args) => this.Close();
            newVMForm.Show();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTitle.Text = String.Empty;
            txtEmail.Text = String.Empty;
            mtxtMN.Text = String.Empty;

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

        private void buttonH_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newMForm = new Main();
            newMForm.Closed += (s, args) => this.Close();
            newMForm.Show();
        }
    }
}
