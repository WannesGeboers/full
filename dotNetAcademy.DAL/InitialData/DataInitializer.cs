using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using dotNetAcademy.DAL.Context;
using dotNetAcademy.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.DependencyInjection;

namespace dotNetAcademy.DAL.InitialData
{
    public static class DataInitializer
    {



        public static void SeedData
        (UserManager<Customer> userManager,
            RoleManager<IdentityRole> roleManager,
            DotNetAcademyDbContext dbContext)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
            SeedParticipants(dbContext);
           
        }


        public static void SeedUsers(UserManager<Customer> userManager)
        {
            if (userManager.FindByEmailAsync("admin@admin.com").Result == null)
            {
                //Administrator
                Customer user = new Customer
                {
                    UserName = "admin",
                    Name = "admin",
                    StreetAndNumber = "adminRoad 1",
                    City = "Heultje",
                    Email = "admin@admin.com",
                    MaxParticipants = 0
                };
                IdentityResult result = userManager.CreateAsync(user, "administrator").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
                
                //Customer
                Customer user2 = new Customer
                {
                    Id = "1",
                    UserName = "dotnetacademy",
                    Name = "dotnetacademy",
                    StreetAndNumber = "dotnetacademy",
                    City = "dotnetacademy",
                    Email = "dotnetacademy@dotnetacademy.com",
                    MaxParticipants = 10
                };
                IdentityResult result2 = userManager.CreateAsync(user2, "customer").Result;

                if (result2.Succeeded)
                {
                    userManager.AddToRoleAsync(user2, "Customer").Wait();
                }
            }
        }

        public static void SeedRoles
            (RoleManager<IdentityRole> roleManager)
        {
            //Administrator
            if (!roleManager.RoleExistsAsync
                ("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                role.NormalizedName = role.Name.ToUpper();
                IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
            }
            //Customer
            if (!roleManager.RoleExistsAsync
                ("Customer").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Customer";
                role.NormalizedName = role.Name.ToUpper();
                IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
            }

            //Partipant
            if (!roleManager.RoleExistsAsync
                ("Participant").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Participant";
                role.NormalizedName = role.Name.ToUpper();
                IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
            }
        }


        public static void SeedParticipants(DotNetAcademyDbContext context)
        {
            //    context.Customers.AddRange(
            //            new Customer { Name = "2Commit",StreetAndNumber = "Weg 1",City = "Edegem", Email = "info@2commit.be", MaxParticipants = 10 },
            //            new Customer { Name = "BitConsult", StreetAndNumber = "Weg 2", City = "Heultje", Email = "info@bitconsult.be", MaxParticipants = 10 },
            //            new Customer { Name = "IT4IT", StreetAndNumber = "Weg 3", City = "Heultje", Email = "info@it4it.be", MaxParticipants = 10 },
            //            new Customer { Name = "Cegeka", StreetAndNumber = "Weg 4", City = "Geel", Email = "info@cegeka.be", MaxParticipants = 10 }
            //        );

            context.Participants.AddRange(
                new Participant { FirstName = "Wannes", LastName = "Geboers", Email = "info@wannes.be", StartDate = new DateTime(2019, 07, 01), EndDate = new DateTime(2019, 10, 31),CustomerId = "1"},
                             new Participant { FirstName = "Geffrey", LastName = "Wuyts", Email = "info@geffrey.be", StartDate = new DateTime(2019, 08, 01), EndDate = new DateTime(2019, 10, 15),CustomerId="1" },
                             new Participant { FirstName = "Jesse", LastName = "Viskens", Email = "info@jesse.be", StartDate = new DateTime(2019, 09, 01), EndDate = new DateTime(2019, 11, 30),CustomerId = "1"},
                             new Participant { FirstName = "Yari", LastName = "Matthe", Email = "info@yari.be", StartDate = new DateTime(2019, 09, 15), EndDate = new DateTime(2019, 11, 25),CustomerId="1" }
            );
            var x = context.Participants.First();
        }
    }
}
