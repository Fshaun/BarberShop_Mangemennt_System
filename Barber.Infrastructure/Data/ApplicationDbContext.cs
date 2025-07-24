using Barber.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barber.Infrastructure.Data
{
    public class BarberDbContext : DbContext
    {
        private readonly static string CONN_STRING = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=Fshaun@1998;Timeout=10;SslMode=Prefer";

        public BarberDbContext() 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(CONN_STRING);
        }

        public DbSet<BarberDetail> Barbers { get; set; }
        public DbSet<ServiceHistory> ServiceHistories { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
