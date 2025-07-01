using Reception.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reception.Application.Contracts
{
    public interface ReceptionContract
    {
        Task<Barber> CreateBarber(Barber barber);
        Task<bool> IsBarberAvailableAsync(int barberId, DateTime startTime, DateTime endTime);
        Task<Reservation> CreateReservation(Reservation reservation);

    }
}
