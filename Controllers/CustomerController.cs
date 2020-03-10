using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace customer_service.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController: ControllerBase
    {
      
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult GetAllCustomers()
        {
            var result = _customerService.GetAllCustomers();
            if (result.Success)
                return new JsonResult(result);

            _logger.LogError("Customers not found");
            return StatusCode(500);
        }

        [Route("/{email}")]
        [HttpGet]

        public ActionResult GetCustomer(string email)
        { 
            var result = _customerService.GetCustomer(email);
            if (result.Success)
                return new JsonResult(result);

            _logger.LogError($"Failed to find customer with email {email}");
        }
    }
}
