using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using InvoiceGenerator.Backend.Database;
using InvoiceGenerator.Services.BatchService;
using InvoiceGenerator.Backend.Core.Services.LoggerService;
using InvoiceGenerator.Backend.Core.Services.DateTimeService;

[assembly: FunctionsStartup(typeof(InvoiceGenerator.Workers.Configuration.Startup))]
namespace InvoiceGenerator.Workers.Configuration;

[ExcludeFromCodeCoverage]
public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddScoped<IDateTimeService, DateTimeService>();
        builder.Services.AddScoped<IBatchService, BatchService>();
        builder.Services.AddSingleton<ILoggerService, LoggerService>();

        var serviceProvider = builder.Services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();

        SetupDatabase(builder.Services, configuration);
    }

    private static void SetupDatabase(IServiceCollection services, IConfiguration configuration) 
    {
        const int maxRetryCount = 10;
        var maxRetryDelay = TimeSpan.FromSeconds(5);

        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(configuration["DbConnect"], addOptions 
                => addOptions.EnableRetryOnFailure(maxRetryCount, maxRetryDelay, null));
        });
    }
}