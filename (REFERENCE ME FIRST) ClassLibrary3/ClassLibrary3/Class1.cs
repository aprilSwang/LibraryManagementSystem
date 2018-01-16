using System;
using System.Windows.Forms;


namespace ClassLibrary3
{
    public class Messages
    {
        public void SaveMessage()
        {
            MessageBox.Show("Information has been updated!");
        }        
    }

    public class Movement
    {
        public void Logout()
        {
            MessageBox.Show("You have successfully logged out");
        }
    }
}
