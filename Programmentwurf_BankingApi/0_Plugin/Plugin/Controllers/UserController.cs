using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1_Adapter.Adapter.User;
using _3_Domain.Domain.Domain_Services;
using _3_Domain.Domain.Others;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programmentwurf_BankingApi.Plugin;
using Programmentwurf_BankingApi.Plugin.User;
using _3_Domain.Domain.Entities;
using _3_Domain.Domain.Repositories;

namespace Programmentwurf_BankingApi.Plugin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserRepository _userRepositoryImpl;
        private UserToUserResourceMapper UserToUserResourceMapper;
        private IChangePassword _changePasswordImpl;

        public UserController(UserRepositoryImpl impl, ChangePasswordImpl pwImpl)
        {
            _userRepositoryImpl = impl;
            _changePasswordImpl = pwImpl;
            UserToUserResourceMapper = UserToUserResourceMapper.getInstance();
        }

        // GET: api/User
        [HttpGet]
        public async Task<List<UserResource>> GetUsers()
        {
            var users = await _userRepositoryImpl.findAllUsers();
            var userlist = UserToUserResourceMapper.convertToUserList(users);
            return userlist;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<UserResource> GetUserEntity(int id)
        {
            var userEntity = await _userRepositoryImpl.findById(id);

            if (userEntity == null)
            {
                System.Console.WriteLine("User not found");
            }

            var userResource = UserToUserResourceMapper.apply(userEntity);

            return userResource;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public NoContentResult PutUserEntity(UserEntity userEntity)
        {
            _userRepositoryImpl.update(userEntity);

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public CreatedAtActionResult PostUserEntity(UserEntity userEntity)
        {
            _userRepositoryImpl.create(userEntity);

            return CreatedAtAction(nameof(GetUserEntity), new { id = userEntity.Id }, userEntity);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public NoContentResult DeleteUserEntity(int id)
        {
            _userRepositoryImpl.delete(id);

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("[action]")]
        public UserEntity Login(LoginObject loginInfo)
        {
            return _userRepositoryImpl.login(loginInfo.email, loginInfo.password);
        }

        // POST: api/User/ChangePassword
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("[action]")]
        public async Task<bool> ChangePassword(int userid, string oldpassword, string newpassword)
        {
            return await _changePasswordImpl.changePassword(userid, oldpassword, newpassword);
        }
    }
}
