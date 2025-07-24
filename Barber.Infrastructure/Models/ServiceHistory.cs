using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Infrastructure.Models
{
    public class ServiceHistory
    {
        public int Id { get; set; }

        public int BarberId { get; set; }
        public BarberDetail Barber { get; set; }

        public string ServiceName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? CustomerRating { get; set; }
    }
}
