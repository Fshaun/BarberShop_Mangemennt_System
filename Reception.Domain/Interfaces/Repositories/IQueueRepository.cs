using Reception.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reception.Domain.Interfaces.Repositories
{
    public interface IQueueRepository
    {
        Task<QueueEntry?> GetByCustomerIdAsync(Guid customerId);
        Task<QueueEntry?> GetNextInQueueAsync();
        Task<List<QueueEntry>> GetAllQueueEntriesAsync();
        Task AddToQueueAsync(QueueEntry queueEntry);
        Task UpdateAsync(QueueEntry queueEntry);
        Task RemoveFromQueueAsync(Guid queueEntryId);
    }

}
