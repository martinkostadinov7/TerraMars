using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using ServiceLayer;
namespace WinFormsUI
{
    public partial class UserLogin : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public User User { get; set; }

        UserService UserService { get; set; }

        public UserLogin()
        {
            InitializeComponent();
            UserService = new UserService();
        }
            
        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            User = UserService.GetUser(username, password);
            if (User == null)
            {
                MessageBox.Show("Invalid credentials!");
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }  
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            UserService.AddUser(username, password);
            MessageBox.Show("Successfully registered!");
        }

    }
}
