using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.Services
{
    public class BaseService:IBaseService
    {
        IBaseResposity _baseResposity;
        public BaseService(IBaseResposity baseResposity)
        {
            _baseResposity = baseResposity;
        }
        /// <summary>
        /// Hàm dùng chung trả về tất cả dữ liệu của 1 bảng
        /// </summary>
        /// <returns>Danh sách dư liệu của 1 bảng</returns
        /// CreatedBy:LCQUYEN(10/03/2021)
        public IEnumerable<MISAEntity> GetAll<MISAEntity>()
        {
            return _baseResposity.GetAll<MISAEntity>();
        }
        public MISAEntity GetObjectById<MISAEntity>(Guid entityId)
        {
            return _baseResposity.GetObjectById<MISAEntity>(entityId);
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
            return _baseResposity.Insert<MISAEntity>(entity);
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
            return _baseResposity.Update<MISAEntity>(entity);
        }
        /// <summary>
        /// Hàm dùng chung xóa 1 bản ghi của 1 bảng
        /// </summary>
        /// <typeparam name="MISAEntity">Object của 1 bảng</typeparam>
        /// <param name="entityId">Khóa chính của bảng</param>    
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy:LCQUYEN(10/03/2021)
        public int Delete<MISAEntity>(Guid entityId)
        {
            return _baseResposity.Delete<MISAEntity>(entityId) ;
        }
    }
}
