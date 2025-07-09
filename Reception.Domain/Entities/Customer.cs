using Reception.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reception.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime CheckInTime { get; set; } = DateTime.UtcNow;
        public CustomerStatus Status { get; set; } = CustomerStatus.Queued;
        public QueueEntry? QueueEntry { get; set; }
    }
}
