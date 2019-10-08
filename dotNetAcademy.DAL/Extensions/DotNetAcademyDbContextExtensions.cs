using dotNetAcademy.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dotNetAcademy.DAL.Entities;
using dotNetAcademy.DAL.Repositories;
using dotNetAcademy.DAL.Repositories.Interfaces;

namespace dotNetAcademy.DAL.Extensions
{
    public static class DotNetAcademyDbContextExtension
    {
        public static IServiceCollection AddDotNetAcademyDbContext(this IServiceCollection services,string connectionString)
        {
            //DAL context laden
            services.AddDbContext<DotNetAcademyDbContext>(options => options.UseSqlServer(connectionString));              
            return services;
        }


        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            //DAL repo inladen
            services.AddTransient<IGenericRepository<Customer>, GenericRepository<Customer>>();
            services.AddTransient<IGenericRepository<Participant>, GenericRepository<Participant>>();
            return services;
        }
    }
}
