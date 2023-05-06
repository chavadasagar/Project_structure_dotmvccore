using Dapper;
using Project.Common.Models;
using Project.Data.DapperConnection;
using Project.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Repository
{
    public class UserRepository:IUserRepository
    {
        public IDapperConnection _dapper;

        public UserRepository(IDapperConnection dapper)
        {
            _dapper = dapper;
        }

        public async Task<List<User>> GetAllUser()
        {
            try
            {
                var param = new DynamicParameters();
                var result = await _dapper.GetAll<User>("SP_GetAllUser", param, CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
