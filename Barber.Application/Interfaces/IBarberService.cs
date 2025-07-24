using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Barber.Application.Models;

namespace Barber.Application.Interfaces
{
    public interface IBarberService
    {
        Task<BarberDetail> GetBaber(string id);
        Task<List<BarberDetail>> GetBaberList();

        Task AddBarber(BarberDetail barber);

        Task DeleteBarber(string barberId);
    }
}
