using dotNetAcademy.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotNetAcademy.DAL.Extensions
{
    public static class AddDotNetAcademyDbContextExtension
    {
        public static IServiceCollection AddDotNetAcademyDbContext(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<DotNetAcademyDbContext>(options => options.UseSqlServer(connectionString));              
            return services;
        }
    }
}
