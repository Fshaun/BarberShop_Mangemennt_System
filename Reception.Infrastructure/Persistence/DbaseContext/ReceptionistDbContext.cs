using Microsoft.EntityFrameworkCore;
using Reception.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reception.Infrastructure.Persistence.DbaseContext
{
    public class ReceptionistDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<QueueEntry> QueueEntries { get; set; }

        public ReceptionistDbContext(DbContextOptions<ReceptionistDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.QueueEntry)
                .WithOne(q => q.Customer)
                .HasForeignKey<QueueEntry>(q => q.CustomerId);

            modelBuilder.Entity<QueueEntry>()
                .HasIndex(q => q.QueuePosition);
        }
    }
}
