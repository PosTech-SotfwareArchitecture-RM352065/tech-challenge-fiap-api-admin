using Microsoft.EntityFrameworkCore;
using Sanduba.Infrastructure.Persistence.SqlServer.Customers.Schemas;
using Sanduba.Infrastructure.Persistence.SqlServer.Orders.Schemas;
using Sanduba.Infrastructure.Persistence.SqlServer.Products.Schemas;

namespace Sanduba.Infrastructure.Persistence.SqlServer.Configurations
{
    public class InfrastructureDbContext : DbContext
    {
        public InfrastructureDbContext(DbContextOptions<InfrastructureDbContext> options) : base(options) { }

        internal DbSet<OrderSchema> Orders { get; set; }
        internal DbSet<CustomerRequestSchema> CustomerRequests { get; set; }
        internal DbSet<ProductSchema> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
