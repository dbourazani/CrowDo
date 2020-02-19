﻿using CrowDo.Models;
using CrowDo.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowDo.Services
{
    public interface IUserServive
    {
        public User CreateUser(CreateUserOptions userOptions);
        public IQueryable<User> Search(SearchUserOptions userOptions);
        public User GetUserById(int id);
        public bool UpdateUser(int id,
            UpdateUserOptions options);
    }
}