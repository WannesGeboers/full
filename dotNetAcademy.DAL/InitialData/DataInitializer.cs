using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dotNetAcademy.DAL.Context;
using dotNetAcademy.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace dotNetAcademy.DAL.InitialData
{
    public static class DataInitializer
    {
        public static void SeedDb(DotNetAcademyDbContext context)
        {
            context.Customers.AddRange(
                    new Customer { Name = "2Commit",StreetAndNumber = "Weg 1",City = "Edegem", Email = "info@2commit.be", MaxParticants = 10 },
                    new Customer { Name = "BitConsult", StreetAndNumber = "Weg 2", City = "Heultje", Email = "info@bitconsult.be", MaxParticants = 10 },
                    new Customer { Name = "IT4IT", StreetAndNumber = "Weg 3", City = "Heultje", Email = "info@it4it.be", MaxParticants = 10 },
                    new Customer { Name = "Cegeka", StreetAndNumber = "Weg 4", City = "Geel", Email = "info@cegeka.be", MaxParticants = 10 }
                );
          
                context.Participants.AddRange(
                    new Participant { FirstName = "Wannes", LastName = "Geboers", Email = "info@wannes.be", StartDate = new DateTime(2019, 07, 01), EndDate = new DateTime(2019, 10, 31) },
                                 new Participant { FirstName = "Geffrey", LastName = "Wuyts", Email = "info@geffrey.be", StartDate = new DateTime(2019, 08, 01), EndDate = new DateTime(2019, 10, 15) },
                                 new Participant { FirstName = "Jesse", LastName = "Viskens", Email = "info@jesse.be", StartDate = new DateTime(2019, 09, 01), EndDate = new DateTime(2019, 11, 30) },
                                 new Participant { FirstName = "Yari", LastName = "Matthe", Email = "info@yari.be", StartDate = new DateTime(2019, 09, 15), EndDate = new DateTime(2019, 11, 25) }
                );

                var x = context.Participants.First();


        }

    }
}
