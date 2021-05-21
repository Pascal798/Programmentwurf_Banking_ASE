using Programmentwurf_Banking_Client.Forms;
using Programmentwurf_Banking_Client.Requests.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programmentwurf_Banking_Client
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            var user = await UserProcessor.LoginUser(EmailBox.Text, PasswordBox.Text);

            if(user != null)
            {
                this.Close();
                //Open Kontoübersicht
            }
            else
            {
                MessageBox.Show("Wrong credentials");
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var registerForm = new Register();
            registerForm.Show();
        }
    }
}
