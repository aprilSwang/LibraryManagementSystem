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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnMember_MouseEnter(object sender, EventArgs e)
        {
            panelMem.Visible = true;
            panelBooks.Visible = false;
            panelReports.Visible = false;
        }

        private void btnBooks_MouseEnter(object sender, EventArgs e)
        {
            panelBooks.Visible = true;
            panelMem.Visible = false;
            panelReports.Visible = false;
        }

        private void btnReports_MouseEnter(object sender, EventArgs e)
        {
            panelReports.Visible = true;
            panelMem.Visible = false;
            panelBooks.Visible = false;
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newVMForm = new ViewMembers();
            newVMForm.Closed += (s, args) => this.Close();
            newVMForm.Show();
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            //ADD CODE FOR books form
            //this.Hide();
            //var newVForm = new ViewMembers();
            //newVForm.Closed += (s, args) => this.Close();
            //newVForm.Show();

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            //ADD CODE FOR books form
            //this.Hide();
            //var newVForm = new ViewMembers();
            //newVForm.Closed += (s, args) => this.Close();
            //newVForm.Show();

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newVMForm = new ViewMembers();
            newVMForm.Closed += (s, args) => this.Close();
            newVMForm.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newAMForm = new AddMember();
            newAMForm.Closed += (s, args) => this.Close();
            newAMForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newEMForm = new Edit_Member();
            newEMForm.Closed += (s, args) => this.Close();
            newEMForm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newAMForm = new AddMember();
            newAMForm.Closed += (s, args) => this.Close();
            newAMForm.Show();
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newRForm = new ReturnForm1();
            newRForm.Closed += (s, args) => this.Close();
            newRForm.Show();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newBForm = new BorrowForm();
            newBForm.Closed += (s, args) => this.Close();
            newBForm.Show();
        }
    }
}
