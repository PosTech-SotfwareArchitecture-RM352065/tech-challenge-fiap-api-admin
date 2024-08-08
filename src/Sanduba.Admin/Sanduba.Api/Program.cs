using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Sanduba.Core.Application;
using Sanduba.Infrastructure.Persistence.SqlServer.Configurations;
using Sanduba.Adapter.Mvc;
using Sanduba.Infrastructure.Broker.ServiceBus.Configurations;

namespace Sanduba.API
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            builder.Services.AddApplication(builder.Configuration);
            builder.Services.AddMvcAdapter(builder.Configuration);
            builder.Services.AddSqlServerInfrastructure(builder.Configuration);
            builder.Services.AddServiceBusInfrastructure(builder.Configuration);

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddHealthChecks()
                .AddDatabaseHealthChecks(builder.Configuration)
                .AddBrokerHealthChecks(builder.Configuration);

            builder.Services.AddHealthChecksUI(options =>
            {
                options.SetEvaluationTimeInSeconds(15);
                options.MaximumHistoryEntriesPerEndpoint(60);
                options.SetApiMaxActiveRequests(1);

            }).AddInMemoryStorage();

            builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressMapClientErrors = true;
                });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = $"Documentação Swagger da API Restaurante Sanduba - {environment}",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Victor Cangelosi de Lima - RM352065",
                            Email = "mktcangel@gmail.com"
                        },
                    });

                options.EnableAnnotations();
            });

            builder.Host.UseSerilog(
                (context, configuration) =>
                {
                    configuration.ReadFrom.Configuration(context.Configuration);
                    configuration.Enrich.WithCorrelationId(headerName: "x-correlation-id", addValueIfHeaderAbsence: true);
                });

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseReDoc(doc =>
            {
                doc.DocumentTitle = "Documentação da API Restaurante Sanduba";
                doc.SpecUrl = "/swagger/v1/swagger.json";

            });

            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => true
            })
            .UseHealthChecks("/healthz", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            })
            .UseHealthChecksUI(options => options.UIPath = "/healthz-ui");

            app.UseSerilogRequestLogging();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static IHealthChecksBuilder AddDatabaseHealthChecks(this IHealthChecksBuilder builder, IConfiguration configuration)
        {
            foreach (var databaseConfig in configuration.GetSection("ConnectionStrings").GetChildren())
            {
                switch (databaseConfig.GetValue<string>("Type"))
                {
                    case "MSSQL":
                        builder.AddSqlServer(connectionString: databaseConfig.GetValue<string>("Value"), name: databaseConfig.Key);
                        break;
                    case "REDIS":
                        builder.AddRedis(redisConnectionString: databaseConfig.GetValue<string>("Value"), name: databaseConfig.Key);
                        break;
                }
            }

            return builder;
        }

        private static IHealthChecksBuilder AddBrokerHealthChecks(this IHealthChecksBuilder builder, IConfiguration configuration)
        {
            string connectionString = configuration.GetValue<string>("BrokerSettings:CustomerConnectionString") ?? string.Empty;
            string topicName = configuration.GetValue<string>("BrokerSettings:CustomerTopicName") ?? string.Empty;
            builder.AddAzureServiceBusQueue(connectionString, topicName);

            return builder;
        }
    }
}