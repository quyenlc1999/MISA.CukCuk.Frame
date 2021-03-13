using Common.Interfaces;
using Common.Models;
using MISA.CukCuk.Common.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Common.Services
{
    public class BaseService:IBaseService
    {
        IBaseResposity _baseResposity;
        public ServiceResult serviceResult;
        public ErrorMsg errorMsg;
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
        public virtual ServiceResult Insert<MISAEntity>(MISAEntity entity)
        {
            //Thực hiện validate dữ liệu
            var isValidate = Validate<MISAEntity>(entity);
            if(isValidate == true)
            {
                errorMsg = new ErrorMsg();
                errorMsg.devMsg = "Add success";
                errorMsg.userMsg = "Thêm mới thành công";
                serviceResult.Data = _baseResposity.Insert<MISAEntity>(entity);
                serviceResult.msg = errorMsg;
                return serviceResult;
            }   
            else
            {
                errorMsg = new ErrorMsg();
                errorMsg.devMsg = "Add failed";
                errorMsg.userMsg = "Thêm mới thất bại";
                serviceResult.Data = _baseResposity.Insert<MISAEntity>(entity);
                serviceResult.msg = errorMsg;
                return serviceResult;
            }
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
        private bool Validate<MISAEntity>(MISAEntity entity)
        {
            var isValidate = true;
            // Đọc các property
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                // Kiểm tra attribute xem có cần validate không
                if (property.IsDefined(typeof(Required), false))
                {
                    // Check bắt buộc nhập
                    var propertyValue = property.GetValue(entity);
                    if(propertyValue == null)
                    { 
                        isValidate = false;
                    }
                }
                if(property.IsDefined(typeof(CheckDuplicate), false))
                {
                    // Check trùng dữ liệu
                    var propertyName = property.Name;
                    var propertyDuplicate = _baseResposity.GetObjectByProperty<MISAEntity>(propertyName,property.GetValue(entity)); 
                    if(propertyDuplicate != null)
                    {
                        isValidate = false;
                    }
                }
            }
            return isValidate;
        }
    }
}
