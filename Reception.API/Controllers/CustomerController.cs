using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reception.Domain.Interfaces.Services;

namespace Reception.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterCustomer([FromBody] CustomerRegisterRequest request)
        {
            var id = await _customerService.RegisterCustomerAsync(request.Name, request.PhoneNumber);
            return Ok(new { CustomerId = id });
        }

        [HttpPost("{customerId}/assign-to-queue")]
        public async Task<IActionResult> AssignToQueue(Guid customerId)
        {
            await _customerService.AssignCustomerToQueueAsync(customerId);
            return Ok();
        }

        [HttpPost("{customerId}/complete")]
        public async Task<IActionResult> Complete(Guid customerId)
        {
            await _customerService.CompleteCustomerAsync(customerId);
            return Ok();
        }
    }

    public class CustomerRegisterRequest
    {
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; }
    } 
}
