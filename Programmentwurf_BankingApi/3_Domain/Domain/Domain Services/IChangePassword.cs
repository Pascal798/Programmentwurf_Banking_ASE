using System.Threading.Tasks;

namespace _3_Domain.Domain.Domain_Services
{
    public interface IChangePassword
    {
        Task<bool> changePassword(int userid, string oldPassword, string newPassword);
    }
}
