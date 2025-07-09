using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reception.Application.DTOs
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime CheckInTime { get; set; }
        public string Status { get; set; } = null!;
    }
}
