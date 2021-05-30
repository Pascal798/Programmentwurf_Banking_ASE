using System.Collections.Generic;
using System.Threading.Tasks;
using _3_Domain.Domain.Entities;

namespace _3_Domain.Domain.Repositories
{
    public interface UserRepository
    {
        Task<List<UserEntity>> findAllUsers();
        Task<bool> update(UserEntity user);
        Task<bool> registrieren(UserEntity user);
        Task<bool> delete(int id);
        UserEntity findByEmail(string email);
        Task<UserEntity> findById(int id);
        UserEntity login(string email, string password);
    }
}
