using Reception.Domain.Entities;
using Reception.Domain.Enums;
using Reception.Domain.Interfaces.Repositories;
using Reception.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reception.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IQueueRepository _queueRepository;

        public CustomerService(ICustomerRepository customerRepository, IQueueRepository queueRepository)
        {
            _customerRepository = customerRepository;
            _queueRepository = queueRepository;
        }

        public async Task<Guid> RegisterCustomerAsync(string name, string? phone)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = name,
                PhoneNumber = phone,
                CheckInTime = DateTime.UtcNow,
                Status = CustomerStatus.Queued
            };

            await _customerRepository.AddAsync(customer);
            return customer.Id;
        }

        public async Task AssignCustomerToQueueAsync(Guid customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
                throw new KeyNotFoundException("Customer not found.");

            var currentQueue = await _queueRepository.GetAllQueueEntriesAsync();
            int nextPosition = currentQueue.Count + 1;

            var queueEntry = new QueueEntry
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                QueuePosition = nextPosition,
                CreatedAt = DateTime.UtcNow
            };

            await _queueRepository.AddToQueueAsync(queueEntry);
            customer.Status = CustomerStatus.Queued;
            await _customerRepository.UpdateAsync(customer);
        }

        public async Task CompleteCustomerAsync(Guid customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
                throw new KeyNotFoundException("Customer not found.");

            customer.Status = CustomerStatus.Completed;
            await _customerRepository.UpdateAsync(customer);

            var queueEntry = await _queueRepository.GetByCustomerIdAsync(customerId);
            if (queueEntry != null)
            {
                await _queueRepository.RemoveFromQueueAsync(queueEntry.Id);
            }
        }
    }
}