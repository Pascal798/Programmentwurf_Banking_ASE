using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3_Domain.Domain.Domain_Services;
using _3_Domain.Domain.Repositories;
using static System.Console;
using _3_Domain.Domain.Entities;

namespace Programmentwurf_BankingApi.Plugin.User
{
    public class UserRepositoryImpl : UserRepository
    {
        private readonly IBankingContext _context;
        public UserRepositoryImpl(IBankingContext context)
        {
            _context = context;
        }

        public async Task<List<UserEntity>> findAllUsers()
        {
            return await _context.Users.ToListAsync();

        }

        public async Task<bool> registrieren(UserEntity user)
        {
            var userEntity = findByEmail(user.Email);
            if(userEntity != null)
            {
                Out("User already exists");
                return false;
            }

            var credentialsService = new CredentialsService();
            if(
                credentialsService.credentialsAreValid(user.Name, user.Email, user.Password))
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                Out("Wrong credentials");
                return false;
            }


        }



        public async Task<bool> delete(int userid)
        {
            var userEntity = await _context.Users.FindAsync(userid);
            if (userEntity == null)
            {
                WriteLine("User not found");
            }

            try
            {
                _context.Users.Remove(userEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                WriteLine(e);
                return false;
            }

            
        }

        public async Task<bool> update(UserEntity user)
        {
            _context.Update(user);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserEntityExists(user.Id))
                {
                    WriteLine("User not found");
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public UserEntity findByEmail(string email)
        {
            var result = _context.Users.FirstOrDefault(x => x.Email == email);
            return result;
        }

        public async Task<UserEntity> findById(int userid)
        {
            var userEntity = await _context.Users.FindAsync(userid);
            if (userEntity == null)
            {
                WriteLine("User not found");
            }
            return userEntity;
        }

        public UserEntity login(string email, string password)
        {
            var userEntity = findByEmail(email);
            if(userEntity != null)
            {
                if(userEntity.Password == password)
                {
                    return userEntity;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private bool UserEntityExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        private void Out(string v)
        {
            System.Console.WriteLine("User already exists");
        }
    }
}
