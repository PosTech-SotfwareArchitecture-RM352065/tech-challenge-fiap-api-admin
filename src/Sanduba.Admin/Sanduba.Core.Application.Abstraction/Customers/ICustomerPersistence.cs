using Sanduba.Core.Application.Abstraction.Commons;
using Sanduba.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Sanduba.Core.Application.Abstraction.Customers
{
    public interface ICustomerPersistence : IAsyncPersistenceGateway<Guid, Customer>
    {
        public IEnumerable<Customer> GetAllRequests(CancellationToken cancellationToken = default);
        public void UpdateCustomerRequest(Guid requestId, RequestStatus status, string comments, CancellationToken cancellationToken = default);
        public void CreateCustomerRequest(Guid requestId, Guid customerId, RequestType type, RequestStatus status, string comments, CancellationToken cancellationToken = default);
    }
}
