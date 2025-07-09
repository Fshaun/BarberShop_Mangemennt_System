using Reception.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reception.Domain.Interfaces.Services
{
    public interface IQueueService
    {
        Task<List<QueueEntry>> GetCurrentQueueAsync();
        Task AssignBarberAsync(Guid queueEntryId, Guid barberId);
        Task<QueueEntry?> GetNextCustomerAsync();
    }
}
