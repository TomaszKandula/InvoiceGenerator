using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using InvoiceGenerator.Backend.Core.Exceptions;
using InvoiceGenerator.WebApi.Configuration;
using InvoiceGenerator.WebApi.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Serilog;
using Newtonsoft.Json.Converters;

namespace InvoiceGenerator.WebApi;

[ExcludeFromCodeCoverage]
public class Startup
{
    private readonly IConfiguration _configuration;

    private readonly IHostEnvironment _environment;

    public Startup(IConfiguration configuration, IHostEnvironment environment)
    {
        _configuration = configuration;
        _environment = environment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));
        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ErrorResponses = new ApiVersionException();
        });
        services.AddResponseCompression(options => options.Providers.Add<GzipCompressionProvider>());
        services.RegisterDependencies(_configuration);
        services.SetupSwaggerOptions(_environment);
        services.SetupDockerInternalNetwork();
        services
            .AddHealthChecks()
            .AddSqlServer(_configuration.GetValue<string>("DbConnect"), name: "SQLServer")
            .AddAzureBlobStorage(_configuration.GetValue<string>("AZ_Storage_ConnectionString"), name: "AzureStorage");
    }

    public void Configure(IApplicationBuilder builder)
    {
        builder.UseSerilogRequestLogging();
        builder.UseHttpsRedirection();
        builder.UseForwardedHeaders();
        builder.ApplyCorsPolicy();
        builder.UseMiddleware<Exceptions>();
        builder.UseMiddleware<CacheControl>();
        builder.UseResponseCompression();
        builder.UseRouting();
        builder.SetupSwaggerUi(_environment);
        builder.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", context 
                => context.Response.WriteAsync("Invoice Generator API"));
        });
        builder.UseHealthChecks("/hc", new HealthCheckOptions
        {
            ResponseWriter = async (context, report) =>
            {
                var result = new
                {
                    status = report.Status.ToString(),
                    errors = report.Entries.Select(pair 
                        => new
                        {
                            key = pair.Key, 
                            value = Enum.GetName(typeof(HealthStatus), pair.Value.Status)
                        })
                };
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
            }
        });
    }
}