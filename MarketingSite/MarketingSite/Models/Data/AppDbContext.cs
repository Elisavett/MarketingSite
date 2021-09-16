using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MarketingSite.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
            Database.EnsureCreated();
        }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Request>()
                .HasOne(r => r.Application)
                .WithMany(a => a.Requests)
                .HasForeignKey(r => r.ApplicationId);

            int id = 0;
            modelBuilder.Entity<Application>().HasData(
                new Application { Id = ++id,  Name = "Приложение"+id},
                new Application { Id = ++id, Name = "Приложение" + id },
                new Application { Id = ++id, Name = "Приложение" + id },
                new Application { Id = ++id, Name = "Приложение" + id },
                new Application { Id = ++id, Name = "Приложение" + id },
                new Application { Id = ++id, Name = "Приложение" + id },
                new Application { Id = ++id, Name = "Приложение" + id },
                new Application { Id = ++id, Name = "Приложение" + id },
                new Application { Id = ++id, Name = "Приложение" + id },
                new Application { Id = ++id, Name = "Приложение" + id },
                new Application { Id = ++id, Name = "Приложение" + id },
                new Application { Id = ++id, Name = "Приложение" + id }
                );
            id = 0;
            modelBuilder.Entity<Request>().HasData(
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки "+ id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 9, 18), ApplicationId = 1},
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 9, 18), ApplicationId = 1 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 9, 19), ApplicationId = 2 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 9, 19), ApplicationId = 2 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 9, 20), ApplicationId = 2 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 9, 20), ApplicationId = 3 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 9, 25), ApplicationId = 3 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 9, 25), ApplicationId = 4 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 10, 1), ApplicationId = 4 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 10, 5), ApplicationId = 4 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 9, 23), ApplicationId = 5 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 9, 21), ApplicationId = 5 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 9, 17), ApplicationId = 6 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 10, 3), ApplicationId = 6 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 10, 5), ApplicationId = 6 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 9, 29), ApplicationId = 7 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 9, 12), ApplicationId = 7 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 9, 30), ApplicationId = 8 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 10, 2), ApplicationId = 8 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 10, 7), ApplicationId = 9 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 10, 8), ApplicationId = 10 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 10, 11), ApplicationId = 10 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 10, 12), ApplicationId = 9 },
                new Request { Id = ++id, Name = "Заявка" + id, Description = "Описание заявки " + id, Email = "email" + id + "@mail.com", EndOfDevelopment = new DateTime(2021, 10, 16), ApplicationId = 11 }
    
                );


        }
    }
}
