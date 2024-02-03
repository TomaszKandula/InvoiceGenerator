using System;
using System.Diagnostics.CodeAnalysis;
using InvoiceGenerator.Backend.Database.Initializer;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Logger = InvoiceGenerator.WebApi.Configuration.Logger;
using Serilog;

namespace InvoiceGenerator.WebApi;

[ExcludeFromCodeCoverage]
public static class Program
{
    private static readonly string EnvironmentValue
        = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

    private static readonly bool IsDevelopment 
        = EnvironmentValue == Environments.Development;

    public static int Main()
    {
        try
        {
            var configuration = GetConfiguration();
            const string fileName = @"logs/InvoiceGenerator.WebApi/{yyyy}{MM}{dd}.txt";
            Log.Logger = Logger.Configuration.GetLogger(configuration, fileName);
            Log.Information("Starting WebHost...");
            Log.Information("Environment: {Environment}", EnvironmentValue);
            CreateWebHostBuilder(configuration)
                .Build()
                .MigrateDatabase()
                .Run();

            return 0;
        }
        catch (Exception exception)
        {
            Log.Fatal(exception, "WebHost has been terminated unexpectedly");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static IConfigurationRoot GetConfiguration()
    {
        var appSettingsEnv = $"appsettings.{EnvironmentValue}.json";
        return new ConfigurationBuilder()
            .AddJsonFile(appSettingsEnv, true, true)
            .AddUserSecrets<Startup>(true)
            .AddEnvironmentVariables()
            .Build();
    }

    private static IWebHostBuilder CreateWebHostBuilder(IConfigurationRoot configurationRoot)
    {
        return WebHost.CreateDefaultBuilder()
            .ConfigureAppConfiguration(builder => builder.AddConfiguration(configurationRoot))
            .ConfigureKestrel(options => options.AddServerHeader = false)
            .UseStartup<Startup>()
            .UseSerilog();
    }

    private static IWebHost MigrateDatabase(this IWebHost webHost)
    {
        var serviceScopeFactory = (IServiceScopeFactory) webHost.Services.GetService(typeof(IServiceScopeFactory));
        if (serviceScopeFactory == null) 
            return webHost;
            
        using var scope = serviceScopeFactory.CreateScope();
        var services = scope.ServiceProvider;
        var dbInitializer = services.GetRequiredService<IDbInitializer>();

        if (!IsDevelopment) 
            return webHost;

        dbInitializer.StartMigration();
        dbInitializer.SeedData();

        return webHost;
    }
}