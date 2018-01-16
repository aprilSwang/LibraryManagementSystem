using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary3;

namespace SA45_TEAM01A_LibrarySystem
{
    public partial class Edit_Member : Form
    {
        public Edit_Member()
        {
            InitializeComponent();
        }

        string newName, newEmail, newCat;
        int? newPN;
        int startupID;

        public int setStartupID
        {
            set
            {
                startupID = value;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string qq2 = mtextUID.Text.TrimStart(new Char[] { '0' });

            if (qq2.Length < 1)
            {
                MessageBox.Show("Please input a valid ID");
            }
            else
            {
                SA45TEAM01ALibraryEntities context = new SA45TEAM01ALibraryEntities();
                string q = "";
                try
                {
                    q = context.Users.Where(x => x.User_ID.ToString() == qq2).Where(x => x.Status != "Inactive").Select(x => x.Name).First();
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid ID. Please try again.");
                    mtextUID.Text = String.Empty;
                }
                if (q.Length < 1)
                {
                }
                else
                {
                    btnSearch.Visible = false;
                    mtextUID.BackColor = System.Drawing.SystemColors.ScrollBar;
                    mtextUID.ReadOnly = true;
                    lblName.Visible = true;
                    lblEmail.Visible = true;
                    lblPN.Visible = true;
                    lblCat.Visible = true;
                    txtName.Visible = true;
                    txtEmail.Visible = true;
                    mtextPN.Visible = true;
                    cboxCat.Visible = true;
                    btnSave.Visible = true;
                    btnClear.Visible = true;
                    toolStripStatusLabel1.Text = "Click Save to Confirm, Cancel to Close Screen";

                    txtName.Text = q;
                    string q1 = context.Users.Where(x => x.User_ID.ToString() == qq2).Select(x => x.Email).First();
                    txtEmail.Text = q1;
                    int? q2 = context.Users.Where(x => x.User_ID.ToString() == qq2).Select(x => x.Phone_no).First();
                    mtextPN.Text = q2.ToString();
                    string q3 = context.Users.Where(x => x.User_ID.ToString() == qq2).Select(x => x.Category).First();
                    cboxCat.Text = q3;
                }
            }
        }

        private void mtextUID_Click(object sender, EventArgs e)
        {
            mtextUID.SelectionStart = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnSearch.Visible = true;
            mtextUID.Text = String.Empty;
            mtextUID.BackColor = System.Drawing.SystemColors.Window;
            mtextUID.ReadOnly = false;
            lblName.Visible = false;
            lblEmail.Visible = false;
            lblPN.Visible = false;
            lblCat.Visible = false;
            txtName.Visible = false;
            txtEmail.Visible = false;
            mtextPN.Visible = false;
            cboxCat.Visible = false;
            btnSave.Visible = false;
            btnClear.Visible = false;
        }

        private void Edit_Member_Load(object sender, EventArgs e)
        {
            if (startupID > 0)
            {
                mtextUID.Text = startupID.ToString();
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string qq2 = mtextUID.Text.TrimStart(new Char[] { '0' });

            if (txtName.Text.Length < 1)
                MessageBox.Show("Please Enter a valid name");
            else
            {
                SA45TEAM01ALibraryEntities context = new SA45TEAM01ALibraryEntities();
                User a = context.Users.Where(x => x.User_ID.ToString() == qq2).FirstOrDefault();
                newName = txtName.Text;
                newEmail = txtEmail.Text;
                newCat = cboxCat.Text;
                newPN = Convert.ToInt32(mtextPN.Text);
                string q = context.Users.Where(x => x.User_ID.ToString() == qq2).Select(x => x.Name).First();
                string q1 = context.Users.Where(x => x.User_ID.ToString() == qq2).Select(x => x.Email).First();
                int? q2 = context.Users.Where(x => x.User_ID.ToString() == qq2).Select(x => x.Phone_no).First();
                string q3 = context.Users.Where(x => x.User_ID.ToString() == qq2).Select(x => x.Category).First();

                using (TransactionScope ts = new TransactionScope())
                {
                    if (newName != q)
                        a.Name = newName;
                    if (newPN != q2)
                        a.Phone_no = newPN;
                    if (newEmail != q1)
                        a.Email = newEmail;
                    if (newCat != q3)
                        a.Category = newCat;

                    context.SaveChanges();
                    ts.Complete();
                }

                btnSearch.Visible = true;
                mtextUID.Text = String.Empty;
                mtextUID.BackColor = System.Drawing.SystemColors.Window;
                mtextUID.ReadOnly = false;
                lblName.Visible = false;
                lblEmail.Visible = false;
                lblPN.Visible = false;
                lblCat.Visible = false;
                txtName.Visible = false;
                txtEmail.Visible = false;
                mtextPN.Visible = false;
                cboxCat.Visible = false;
                btnSave.Visible = false;
                btnClear.Visible = false;
                toolStripStatusLabel1.Text = "Input User_ID and click Search";

                Messages A = new Messages();
                A.SaveMessage();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newVMForm = new ViewMembers();
            newVMForm.Closed += (s, args) => this.Close();
            newVMForm.Show();
        }
    }
}
