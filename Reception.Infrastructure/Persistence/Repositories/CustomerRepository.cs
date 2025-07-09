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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ReceptionistDbContext _context;

        public CustomerRepository(ReceptionistDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        } 
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Customers.FindAsync(id);
            if (entity != null) _context.Customers.Remove(entity);
        }

        public async Task<List<Customer>> GetAllAsync() => await _context.Customers.ToListAsync();

        public async Task<Customer?> GetByIdAsync(Guid id) => await _context.Customers.FindAsync(id);


        public async Task UpdateAsync(Customer customer) =>  _context.Customers.Update(customer);
    }

}
