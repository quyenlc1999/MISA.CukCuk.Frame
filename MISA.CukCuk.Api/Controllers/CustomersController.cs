using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Api.Interface;
using MISA.CukCuk.Api.Model;
using MISA.CukCuk.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MISA.CukCuk.Api.Controllers
{
    public class CustomersController : BaseController<Customer>
    {
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService, IBaseService baseService) : base(baseService)
        {
            _customerService = customerService;
        }


        [HttpGet("code")]
        public IActionResult GetCustomerByCode(string customerCode)
        {
            //var customerService = new CustomerService();
            var customers = _customerService.GetCustomerByCode(customerCode);
            if (customers.Count() > 0)
                return Ok(customers);
            else
                return StatusCode(204);
        }


    }
}
