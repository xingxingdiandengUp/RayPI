﻿//微软包
using Microsoft.Extensions.DependencyInjection;
//本地项目包
using RayPI.Infrastructure.Cors.Enums;

namespace RayPI.Infrastructure.Cors.Di
{
    public static class CorsDiExtension
    {
        public static IServiceCollection AddCorsService(this IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy(CorsPolicyEnum.Free.ToString(), policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });

                c.AddPolicy(CorsPolicyEnum.Limit.ToString(), policy =>
                {
                    policy.WithOrigins("localhost:8083")
                    .WithMethods("get", "post", "put", "delete")
                    //.WithHeaders("Authorization");
                    .AllowAnyHeader();
                }); ;
            });
            return services;
        }
    }
}
