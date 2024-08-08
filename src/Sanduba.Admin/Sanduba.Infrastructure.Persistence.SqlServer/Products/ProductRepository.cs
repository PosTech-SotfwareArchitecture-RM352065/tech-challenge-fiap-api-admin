using AutoMapper;
using Sanduba.Core.Application.Abstraction.Products;
using Sanduba.Core.Domain.Products;
using Sanduba.Infrastructure.Persistence.SqlServer.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sanduba.Infrastructure.Persistence.SqlServer.Products
{
    internal class ProductRepository(InfrastructureDbContext dbContext, IMapper mapper)
        : IProductPersistence
    {
        private readonly InfrastructureDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Product> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Product entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
