using MISA.CukCuk.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface ICustomerResposity:IBaseResposity
    {
        IEnumerable<Customer> GetCustomerByCode(string customerCode);
    }
}
