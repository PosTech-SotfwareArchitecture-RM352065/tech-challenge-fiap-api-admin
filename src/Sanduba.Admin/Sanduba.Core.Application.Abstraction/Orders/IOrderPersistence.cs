using Sanduba.Core.Application.Abstraction.Commons;
using Sanduba.Core.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Sanduba.Core.Application.Abstraction.Orders
{
    public interface IOrderPersistence : IAsyncPersistenceGateway<Guid, Order>
    {
        public IEnumerable<Order> GetAllOpenOrders(CancellationToken cancellationToken = default);
        public void AcceptOrder(Guid id, DateTime acceptedAt);
        public void ConcludeOrder(Guid id, DateTime concludedAt);
    }
}
