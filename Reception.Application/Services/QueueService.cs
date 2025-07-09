using Reception.Domain.Entities;
using Reception.Domain.Interfaces.Repositories;
using Reception.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reception.Application.Services
{
    public class QueueService : IQueueService
    {
        private readonly IQueueRepository _queueRepository;
        private readonly ICustomerRepository _customerRepository;

        public QueueService(IQueueRepository queueRepository, ICustomerRepository customerRepository)
        {
            _queueRepository = queueRepository;
            _customerRepository = customerRepository;
        }

        public async Task<List<QueueEntry>> GetCurrentQueueAsync()
        {
            return await _queueRepository.GetAllQueueEntriesAsync();
        }

        public async Task AssignBarberAsync(Guid queueEntryId, Guid barberId)
        {
            var queueEntry = await _queueRepository.GetAllQueueEntriesAsync()
                .ContinueWith(t => t.Result.FirstOrDefault(q => q.Id == queueEntryId));

            if (queueEntry == null)
                throw new KeyNotFoundException("Queue entry not found.");

            queueEntry.AssignedBarberId = barberId;
            await _queueRepository.UpdateAsync(queueEntry);

            var customer = await _customerRepository.GetByIdAsync(queueEntry.CustomerId);
            if (customer != null)
            {
                customer.Status = Domain.Enums.CustomerStatus.Assigned;
                await _customerRepository.UpdateAsync(customer);
            }
        }

        public async Task<QueueEntry?> GetNextCustomerAsync()
        {
            return await _queueRepository.GetNextInQueueAsync();
        }
    }
}