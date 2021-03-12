using Common.Interfaces;
using Dapper;
using DataAccess.Resposity;
using MISA.CukCuk.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAcess.Resposity
{
    public class CutomerResopity:BaseResposity, ICustomerResposity
    {
        public IEnumerable<Customer> GetCustomerByCode(string customerCode)
        {
            var procName = "Proc_GetCustomerByCode";
            var customers = _dbConnection.Query<Customer>(procName, new { CustomerCode = customerCode }, commandType: CommandType.StoredProcedure);
            return customers;
        }
    }
}
