using Common.Interfaces;
using MISA.CukCuk.Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Common.Services
{
    public class CustomerService:BaseService , ICustomerService
    {
        ICustomerResposity _customerResposity;
        public CustomerService(ICustomerResposity customerResposity, IBaseResposity baseResposity) :base(baseResposity)
        {
            _customerResposity = customerResposity;
        }  
    public IEnumerable<Customer> GetCustomerByCode(string customerCode)
    {
            return _customerResposity.GetCustomerByCode(customerCode);
    }
}
}
