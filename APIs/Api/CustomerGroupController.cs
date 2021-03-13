using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Api.Api;
using MISA.CukCuk.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIs.Api
{
    public class CustomerGroupController :BaseController<CustomerGroup>
    {
        public ICustomerGroupService _customerGroupService;
        public CustomerGroupController(ICustomerGroupService customerGroupService , IBaseService baseService) : base(baseService)
        {
            _customerGroupService = customerGroupService;
        }
    }
}
