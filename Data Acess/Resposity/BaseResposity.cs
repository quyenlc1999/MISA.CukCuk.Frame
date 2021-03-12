using Common.Interfaces;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Data_Acess.Resposity
{
    public class BaseResposity: IBaseResposity
    {
        protected string connString = @"Host=47.241.69.179; Port=3306;Database=MF749_LCQUYEN_CukCuk;User Id=dev;Password=12345678";
        protected IDbConnection _dbConnection;
        public BaseResposity()
        {
            _dbConnection = new MySqlConnection(connString);
        }
        
        public IEnumerable<MISAEntity> GetAll<MISAEntity>()
        {
            var className = typeof(MISAEntity).Name;
            string procName = $"Proc_Get{className}s";
            var objects = _dbConnection.Query<MISAEntity>(procName, commandType: CommandType.StoredProcedure);
            return objects;
        }
      
        public int Insert<MISAEntity>(MISAEntity entity)
        {
            var className = typeof(MISAEntity).Name;
            string procName = $"Proc_Insert{className}";
            var res = _dbConnection.Execute(procName, entity, commandType: CommandType.StoredProcedure);
            return res;
        }
       
        public int Update<MISAEntity>(MISAEntity entity)
        {
            var className = typeof(MISAEntity).Name;
            var procName = $"Proc_Update{className}";
            var res = _dbConnection.Execute(procName, entity, commandType: CommandType.StoredProcedure);
            return res;
        }
      
        public int Delete<MISAEntity>(Guid entity)
        {
            var className = typeof(MISAEntity).Name;
            var procName = $"Proc_Delete{className}";
            //   var sql = $"DELETE FROM {className} WHERE {className}Id = '{entity}'";
            var dynamicParams = new DynamicParameters();
            dynamicParams.Add($"@Id", entity.ToString());
            //   var classNameId = $"{className}Id";
            //   var res = _dbConnection.Execute(sql, commandType: CommandType.Text);
            var res = _dbConnection.Execute(procName,   
                                            param: dynamicParams,
                                            commandType: CommandType.StoredProcedure);
            return res;
        }
    }
}
