using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using dotNetAcademy.BLL.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace dotNetAcademy.BLL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            //automapper
            var config = new MapperConfiguration(c => { c.AddProfile(new MappingProfiles()); });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }


    }
}
