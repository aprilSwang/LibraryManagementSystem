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

namespace SA45_TEAM01A_LibrarySystem
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection("Data Source = (local);" + "Initial Catalog =SA45TEAM01ALibrary;" + " Integrated Security = True");
        int count = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
           if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {           
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select* from Librarian where User_Name = '" + txtUsername.Text + "' and Password ='" + txtPassword.Text + " '";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());

            if (count == 0)
            {
                MessageBox.Show("Username and Password doesn't match!");
            }
            else
            {
                this.Hide();
                Main mn = new Main();
                mn.Show();
            }
        }

      
    }
}