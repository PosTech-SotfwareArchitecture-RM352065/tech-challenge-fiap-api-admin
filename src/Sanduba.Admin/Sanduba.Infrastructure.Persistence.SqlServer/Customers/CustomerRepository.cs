using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using Sanduba.Core.Application.Abstraction.Customers;
using Sanduba.Infrastructure.Persistence.SqlServer.Customers.Schemas;
using Sanduba.Infrastructure.Persistence.SqlServer.Configurations;
using Sanduba.Core.Domain.Customers;
using Microsoft.EntityFrameworkCore;


namespace Sanduba.Infrastructure.Persistence.SqlServer.Customers
{
    public class CustomerRepository(InfrastructureDbContext dbContext, IMapper mapper)
        : ICustomerPersistence
    {
        private readonly InfrastructureDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public void CreateCustomerRequest(Guid requestId, Guid customerId, RequestType type, RequestStatus status, string comments, CancellationToken cancellationToken = default)
        {
            _dbContext.CustomerRequests.Add(new CustomerRequestSchema()
            {
                Id = requestId,
                CustomerId = customerId,
                Comments = comments,
                RequestedAt = DateTime.UtcNow,
                Status = status.ToString(),
                Type = type.ToString()
            });

            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var query = _dbContext.CustomerRequests
                .Where(request => request.Status == RequestStatus.Requested.ToString());

            return query.GroupBy(request => request.CustomerId)
                .Select(customer => new Customer(customer.Key)
                {
                    Requests = customer.Select(request => new Request(request.Id)
                    {
                        Status = Enum.Parse<RequestStatus>(request.Status),
                        Type = Enum.Parse<RequestType>(request.Type),
                        RequestedAt = request.RequestedAt,
                        Comments = request.Comments
                    }).ToList()
                }).ToList();
        }

        public IEnumerable<Customer> GetAllRequests(CancellationToken cancellationToken = default)
        {
            var query = _dbContext.CustomerRequests
                .Where(request => request.Status == RequestStatus.Requested.ToString());

            return _mapper.Map<IEnumerable<Customer>>(query);
        }

        public Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Customer entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomerRequest(Guid requestId, RequestStatus status, string comments, CancellationToken cancellationToken = default)
        {
            _dbContext.CustomerRequests
                .Where(request => request.Id == requestId)
                .ExecuteUpdateAsync(request => request
                    .SetProperty(o => o.Status, status.ToString())
                    .SetProperty(o => o.Comments, comments)
                );
        }
    }
}
