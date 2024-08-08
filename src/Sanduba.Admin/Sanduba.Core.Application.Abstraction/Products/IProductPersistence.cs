using Sanduba.Core.Application.Abstraction.Commons;
using Sanduba.Core.Domain.Products;
using System;

namespace Sanduba.Core.Application.Abstraction.Products
{
    public interface IProductPersistence : IAsyncPersistenceGateway<Guid, Product>
    {
    }
}
