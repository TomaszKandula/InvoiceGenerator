﻿namespace InvoiceGenerator.WebApi.Configuration
{
    using System;
    using System.Net.Http;
    using System.Reflection;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Backend.Cqrs;
    using Backend.Database;
    using Backend.VatService;
    using Backend.UserService;
    using Backend.BatchService;
    using Backend.TemplateService;
    using Backend.Core.Behaviours;
    using Backend.Database.Initializer;
    using Backend.Core.Services.LoggerService;
    using Backend.Core.Services.DateTimeService;
    using MediatR;
    using FluentValidation;

    [ExcludeFromCodeCoverage]
    public static class Dependencies
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            CommonServices(services, configuration);
            SetupDatabase(services, configuration);
            SetupRetryPolicyWithPolly(services);
        }

        public static void CommonServices(IServiceCollection services, IConfiguration configuration)
        {
            SetupLogger(services);
            SetupServices(services);
            SetupValidators(services);
            SetupMediatR(services);
        }

        private static void SetupLogger(IServiceCollection services) 
            => services.AddSingleton<ILoggerService, LoggerService>();

        private static void SetupDatabase(IServiceCollection services, IConfiguration configuration) 
        {
            const int maxRetryCount = 10;
            var maxRetryDelay = TimeSpan.FromSeconds(5);
            
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnect"), addOptions 
                    => addOptions.EnableRetryOnFailure(maxRetryCount, maxRetryDelay, null));
            });
        }

        private static void SetupServices(IServiceCollection services) 
        {
            services.AddHttpContextAccessor();

            services.AddScoped<HttpClient>();
            services.AddScoped<IDateTimeService, DateTimeService>();
            services.AddScoped<IVatService, VatService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBatchService, BatchService>();
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<IDbInitializer, DbInitializer>();
        }

        private static void SetupValidators(IServiceCollection services)
            => services.AddValidatorsFromAssemblyContaining<TemplateHandler<IRequest, Unit>>();

        private static void SetupMediatR(IServiceCollection services) 
        {
            services.AddMediatR(options => options.AsScoped(), 
                typeof(TemplateHandler<IRequest, Unit>).GetTypeInfo().Assembly);

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
        }

        private static void SetupRetryPolicyWithPolly(IServiceCollection services)
        {
            services.AddHttpClient("RetryHttpClient", options =>
            {
                options.DefaultRequestHeaders.Add("Accept", "application/json");
                options.Timeout = TimeSpan.FromMinutes(5);
                options.DefaultRequestHeaders.ConnectionClose = true;
            }).AddPolicyHandler(Handlers.RetryPolicyHandler());
        }
    }
}