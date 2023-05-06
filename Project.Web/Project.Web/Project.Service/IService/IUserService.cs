using Project.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.IService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUser();
        Task<List<User>> GetAllUser_UOW();
    }
}
