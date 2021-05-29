using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Programmentwurf_Banking_Client.Models;
using Programmentwurf_Banking_Client.Requests.User;

namespace Programmentwurf_Banking_Client.Forms
{
    public partial class ChangePassword : Form
    {
        private UserModel user;
        public ChangePassword()
        {
            user = (UserModel) Cache.cache.Get("User");
            InitializeComponent();
        }

        private async void ChangePasswordBtn_Click(object sender, EventArgs e)
        {
            if (await UserProcessor.ChangePassword(user.Id, OldPasswordBox.Text, NewPasswordBox.Text))
            {
                MessageBox.Show("Password changed");
                Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
    }
}
