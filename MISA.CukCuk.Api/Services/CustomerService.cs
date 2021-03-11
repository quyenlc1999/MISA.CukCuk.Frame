using Dapper;
using MISA.CukCuk.Api.Interface;
using MISA.CukCuk.Api.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Services
{
    public class CustomerService: BaseService,ICustomerService
    {
        public IEnumerable<Customer> GetCustomerByCode(string customerCode)
        {
            var procName = "Proc_GetCustomerByCode";
            var customers = _dbConnection.Query<Customer>(procName, new { CustomerCode = customerCode }, commandType:CommandType.StoredProcedure);
            return customers;
        }
    }
}
