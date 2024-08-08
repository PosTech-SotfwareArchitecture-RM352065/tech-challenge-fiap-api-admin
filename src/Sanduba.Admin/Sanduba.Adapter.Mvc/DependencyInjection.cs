using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sanduba.Core.Application.Abstraction.Customers;
using Sanduba.Core.Application.Abstraction.Products;
using Sanduba.Core.Application.Abstraction.Orders;
using Sanduba.Adapter.Mvc.Customers;
using Sanduba.Adapter.Mvc.Orders;
using Sanduba.Adapter.Mvc.Products;

namespace Sanduba.Adapter.Mvc
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers the necessary services with the DI framework.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>The same service collection.</returns>
        public static IServiceCollection AddMvcAdapter(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<OrderController<IActionResult>, OrderApiController>();
            services.AddTransient<OrderPresenter<IActionResult>, OrderApiPresenter>();
            services.AddTransient<CustomerController<IActionResult>, CustomerApiController>();
            services.AddTransient<CustomerPresenter<IActionResult>, CustomerApiPresenter>();
            services.AddTransient<ProductsController<IActionResult>, ProductApiController>();
            services.AddTransient<ProductPresenter<IActionResult>, ProductApiPresenter>();

            return services;
        }
    }
}

