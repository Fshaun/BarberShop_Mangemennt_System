using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reception.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<Guid> RegisterCustomerAsync(string name, string? phone);
        Task AssignCustomerToQueueAsync(Guid customerId);
        Task CompleteCustomerAsync(Guid customerId);
    }
}
