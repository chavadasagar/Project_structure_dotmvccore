﻿using Project.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.IRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUser();
    }
}
