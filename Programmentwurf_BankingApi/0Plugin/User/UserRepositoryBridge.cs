using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programmentwurf_BankingApi.Domain.Entities;
using Programmentwurf_BankingApi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi.Plugin.User
{
    public class UserRepositoryBridge : UserRepository
    {
        private BankingContext Context;
        public UserRepositoryBridge(BankingContext context)
        {
            Context = context;
        }

        public async Task<List<UserEntity>> findAllUsers()
        {
            return await Context.Users.ToListAsync();
        }

        public async void create(UserEntity user)
        {
            var userEntity = findByEmail(user.Email);
            if(userEntity != null)
            {
                System.Console.WriteLine("User already exists");
                return;
            }
            Context.Users.Add(user);
            await Context.SaveChangesAsync();
        }

        public async void delete(int userid)
        {
            var userEntity = await Context.Users.FindAsync(userid);
            if (userEntity == null)
            {
                System.Console.WriteLine("User not found");
            }

            Context.Users.Remove(userEntity);
            await Context.SaveChangesAsync();
        }

        public async void update(UserEntity user)
        {
            Context.Entry(user).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserEntityExists(user.Id))
                {
                    System.Console.WriteLine("User not found");
                }
                else
                {
                    throw;
                }
            }
        }

        public UserEntity findByEmail(string email)
        {
            var result = Context.Users.FirstOrDefault(x => x.Email == email);
            return result;
        }

        public async Task<UserEntity> findById(int userid)
        {
            var userEntity = await Context.Users.FindAsync(userid);
            if (userEntity == null)
            {
                System.Console.WriteLine("User not found");
            }
            return userEntity;
        }

        public IActionResult login(string email, string password)
        {
            var userEntity = findByEmail(email);
            if(userEntity != null)
            {
                if(userEntity.Password == password)
                {
                    return new OkObjectResult(userEntity.Id);
                }
                else
                {
                    return new UnauthorizedObjectResult("Wrong password");
                }
            }
            else
            {
                return new NotFoundObjectResult("Email wrong");
            }
        }

        private bool UserEntityExists(int id)
        {
            return Context.Users.Any(e => e.Id == id);
        }
    }
}
