using Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<MISAEntity> : ControllerBase
    {
        protected IBaseService _baseService;
        public BaseController(IBaseService baseService)
        {
            this._baseService = baseService;
        }
        /// <summary>
        /// Lấy danh sách
        /// CreatedBy:LCQUYEN(10/03/2021)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseService.GetAll<MISAEntity>().ToList();
            if (entities.Count > 0)
            {
                return StatusCode(200, entities);
            }
            else
            {
                return StatusCode(204, entities);
            }
        }
        /// <summary>
        /// Thêm mới thông tin
        /// CreatedBy:LCQUYEN(10/03/2021)
        /// </summary
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(MISAEntity entity)
        {
            var rowEffect = _baseService.Insert<MISAEntity>(entity);
            if (rowEffect > 0)
            {
                return StatusCode(201, rowEffect);
            }
            else
            {
                return StatusCode(204, rowEffect);
            }
        }
        /// <summary>
        /// Cập nhật thông tin
        /// CreatedBy:LCQUYEN(10/03/2021)
        /// </summary
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(MISAEntity entity)
        {
            var rowEffect = _baseService.Update<MISAEntity>(entity);
            if (rowEffect > 0)
            {
                return StatusCode(200, rowEffect);
            }
            else
            {
                return StatusCode(404, rowEffect);
            }
        }
        [HttpDelete("{entity}")]
        public IActionResult Delete(Guid entity)
        {
            var rowEffect = _baseService.Delete<MISAEntity>(entity);
            if (rowEffect > 0)
            {
                return StatusCode(200, rowEffect);
            }
            else
            {
                return StatusCode(404, rowEffect);
            }
        }
    }
}
