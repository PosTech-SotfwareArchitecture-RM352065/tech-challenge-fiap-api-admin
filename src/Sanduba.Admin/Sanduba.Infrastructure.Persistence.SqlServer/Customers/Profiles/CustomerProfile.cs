using AutoMapper;
using Sanduba.Core.Domain.Customers;
using Sanduba.Infrastructure.Persistence.SqlServer.Customers.Schemas;

namespace Sanduba.Infrastructure.Persistence.SqlServer.Customers.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerRequestSchema, Request>();
            CreateMap<CustomerRequestSchema, Customer>()
                .ForPath(destination => destination.Id, options => options.MapFrom(source => source.CustomerId));
        }
    }
}
