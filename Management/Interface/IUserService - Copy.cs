using Management.Entities;
using Management.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management.Interface
{
    public interface IUserService
    {
        UserEntity Authenticate(string userName, string password);
        IEnumerable<UserEntity> GetAll();
        UserEntity GetById(int id, UserStatus? userStatus);
    }
}
