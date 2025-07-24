using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Infrastructure.Models
{
    public class BarberDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public bool IsAvailable { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<ServiceHistory> ServiceHistories { get; set; }
    }
}
