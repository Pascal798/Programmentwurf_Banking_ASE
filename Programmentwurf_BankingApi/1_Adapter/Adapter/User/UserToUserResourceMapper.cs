using System.Collections.Generic;
using _3_Domain.Domain.Entities;

namespace _1_Adapter.Adapter.User
{
    public class UserToUserResourceMapper
    {
        private static UserToUserResourceMapper instance;
        public static UserToUserResourceMapper getInstance()
        {
            if(instance == null)
            {
                instance = new UserToUserResourceMapper();
            }
            return instance;
        }
        public UserResource apply (UserEntity user)
        {
            return map(user);
        }

        private UserResource map(UserEntity user)
        {
            return new UserResource(user.Id, user.Name, user.Email);
        }
        public List<UserResource> convertToUserList(List<UserEntity> userEntities)
        {
            var userlist = new List<UserResource>();
            foreach(var userEntity in userEntities)
            {
                userlist.Add(new UserResource(userEntity.Id, userEntity.Name, userEntity.Email));
            }
            return userlist;
        }
    }
}
