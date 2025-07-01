using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reception.Domain.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string? Description { get; set; }
        public int UserId { get; set; }
        public int BarberId { get; set; }
        public virtual Barber? Barber { get; set; }
        public bool IsCancelled { get; set; } = false;
        public bool IsCompleted { get; set; } = false;
        public ReservationType Type { get; set; } = ReservationType.Regular;

        public enum ReservationType
        {
            Regular = 1,
            Special = 2,
            VIP = 3
        }

    }
}
