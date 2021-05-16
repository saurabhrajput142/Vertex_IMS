using Management.Entities;
using Management.Enums;
using Management.Implementation.Context;
using Management.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Management.Implementation.Services
{
    public class UserService : IUserService
    {
        private readonly MainDbContext _dbContext;
       
        public UserService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserEntity Authenticate(string userName, string password)
        {
            var user = _dbContext.UserEntities
                .FirstOrDefault(x => x.UserName == userName
                && x.Password == password
                && x.Status == (byte) UserStatus.Active);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return _dbContext.UserEntities;
        }

        public UserEntity GetById(int id, UserStatus? userStatus)
        {
            if (userStatus == null)
            {
                return _dbContext.UserEntities.FirstOrDefault(x => x.UserId == id);
            }
            else
            {
                return _dbContext.UserEntities.FirstOrDefault(x => x.UserId == id
                && x.Status == (byte)userStatus);
            }
        }

        public UserEntity GetUserProfile(int id)
        {
            return _dbContext.UserEntities.FirstOrDefault(x => x.UserId == id);
        }
    }
}
