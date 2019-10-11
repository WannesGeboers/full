using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dotNetAcademy.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotNetAcademy.DAL.Context
{
    public class DotNetAcademyDbContext:IdentityDbContext<Customer>
    {

        public DotNetAcademyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Participant> Participants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var customer = new Customer {Name = "BitConsult", StreetAndNumber = "HeultjeWeg 1", City = "Westerlo", MaxParticipants = 10};

            modelBuilder.Entity<Customer>()
                .HasData(
                    customer,
                    new Customer { Id="df39664c-5a15-4063-900d-7a67e09c281e", Name = "IT4IT", StreetAndNumber = "HeultjeWeg 1", City = "Westerlo", MaxParticipants = 10 },
                    new Customer { Id = "rf39664c-5a15-4063-900d-7a67e09c281d", Name = "2Commit", StreetAndNumber = "EdegemWeg 1", City = "Edegem", MaxParticipants = 10},
                    new Customer { Id = "df39664c-5a15-4063-900d-7a67e09c281d", Name = "IT4IT", StreetAndNumber = "Heulte 1", City = "Westerlo", MaxParticipants = 10 }
                    );

            modelBuilder.Entity<Participant>()
                .HasData(
                    new Participant
                    {
                        Id = "bb6799f7-28e1-473e-9293-7b64bca27a32", FirstName = "Ive",LastName = "Verstappen",Email="info@ive.be", StartDate = new DateTime(2019, 10, 10),EndDate = new DateTime(2100, 01, 01),CustomerId = "df39664c-5a15-4063-900d-7a67e09c281e"
                    },
                    new Participant
                    {
                        Id = "aa6799f7-28e1-473e-9293-7b64bca27a32",
                        FirstName = "Yari",
                        LastName = "Matthe",
                        Email = "info@yari.be",
                        StartDate = new DateTime(2019, 10, 10),
                        EndDate = new DateTime(2100, 12, 31),
                        CustomerId = "rf39664c-5a15-4063-900d-7a67e09c281d"
                    }
                );
        }
    }

   


}
