using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.DapperConnection
{
    public interface IDapperConnection
    {
        DbConnection GetDbConnection();
        Task<int> Execute(string sp, DynamicParameters parms, CommandType commandtype = CommandType.StoredProcedure);
        Task<T> Get<T>(string sp, DynamicParameters parms, CommandType commandtype = CommandType.StoredProcedure);
        Task<List<T>> GetAll<T>(string sp, DynamicParameters parms, CommandType commandtype = CommandType.StoredProcedure);
        Task<T> Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, CancellationToken Token = default);
        Task<T> Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<T> GetQuery<T>(string query, CommandType commandType = CommandType.Text);
    }
}
