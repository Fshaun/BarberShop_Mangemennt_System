using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reception.Domain.Interfaces.Services;

namespace Reception.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly IQueueService _queueService;

        public QueueController(IQueueService queueService)
        {
            _queueService = queueService;
        }

        [HttpGet]
        public async Task<IActionResult> GetQueue()
        {
            var queue = await _queueService.GetCurrentQueueAsync();
            return Ok(queue);
        }

        [HttpPost("{queueEntryId}/assign-barber/{barberId}")]
        public async Task<IActionResult> AssignBarber(Guid queueEntryId, Guid barberId)
        {
            await _queueService.AssignBarberAsync(queueEntryId, barberId);
            return Ok();
        }

        [HttpGet("next")]
        public async Task<IActionResult> GetNextCustomer()
        {
            var next = await _queueService.GetNextCustomerAsync();
            return Ok(next);
        }

    }
}
