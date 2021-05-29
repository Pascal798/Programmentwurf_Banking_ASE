using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmentwurf_Banking_Client.Models
{
    public class UserModel
    {
        public UserModel() { }
        public UserModel(int id, string email, string name)
        {
            Id = id;
            Email = email;
            Name = name;
        }

        public UserModel(string email, string name, string password)
        {
            Email = email;
            Name = name;
            Password = password;
        }

        public UserModel(string email, string name, string password, bool isAdmin)
        {
            Email = email;
            Name = name;
            Password = password;
            IsAdmin = isAdmin;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
