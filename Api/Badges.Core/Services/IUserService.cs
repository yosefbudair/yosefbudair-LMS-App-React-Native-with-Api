﻿using Badges.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Core.Services
{
    public interface IUserService
    {
        public List<User> GetAllUsers();

        public bool CreateUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(int id);
        public User GetUserById(int id);
    }
}
