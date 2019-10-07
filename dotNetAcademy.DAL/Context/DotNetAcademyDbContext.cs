using System;
using System.Collections.Generic;
using System.Text;
using dotNetAcademy.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotNetAcademy.DAL.Context
{
    public class DotNetAcademyDbContext:DbContext
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
    }

   


}
