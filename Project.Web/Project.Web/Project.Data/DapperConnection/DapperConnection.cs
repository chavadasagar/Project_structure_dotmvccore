using System;
using System.Collections.Generic;
using System.Data.Common;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Project.Data.DapperConnection
{
    public class DapperConnection: IDapperConnection
    {
        private readonly string connectionstring;
        public DapperConnection(SqlConnectionConfig config)
        {
            connectionstring = config.SqlConnection;
        }

        public async Task<int> Execute(string sp, DynamicParameters parms, CommandType commandtype = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
            {
                var result = db.Execute(sp, parms, commandType: commandtype);
                return result;
            }
        }
        public async Task<T> Get<T>(string sp, DynamicParameters parms, CommandType commandtype = CommandType.StoredProcedure)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connectionstring))
                {
                    var result = db.Query<T>(sp, parms, commandType: commandtype);
                    return result.FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<List<T>> GetAll<T>(string sp, DynamicParameters parms, CommandType commandtype = CommandType.StoredProcedure)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
            {
                var result = db.Query<T>(sp, parms, commandType: commandtype);
                return result?.ToList();

            }
        }
        public DbConnection GetDbConnection()
        {
            return new SqlConnection(connectionstring);
        }
        public async Task<T> GetQuery<T>(string query, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection db = new SqlConnection(connectionstring))
            {
                var result = await db.QueryAsync<T>(query);
                return result.FirstOrDefault();
            }
        }
        public async Task<T> Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure, CancellationToken Token = default)
        {
            T result;
            IDbConnection db = new SqlConnection(connectionstring);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using (var trans = db.BeginTransaction())
                {
                    try
                    {
                        var cd = new CommandDefinition(commandText: sp, parameters: parms, commandType: commandType, transaction: trans, cancellationToken: Token);
                        result = (await db.QueryAsync<T>(cd)).FirstOrDefault();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw ex;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }

        public async Task<T> Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            IDbConnection db = new SqlConnection(connectionstring);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using (var trans = db.BeginTransaction())
                {
                    try
                    {
                        result = db.Query<T>(sp, parms, commandType: commandType, transaction: trans).FirstOrDefault();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
            return result;
        }
    }
}
