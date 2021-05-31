using System.Collections.Generic;
using System.Threading.Tasks;
using _1_Adapter.Adapter.User;
using _3_Domain.Domain.Domain_Services;
using Microsoft.AspNetCore.Mvc;
using Programmentwurf_BankingApi.Plugin.User;
using _3_Domain.Domain.Entities;
using _3_Domain.Domain.Repositories;

namespace Programmentwurf_BankingApi.Plugin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserRepository _userRepo;
        private UserMapper _userMapper;
        private IChangePassword _changePasswordImpl;

        public UserController(UserRepository impl, ChangePasswordImpl pwImpl)
        {
            _userRepo = impl;
            _changePasswordImpl = pwImpl;
            _userMapper = UserMapper.getInstance();
        }

        // GET: api/User
        [HttpGet]
        public async Task<List<_1_Adapter.Adapter.User.User>> GetUsers()
        {
            var users = await _userRepo.findAllUsers();
            var userlist = _userMapper.convertToUserList(users);
            return userlist;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<_1_Adapter.Adapter.User.User> GetUserEntity(int id)
        {
            var userEntity = await _userRepo.findById(id);

            if (userEntity == null)
            {
                System.Console.WriteLine("User not found");
            }

            var userResource = _userMapper.apply(userEntity);

            return userResource;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserEntity(UserEntity userEntity)
        {
            var response = await _userRepo.update(userEntity);

            if (response)
            {
                return new OkResult();
            }

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostUserEntity(UserEntity userEntity)
        {
            var response = await _userRepo.registrieren(userEntity);

            if (response)
            {
                return CreatedAtAction(nameof(GetUserEntity), new { id = userEntity.Id }, userEntity);
            }

            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserEntity(int id)
        {
            var response = await _userRepo.delete(id);
            if (response)
            {
                return new OkResult();
            }
            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("[action]")]
        public UserEntity Login(LoginObject loginInfo)
        {
            return _userRepo.login(loginInfo.email, loginInfo.password);
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
