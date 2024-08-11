using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sanduba.Core.Application.Abstraction.Customers;
using Sanduba.Core.Application.Abstraction.Orders;
using Sanduba.Core.Application.Abstraction.Products;
using Sanduba.Infrastructure.Persistence.SqlServer.Customers;
using Sanduba.Infrastructure.Persistence.SqlServer.Orders;
using Sanduba.Infrastructure.Persistence.SqlServer.Products;
using System;

namespace Sanduba.Infrastructure.Persistence.SqlServer.Configurations
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers the necessary services with the DI framework.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>The same service collection.</returns>
        public static IServiceCollection AddSqlServerInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("AdminDatabase:value");

            services.AddDbContext<InfrastructureDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
                options.EnableSensitiveDataLogging();
            });

            services.AddScoped<ICustomerPersistence, CustomerRepository>();
            services.AddScoped<IOrderPersistence, OrderRepository>();
            services.AddScoped<IProductPersistence, ProductRepository>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
