﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Sanduba.Infrastructure.Persistence.SqlServer.Configurations;
using Sanduba.Core.Domain.Orders;
using Sanduba.Core.Application.Abstraction.Orders;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Sanduba.Infrastructure.Persistence.SqlServer.Orders.Schemas;

namespace Sanduba.Infrastructure.Persistence.SqlServer.Orders
{
    public class OrderRepository(InfrastructureDbContext dbContext, IMapper mapper) : IOrderPersistence
    {
        private readonly InfrastructureDbContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;
        public Task<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _dbContext.Orders
                .Where(item => item.Id == id)
                .ProjectTo<Order>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public Task SaveAsync(Order entity, CancellationToken cancellationToken = default)
        {
            var order = _mapper.Map<OrderSchema>(entity);
            _dbContext.Orders.Add(order);

            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task UpdateAsync(Order entity, CancellationToken cancellationToken = default)
        {
            var order = _mapper.Map<OrderSchema>(entity);
            _dbContext.Orders.Update(order);

            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task<Order> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Orders
                .ToListAsync();

            return _mapper.Map<IEnumerable<Order>>(query);
        }

        public IEnumerable<Order> GetAllOpenOrders(CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Orders
                .Where(order => order.Status == (int)Status.Payed || order.Status == (int)Status.Accepted)
                .OrderBy(order => order.PayedAt)
                .ToList();

            return _mapper.Map<IEnumerable<Order>>(query);
        }

        public void AcceptOrder(Guid id, DateTime acceptedAt)
        {
            _dbContext.Orders
                .Where(order => order.Id == id)
                .ExecuteUpdate(order => order
                    .SetProperty(o => o.AcceptedAt, acceptedAt)
                    .SetProperty(o => o.Status, (int)Status.Accepted)
                );

            _dbContext.SaveChanges();
        }

        public void ConcludeOrder(Guid id, DateTime finalizeAt)
        {
            _dbContext.Orders
                .Where(order => order.Id == id)
                .ExecuteUpdate(order => order
                    .SetProperty(o => o.AcceptedAt, finalizeAt)
                    .SetProperty(o => o.Status, (int)Status.Ready)
                );

            _dbContext.SaveChanges();
        }
    }
}
