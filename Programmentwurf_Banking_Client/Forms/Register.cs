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

namespace Programmentwurf_Banking_Client.Forms
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            var response = await UserProcessor.RegisterUser(EmailBox.Text, NameBox.Text, PasswordBox.Text);

            if(response != null)
            {
                var msgBox = MessageBox.Show("User created: " + response.Name);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error while creating user");
            }
        }
    }
}
