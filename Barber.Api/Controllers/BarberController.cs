using Barber.Application.Interfaces;
using Barber.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Barber.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BarberController : ControllerBase
    {
        private readonly IBarberService _barberService;
        public BarberController(IBarberService barberService) 
        { 
            _barberService = barberService;
        }

        [HttpGet]
        public async Task<List<BarberDetail>> GetAllBarber()
        {
            return await _barberService.GetBaberList();
        }

        [HttpGet("id")]
        public async Task<BarberDetail> GetBarberById(string id) 
        {
            return await _barberService.GetBaber(id);
        }

        [HttpPost(Name = "PostBarber")]
        public async Task PostBarber(BarberDetail barber) 
        {
            await _barberService.AddBarber(barber);
        }

        [HttpPut(Name = "PutBarber")]
        public void PutBarber(BarberDetail barber) 
        {

        }

        [HttpPatch(Name = "PatchBarber")]
        public void PatchBarber(BarberDetail barber)
        {

        }

        [HttpDelete(Name = "DeleteBarber")]
        public async Task DeleteBarber(string id) 
        {
            await _barberService.DeleteBarber(id); 
        }
    }
}
