using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services
{
    public class CustomerGroupService :BaseService, ICustomerGroupService
    {
        public ICustomerGroupResposity _customerGroupResposity;
        public CustomerGroupService(ICustomerGroupResposity customerGroupResposity,IBaseResposity baseResposity):base(baseResposity)
        {
            this._customerGroupResposity = customerGroupResposity;
        }
    }
}
