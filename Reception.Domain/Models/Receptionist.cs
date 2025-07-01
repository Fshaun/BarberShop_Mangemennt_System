using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reception.Domain.Models
{
    public class Receptionist
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        public virtual ICollection<Barber> Barbers { get; set; } = new List<Barber>();

        public Receptionist(int id, string? name, string? email, string? password, bool isActive = true)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            IsActive = isActive;
            Reservations = new List<Reservation>();
            Barbers = new List<Barber>();
        }
    }
}
