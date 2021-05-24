using Programmentwurf_BankingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi.Adapter.User
{
    public class UserToUserResourceMapper
    {
        public UserResource apply (UserEntity user)
        {
            return map(user);
        }

        private UserResource map(UserEntity user)
        {
            return new UserResource(user.Id, user.Name, user.Email);
        }
    }
}
