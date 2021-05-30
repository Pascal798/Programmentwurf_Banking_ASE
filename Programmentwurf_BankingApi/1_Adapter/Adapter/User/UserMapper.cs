using System.Collections.Generic;
using _3_Domain.Domain.Entities;

namespace _1_Adapter.Adapter.User
{
    public class UserMapper
    {
        private static UserMapper instance;
        public static UserMapper getInstance()
        {
            if(instance == null)
            {
                instance = new UserMapper();
            }
            return instance;
        }
        public User apply (UserEntity user)
        {
            return map(user);
        }

        private User map(UserEntity user)
        {
            return new User(user.Id, user.Name, user.Email);
        }
        public List<User> convertToUserList(List<UserEntity> userEntities)
        {
            var userlist = new List<User>();
            foreach(var userEntity in userEntities)
            {
                userlist.Add(new User(userEntity.Id, userEntity.Name, userEntity.Email));
            }
            return userlist;
        }
    }
}
