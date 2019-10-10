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

        //public static IServiceCollection AddIdentityExtension(this IServiceCollection services)
        //{
        //    //identity
        //    ////users
        //    services.AddDefaultIdentity<Customer>()
        //        .AddRoles<IdentityRole>()
        //        .AddEntityFrameworkStores<DotNetAcademyDbContext>();


        //    // Password settings + lockout settings + user settings
        //    //source: https://stackoverflow.com/questions/27831597/how-do-i-define-the-password-rules-for-identity-in-asp-net-5-mvc-6-vnext
        //    services.Configure<IdentityOptions>(options =>
        //    {
        //        options.Password.RequireUppercase = false;
        //        options.Password.RequireLowercase = false;
        //        options.Password.RequireDigit = false;
        //        options.Password.RequireNonAlphanumeric = false;
        //        options.Password.RequiredLength = 5;
        //        options.Password.RequiredUniqueChars = 0;

        //        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        //        options.Lockout.MaxFailedAccessAttempts = 3;
        //        options.Lockout.AllowedForNewUsers = true;

        //        options.User.RequireUniqueEmail = true;
        //    });
        //    return services;
        //}
    }
}
