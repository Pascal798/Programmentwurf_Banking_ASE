using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi.Adapter.User
{
    public class UserResource
    {
        public string Name { get; set; }
        public string Email { get; set; }
    
    public UserResource(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
