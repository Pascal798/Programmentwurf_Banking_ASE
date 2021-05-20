using Microsoft.AspNetCore.Mvc;
using Programmentwurf_BankingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi.Domain.Repositories
{
    public interface UserRepository
    {
        Task<List<UserEntity>> findAllUsers();
        void update(UserEntity user);
        void create(UserEntity user);
        void delete(int id);
        UserEntity findByEmail(string email);
        Task<UserEntity> findById(int id);
    }
}
