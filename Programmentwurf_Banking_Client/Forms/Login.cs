using Programmentwurf_Banking_Client.Forms;
using Programmentwurf_Banking_Client.Requests.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
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
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                Cache.cache.Set("User", user, cacheItemPolicy);

                var home = new Home();
                home.Show();
                
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
