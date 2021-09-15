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


            modelBuilder.Entity<Application>().HasData(
                new Application { Id = 1,  Name = "Приложение1"},
                new Application { Id = 2, Name = "Приложение2" },
                new Application { Id = 3, Name = "Приложение3" },
                new Application { Id = 4, Name = "Приложение4" },
                new Application { Id = 5, Name = "Приложение5" },
                new Application { Id = 6, Name = "Приложение6" },
                new Application { Id = 7, Name = "Приложение7" },
                new Application { Id = 8, Name = "Приложение8" },
                new Application { Id = 9, Name = "Приложение9" },
                new Application { Id = 10, Name = "Приложение10" },
                new Application { Id = 11, Name = "Приложение11" }
                );

            modelBuilder.Entity<Request>().HasData(
                new Request { Id = 1, Name = "Заявка1", Description = "Описание заявки 1", Email = "email1@mail.com", EndOfDevelopment = new DateTime(2021, 9, 18), ApplicationId = 1},
                new Request { Id = 2, Name = "Заявка2", Description = "Описание заявки 2", Email = "email2@mail.com", EndOfDevelopment = new DateTime(2021, 9, 18), ApplicationId = 1 },
                new Request { Id = 3, Name = "Заявка3", Description = "Описание заявки 3", Email = "email3@mail.com", EndOfDevelopment = new DateTime(2021, 9, 19), ApplicationId = 2 },
                new Request { Id = 4, Name = "Заявка4", Description = "Описание заявки 4", Email = "email4@mail.com", EndOfDevelopment = new DateTime(2021, 9, 19), ApplicationId = 2 },
                new Request { Id = 5, Name = "Заявка5", Description = "Описание заявки 5", Email = "email5@mail.com", EndOfDevelopment = new DateTime(2021, 9, 20), ApplicationId = 2 },
                new Request { Id = 6, Name = "Заявка6", Description = "Описание заявки 6", Email = "email1@mail.com", EndOfDevelopment = new DateTime(2021, 9, 20), ApplicationId = 3 },
                new Request { Id = 7, Name = "Заявка7", Description = "Описание заявки 7", Email = "email2@mail.com", EndOfDevelopment = new DateTime(2021, 9, 25), ApplicationId = 3 },
                new Request { Id = 8, Name = "Заявка8", Description = "Описание заявки 8", Email = "email3@mail.com", EndOfDevelopment = new DateTime(2021, 9, 25), ApplicationId = 4 },
                new Request { Id = 9, Name = "Заявка9", Description = "Описание заявки 9", Email = "email4@mail.com", EndOfDevelopment = new DateTime(2021, 9, 25), ApplicationId = 4 },
                new Request { Id = 10, Name = "Заявка10", Description = "Описание заявки 10", Email = "email5@mail.com", EndOfDevelopment = new DateTime(2021, 10, 1), ApplicationId = 4 },
                new Request { Id = 11, Name = "Заявка11", Description = "Описание заявки 11", Email = "email1@mail.com", EndOfDevelopment = new DateTime(2021, 9, 27), ApplicationId = 5 },
                new Request { Id = 12, Name = "Заявка12", Description = "Описание заявки 12", Email = "email2@mail.com", EndOfDevelopment = new DateTime(2021, 10, 18), ApplicationId = 5 },
                new Request { Id = 13, Name = "Заявка13", Description = "Описание заявки 13", Email = "email3@mail.com", EndOfDevelopment = new DateTime(2021, 10, 28), ApplicationId = 6 },
                new Request { Id = 14, Name = "Заявка14", Description = "Описание заявки 14", Email = "email4@mail.com", EndOfDevelopment = new DateTime(2021, 10, 11), ApplicationId = 7 },
                new Request { Id = 15, Name = "Заявка15", Description = "Описание заявки 15", Email = "email5@mail.com", EndOfDevelopment = new DateTime(2021, 10, 9), ApplicationId = 8 },
                new Request { Id = 16, Name = "Заявка16", Description = "Описание заявки 16", Email = "email6@mail.com", EndOfDevelopment = new DateTime(2021, 10, 10), ApplicationId = 9 },
                new Request { Id = 17, Name = "Заявка17", Description = "Описание заявки 17", Email = "email7@mail.com", EndOfDevelopment = new DateTime(2021, 10, 5), ApplicationId = 10 }
                );


        }
    }
}
