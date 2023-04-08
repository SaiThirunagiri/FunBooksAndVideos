using FunBooksAndVideos.Entities;
using FunBooksAndVideos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService,
            ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }
        [HttpPost("RegisterCustomer")]
        public async Task<IActionResult> RegisterCustomer([FromBody] Customer customer)
        {
            try
            {
                _customerService.RegisterCustomer(customer);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Register Customer");
                return StatusCode(500);
            }
        }

        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomer(long customerId)
        {
            try
            {
                var customer = _customerService.GetCustomer(customerId);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Get Customer");
                return StatusCode(500);
            }
        }
        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            try
            {
                var customer = _customerService.GetAllCustomer();
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error GetAll Customer");
                return StatusCode(500);
            }
        }
    }
}
