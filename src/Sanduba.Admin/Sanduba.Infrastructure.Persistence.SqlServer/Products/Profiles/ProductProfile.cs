using AutoMapper;
using Sanduba.Core.Domain.Products;
using Sanduba.Infrastructure.Persistence.SqlServer.Products.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanduba.Infrastructure.Persistence.SqlServer.Products.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductSchema>();
            CreateMap<ProductSchema, Product>();
        }
    }
}
