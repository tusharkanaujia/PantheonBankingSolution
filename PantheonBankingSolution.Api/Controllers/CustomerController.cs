using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PantheonBankingSolution.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customers = PantheonBankingSolution.Application.Customers.List;


namespace PantheonBankingSolution.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : BaseController
    {
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomerList()
        {
            return await Mediator.Send(new Customers.Query() );
        }
    }
}
