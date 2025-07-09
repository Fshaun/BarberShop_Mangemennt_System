using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reception.Domain.Entities
{
    public class QueueEntry
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public int QueuePosition { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? AssignedBarberId { get; set; }

        public Customer Customer { get; set; } = null!;
    }
}
