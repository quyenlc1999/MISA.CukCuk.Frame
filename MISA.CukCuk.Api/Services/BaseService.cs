using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using MISA.CukCuk.Api.Interface;

namespace MISA.CukCuk.Api.Services
{
    public class BaseService:IBaseService
    {
        protected string connString = @"Host=47.241.69.179; Port=3306;Database=MF749_LCQUYEN_CukCuk;User Id=dev;Password=12345678";
        protected IDbConnection _dbConnection;
        public BaseService()
        {
            _dbConnection = new MySqlConnection(connString);
        }
        /// <summary>
        /// Hàm dùng chung trả về tất cả dữ liệu của 1 bảng
        /// </summary>
        /// <returns>Danh sách dư liệu của 1 bảng</returns
        /// CreatedBy:LCQUYEN(10/03/2021)
        public IEnumerable<MISAEntity> GetAll<MISAEntity>(){
            var className = typeof(MISAEntity).Name;
            string procName = $"Proc_Get{className}s";
            var objects = _dbConnection.Query<MISAEntity>(procName, commandType: CommandType.StoredProcedure);
            return objects;
        }
        /// <summary>
        /// Hàm dùng chung thêm mới dữ liệu vào 1 bảng
        /// </summary>
        /// <typeparam name="MISAEntity">Object của 1 bảng</typeparam>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy:LCQUYEN(10/03/2021)
        public int Insert<MISAEntity>(MISAEntity entity)
        {
            var className = typeof(MISAEntity).Name;
            string procName = $"Proc_Insert{className}";
            var res = _dbConnection.Execute(procName,entity,commandType:CommandType.StoredProcedure);
            return res;
        }
        /// <summary>
        /// Hàm dùng chung cập nhật dữ liệu 1 bảng
        /// </summary>
        /// <typeparam name="MISAEntity">Object của 1 bảng</typeparam>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy:LCQUYEN(10/03/2021)
        public int Update<MISAEntity>(MISAEntity entity)
        {
            var className = typeof(MISAEntity).Name;
            var procName = $"Proc_Update{className}";
            var res = _dbConnection.Execute(procName,entity,commandType:CommandType.StoredProcedure);
            return res;
        }
        /// <summary>
        /// Hàm dùng chung xóa 1 bản ghi của 1 bảng
        /// </summary>
        /// <typeparam name="MISAEntity">Object của 1 bảng</typeparam>
        /// <param name="entity">Khóa chính của bảng</param>    
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy:LCQUYEN(10/03/2021)
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
