using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3_Domain.Domain.Domain_Services;
using Xunit.Sdk;

namespace _3_Domain.Domain.Entities
{
    public class UserEntity
    {
        public UserEntity() { }
        public UserEntity(int id, string email, string name, string password, bool isAdmin = false)
        {
            Id = id;
            CredentialsService cService = new CredentialsService();
            if (!cService.isNameValid(name))
            {
                throw new ArgumentException("Name is invalid");
            }
            Name = name;
            if (!cService.isEmailValid(email))
            {
                throw new ArgumentException("Email is invalid");
            }
            Email = email;
            if (!cService.isPasswordValid(password))
            {
                throw new ArgumentException("Password is invalid");
            }
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
