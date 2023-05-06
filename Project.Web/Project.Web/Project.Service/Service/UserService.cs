using Project.Common.Models;
using Project.Data.IRepository;
using Project.Data.UoW;
using Project.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _user;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository user, IUnitOfWork unitOfWork)
        {
            _user = user;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<User>> GetAllUser()
        {
            try
            {
                var Users = await _user.GetAllUser();
                return Users;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<User>> GetAllUser_UOW()
        {
            try
            {
                return _unitOfWork.Repository<User>().GetAll().ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }



    }
}
