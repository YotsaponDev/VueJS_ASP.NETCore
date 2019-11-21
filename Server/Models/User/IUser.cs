﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Server.Models.User
{
    public interface IUser
    {
        List<UserEntity> GetAll();
        UserEntity GetById(Guid id);
        UserReturnViewModel GetByIdViaJWT(string authHeader);
        UserEntity Create(UserEntity model);
        UserEntity Update(Guid id, UserEntity modelUpdate);
        UserEntity Delete(Guid id);
        object Login(UserLoginViewModel model);
    }
}
