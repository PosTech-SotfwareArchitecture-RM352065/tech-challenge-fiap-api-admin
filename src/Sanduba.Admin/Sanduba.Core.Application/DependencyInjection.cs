using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sanduba.Core.Application.Abstraction.Orders;
using Sanduba.Core.Application.Abstraction.Customers;
using Sanduba.Core.Application.Abstraction.Products;
using Sanduba.Core.Application.Products;
using Sanduba.Core.Application.Orders;
using Sanduba.Core.Application.Customers;

namespace Sanduba.Core.Application
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers the necessary services with the DI framework.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>The same service collection.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IOrderInteractor, OrderInteractor>();
            services.AddTransient<ICustomerInteractor, CustomerInteractor>();
            services.AddTransient<IProductInteractor, ProductInteractor>();

            return services;
        }
    }
}
