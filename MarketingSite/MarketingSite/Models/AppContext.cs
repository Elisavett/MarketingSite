using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MarketingSite.Models
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<DbContext> options) : base(options) { }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Request>()
                .HasOne(r => r.Application)
                .WithMany(a => a.Requests)
                .HasForeignKey(r => r.AppliccationId);

        }
    }
}
