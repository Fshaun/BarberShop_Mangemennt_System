using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barber.Application.Interfaces;
using Barber.Application.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Barber.Application.Services
{
    public class BarberService : IBarberService
    {
        private readonly IMemoryCache _memoryCache;
        public BarberService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;  
        }
        public async Task AddBarber(BarberDetail barber)
        {
            await Task.Delay(1000);
            _memoryCache.Set(barber.Id, barber);
        }

        public async Task DeleteBarber(string barberId)
        {
            await Task.Delay(1000);
            _memoryCache.Remove(barberId);
        }

        public async Task<List<BarberDetail>> GetBaberList()
        {
            List<BarberDetail> barberlist = new List<BarberDetail>()
            {
                await this.GetBaber("1"),
                await this.GetBaber("2"),
                await this.GetBaber("3")
        };

            return barberlist;
        }

        async Task<BarberDetail> GetBaber(string id)
        {
            BarberDetail barber = null;
            await Task.Delay(1000);
            if (_memoryCache.TryGetValue(id, out barber))
            {
                return barber;
            }

            return null;
        }

        Task<BarberDetail> IBarberService.GetBaber(string id)
        {
            throw new NotImplementedException();
        }
    }
}
