﻿using Application.Core;
using Application.Interfaces;
using Application.Posts;
using AutoMapper;
using Infrastructure.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistance;

namespace CovRecover.API.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection 
            AddAppServicesToCollection(this IServiceCollection services, IConfiguration _config)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CovRevocer.API", Version = "v1" });
            });
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(_config.GetConnectionString("CovRecoverDbConnection"));
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("AppCorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });
            services.AddMediatR(typeof(List.Handler).Assembly);
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddScoped<IUserAccessor, UserAccessor>();
            return services;
        }
    }
}
