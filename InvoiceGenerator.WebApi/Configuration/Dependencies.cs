﻿using System;
using System.Net.Http;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using InvoiceGenerator.Backend.Database;
using InvoiceGenerator.Services.VatService;
using InvoiceGenerator.Services.UserService;
using InvoiceGenerator.Services.BatchService;
using InvoiceGenerator.Services.TemplateService;
using InvoiceGenerator.Services.BehaviourService;
using InvoiceGenerator.Backend.Database.Initializer;
using InvoiceGenerator.Backend.Core.Services.LoggerService;
using InvoiceGenerator.Backend.Core.Services.DateTimeService;
using MediatR;
using FluentValidation;

namespace InvoiceGenerator.WebApi.Configuration;

[ExcludeFromCodeCoverage]
public static class Dependencies
{
    public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.CommonServices(configuration);
        SetupDatabase(services, configuration);
        SetupRetryPolicyWithPolly(services);
    }

    public static void CommonServices(this IServiceCollection services, IConfiguration configuration)
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
            var dbConnect = configuration.GetValue<string>("DbConnect");
            options.UseSqlServer(dbConnect, addOptions 
                => addOptions.EnableRetryOnFailure(maxRetryCount, maxRetryDelay, null));
        });
    }

    private static void SetupServices(IServiceCollection services) 
    {
        services.AddHttpContextAccessor();

        services.AddScoped<HttpClient>();
        services.AddScoped<IDbInitializer, DbInitializer>();
        services.AddScoped<IDateTimeService, DateTimeService>();
        services.AddScoped<IVatService, VatService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IBatchService, BatchService>();
        services.AddScoped<ITemplateService, TemplateService>();
    }

    private static void SetupValidators(IServiceCollection services)
        => services.AddValidatorsFromAssemblyContaining<Backend.Cqrs.RequestHandler<IRequest, Unit>>();

    private static void SetupMediatR(IServiceCollection services) 
    {
        services.AddMediatR(options => options.AsScoped(), 
            typeof(Backend.Cqrs.RequestHandler<IRequest, Unit>).GetTypeInfo().Assembly);

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(DomainCheckBehaviour<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PrivateKeyCheckBehaviour<,>));
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
        }).AddPolicyHandler(PollyPolicyHandler.SetupRetry());
    }
}