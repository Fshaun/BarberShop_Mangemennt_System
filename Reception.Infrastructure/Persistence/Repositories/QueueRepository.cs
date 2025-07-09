using Microsoft.EntityFrameworkCore;
using Reception.Domain.Entities;
using Reception.Domain.Interfaces.Repositories;
using Reception.Infrastructure.Persistence.DbaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reception.Infrastructure.Persistence.Repositories
{
    public class QueueRepository : IQueueRepository
    {
        private readonly ReceptionistDbContext _context;

        public QueueRepository(ReceptionistDbContext context)
        {
            _context = context;
        }

        public async Task AddToQueueAsync(QueueEntry queueEntry)
        {
            await _context.QueueEntries.AddAsync(queueEntry);
            await _context.SaveChangesAsync();
        }
        public async Task<QueueEntry?> GetByCustomerIdAsync(Guid customerId) => await _context.QueueEntries.FirstOrDefaultAsync(q => q.CustomerId == customerId);
        public async Task<QueueEntry?> GetNextInQueueAsync() => await _context.QueueEntries.OrderBy(q => q.QueuePosition).FirstOrDefaultAsync();
        public async Task<List<QueueEntry>> GetAllQueueEntriesAsync() => await _context.QueueEntries.OrderBy(q => q.QueuePosition).ToListAsync();
        public async Task RemoveFromQueueAsync(Guid queueEntryId)
        {
            var entry = await _context.QueueEntries.FindAsync(queueEntryId);
            if (entry != null) _context.QueueEntries.Remove(entry);
        }

        public async Task UpdateAsync(QueueEntry queueEntry) => _context.QueueEntries.Update(queueEntry);
    }

}
