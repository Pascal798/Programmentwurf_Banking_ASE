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

        public async void create(UserEntity user)
        {
            var userEntity = findByEmail(user.Email);
            if(userEntity != null)
            {
                Out("User already exists");
                return;
            }

            var credentialsService = new CredentialsService();
            if(
                credentialsService.isNameValid(user.Name) && 
                credentialsService.isEmailValid(user.Email) && 
                credentialsService.isPasswordValid(user.Password))
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                Out("Wrong credentials");
            }


        }



        public async void delete(int userid)
        {
            var userEntity = await _context.Users.FindAsync(userid);
            if (userEntity == null)
            {
                WriteLine("User not found");
            }

            _context.Users.Remove(userEntity);
            await _context.SaveChangesAsync();
        }

        public async void update(UserEntity user)
        {
            _context.Update(user);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserEntityExists(user.Id))
                {
                    WriteLine("User not found");
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
