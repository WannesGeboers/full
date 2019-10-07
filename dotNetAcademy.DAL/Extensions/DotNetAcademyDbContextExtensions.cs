using dotNetAcademy.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dotNetAcademy.DAL.Entities;

namespace dotNetAcademy.DAL.Extensions
{
    public static class DotNetAcademyDbContextExtension
    {
        public static IServiceCollection AddDotNetAcademyDbContext(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<DotNetAcademyDbContext>(options => options.UseSqlServer(connectionString));              
            return services;
        }
    }
}
