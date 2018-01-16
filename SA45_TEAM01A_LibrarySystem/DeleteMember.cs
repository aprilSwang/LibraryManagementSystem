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
using System.Transactions;

namespace SA45_TEAM01A_LibrarySystem
{
    public partial class DeleteMember : Form
    {
        public DeleteMember()
        {
            InitializeComponent();
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
                    txtName.Visible = true;
                    txtEmail.Visible = true;
                    mtextPN.Visible = true;
                    btnDel.Visible = true;
                    btnClear.Visible = true;
                    toolStripStatusLabel1.Text = "Click Delete to Remove Member or Cancel to Exit";

                    txtName.Text = q;
                    string q1 = context.Users.Where(x => x.User_ID.ToString() == qq2).Select(x => x.Email).First();
                    txtEmail.Text = q1;
                    int? q2 = context.Users.Where(x => x.User_ID.ToString() == qq2).Select(x => x.Phone_no).First();
                    mtextPN.Text = q2.ToString();
                    string q3 = context.Users.Where(x => x.User_ID.ToString() == qq2).Select(x => x.Category).First();
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
            txtName.Visible = false;
            txtEmail.Visible = false;
            mtextPN.Visible = false;
            btnDel.Visible = false;
            btnClear.Visible = false;
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var newVMForm = new ViewMembers();
            newVMForm.Closed += (s, args) => this.Close();
            newVMForm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string qq2 = mtextUID.Text.TrimStart(new Char[] { '0' });
            DialogResult result = MessageBox.Show("Confirm Delete?", "Warning!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SA45TEAM01ALibraryEntities context = new SA45TEAM01ALibraryEntities();
                User a = context.Users.Where(x => x.User_ID.ToString() == qq2).FirstOrDefault();

                using (TransactionScope ts = new TransactionScope())
                {
                    a.Status = "Inactive";
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
                txtName.Visible = false;
                txtEmail.Visible = false;
                mtextPN.Visible = false;
                btnDel.Visible = false;
                btnClear.Visible = false;
                toolStripStatusLabel1.Text = "Input User_ID and click Search";

                Messages A = new Messages();
                A.SaveMessage();
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newMForm = new Main();
            newMForm.Closed += (s, args) => this.Close();
            newMForm.Show();
        }
    }

    }
