using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programmentwurf_BankingApi._3Domain.Others;
using Programmentwurf_BankingApi.Adapter.User;
using Programmentwurf_BankingApi.Domain.Entities;
using Programmentwurf_BankingApi.Plugin;
using Programmentwurf_BankingApi.Plugin.User;

namespace Programmentwurf_BankingApi.Plugin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserRepositoryBridge UserRepositoryBridge;
        private UserToUserResourceMapper UserToUserResourceMapper;

        public UserController(UserRepositoryBridge bridge)
        {
            UserRepositoryBridge = bridge;
            UserToUserResourceMapper = UserToUserResourceMapper.getInstance();
        }

        // GET: api/User
        [HttpGet]
        public async Task<List<UserResource>> GetUsers()
        {
            var users = await UserRepositoryBridge.findAllUsers();
            List<UserResource> userList = new List<UserResource>();
            
            foreach(var user in users)
            {
                userList.Add(UserToUserResourceMapper.apply(user));
            }

            return userList;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<UserResource> GetUserEntity(int id)
        {
            var userEntity = await UserRepositoryBridge.findById(id);

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
            UserRepositoryBridge.update(userEntity);

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public CreatedAtActionResult PostUserEntity(UserEntity userEntity)
        {
            UserRepositoryBridge.create(userEntity);

            return CreatedAtAction(nameof(GetUserEntity), new { id = userEntity.Id }, userEntity);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public NoContentResult DeleteUserEntity(int id)
        {
            UserRepositoryBridge.delete(id);

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("[action]")]
        public UserEntity Login(LoginObject loginInfo)
        {
            return UserRepositoryBridge.login(loginInfo.email, loginInfo.password);
        }
    }
}
