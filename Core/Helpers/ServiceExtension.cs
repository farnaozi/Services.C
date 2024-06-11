using FluentValidation;
using Services.C.Core.Events;
using Services.C.Core.Handlers;
using Services.C.Core.Interfaces;
using Services.C.Core.Models;
using Services.C.Core.Repositories;
using Services.C.Infrastructure;
using Services.C.Infrastructure.DB;
using Services.C.Infrastructure.Logger;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using Microsoft.Extensions.Options;

namespace Services.C.Core.Helpers
{
    public static class ServiceExtension
    {
        [Conditional("DEBUG")]
        static void AddDebugModeRepositories(IServiceCollection services)
        {
            services.AddTransient<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                var appSettings = sp.GetRequiredService<IOptions<AppSettings>>();
                return new RabbitMQBus(scopeFactory, appSettings);
            });
            services.AddTransient<ServiceCDEventHandler>();
            services.AddTransient<IEventHandler<ServiceCDEvent>, ServiceCDEventHandler>();
            services.AddTransient<IDBRepo, DBRepo>();
            services.AddTransient<IServiceRepo, ServiceRepo>();
            services.AddTransient<ILoggerRepo, LoggerRepo>();
            services.AddTransient<IJwtFactory, JwtFactory>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<ServiceExceptions>();
        }

        [Conditional("RELEASE")]
        static void AddReleaseModeRepositories(IServiceCollection services)
        {
            services.AddTransient<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                var appSettings = sp.GetRequiredService<IOptions<AppSettings>>();
                return new RabbitMQBus(scopeFactory, appSettings);
            });
            services.AddTransient<ServiceCDEventHandler>();
            services.AddTransient<IEventHandler<ServiceCDEvent>, ServiceCDEventHandler>();
            services.AddTransient<IDBRepo, DBRepo>();
            services.AddTransient<IServiceRepo, ServiceRepo>();
            services.AddTransient<ILoggerRepo, LoggerRepo>();
            services.AddTransient<IJwtFactory, JwtFactory>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<ServiceExceptions>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            AddDebugModeRepositories(services);
            AddReleaseModeRepositories(services);
        }
    }
}
