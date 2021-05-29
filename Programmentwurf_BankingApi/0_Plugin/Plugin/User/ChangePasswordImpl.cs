using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3_Domain.Domain.Domain_Services;

namespace Programmentwurf_BankingApi.Plugin.User
{
    public class ChangePasswordImpl : IChangePassword
    {
        private readonly UserRepositoryImpl UserRepositoryImpl;

        public ChangePasswordImpl(UserRepositoryImpl userRepositoryImpl)
        {
            UserRepositoryImpl = userRepositoryImpl;

        }

        public async Task<bool> changePassword(int userid, string oldpassword, string newpassword)
        {
            var user = await UserRepositoryImpl.findById(userid);
            if (user.Password == oldpassword)
            {
                var cService = new CredentialsService();
                if (cService.isPasswordValid(newpassword))
                {
                    user.Password = newpassword;
                    UserRepositoryImpl.update(user);
                    return true;
                }
                
            }

            return false;
        }
    }

}
