using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reception.Application.DTOs
{
    public class QueueEntryDto
    {
        public Guid Id { get; set; }
        public int QueuePosition { get; set; }
        public Guid CustomerId { get; set; }
        public Guid? AssignedBarberId { get; set; }
    }
}
