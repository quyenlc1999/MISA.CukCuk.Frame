using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IBaseResposity
    {
        /// <summary>
        /// Hàm dùng chung trả về tất cả dữ liệu của 1 bảng
        /// </summary>
        /// <returns>Danh sách dữ liệu của 1 bảng</returns
        /// CreatedBy:LCQUYEN(10/03/2021)
        IEnumerable<MISAEntity> GetAll<MISAEntity>();

        /// <summary>
        /// Hàm dùng chung trả về dữ liệu của 1 bảng theo Id
        /// </summary>
        /// <returns>Danh sách dư liệu của 1 bảng</returns
        /// CreatedBy:LCQUYEN(10/03/2021)
        MISAEntity GetObjectById<MISAEntity>(Guid entityId);

        /// <summary>
        /// Hàm dùng chung thêm mới dữ liệu vào 1 bảng
        /// </summary>
        /// <typeparam name="MISAEntity">Object của 1 bảng</typeparam>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy:LCQUYEN(10/03/2021)
        object Insert<MISAEntity>(MISAEntity entity);

        /// <summary>
        /// Hàm dùng chung cập nhật dữ liệu 1 bảng
        /// </summary>
        /// <typeparam name="MISAEntity">Object của 1 bảng</typeparam>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy:LCQUYEN(10/03/2021)
        int Update<MISAEntity>(MISAEntity entity);

        /// <summary>
        /// Hàm dùng chung xóa 1 bản ghi của 1 bảng
        /// </summary>
        /// <typeparam name="MISAEntity">Object của 1 bảng</typeparam>
        /// <param name="entity">Khóa chính của bảng</param>    
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy:LCQUYEN(10/03/2021)
        int Delete<MISAEntity>(Guid entityId);

        MISAEntity GetObjectByProperty<MISAEntity>(string propertyName, object propertyValue);


    }
}
