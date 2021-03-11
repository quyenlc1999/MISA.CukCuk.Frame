using MISA.CukCuk.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Interface
{
    public interface ICustomerService:IBaseService
    {
        IEnumerable<Customer> GetCustomerByCode(string customerCode);
    }
}
