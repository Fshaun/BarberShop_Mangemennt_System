using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reception.Domain.Models
{
    public class Barber
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public bool Available { get; set; } = true;
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
