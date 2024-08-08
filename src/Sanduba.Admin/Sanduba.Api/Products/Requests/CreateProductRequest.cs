using System;

namespace Sanduba.API.Products.Requests
{
    public record CreateProductRequest(string Name, string Description, string Category, double UnitPrice);
}
