using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmentwurf_Banking_Client.Models.User
{
    public class LoginModel
    {
        public LoginModel(string email, string password)
        {
            Email = email;
            this.password = password;
        }

        public string Email { get; set; }
        public string password { get; set; }
    }
}
