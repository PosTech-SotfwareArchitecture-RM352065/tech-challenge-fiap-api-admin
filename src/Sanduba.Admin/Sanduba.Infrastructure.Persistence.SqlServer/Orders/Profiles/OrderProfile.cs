using AutoMapper;
using Sanduba.Core.Domain.Orders;
using Sanduba.Infrastructure.Persistence.SqlServer.Orders.Schemas;

namespace Sanduba.Infrastructure.Persistence.SqlServer.Orders.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderSchema>();
            CreateMap<OrderSchema, Order>();
        }
    }
}
