using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi.Adapter.User
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    
    public UserResource(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}
