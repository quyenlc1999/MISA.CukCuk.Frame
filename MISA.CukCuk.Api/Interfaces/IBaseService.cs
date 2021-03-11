using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Interface
{
    public interface IBaseService
    {
        IEnumerable<MISAEntity> GetAll<MISAEntity>();
        int Insert<MISAEntity>(MISAEntity entity);
        int Update<MISAEntity>(MISAEntity entity);
        int Delete<MISAEntity>(Guid entity);
    }
}
