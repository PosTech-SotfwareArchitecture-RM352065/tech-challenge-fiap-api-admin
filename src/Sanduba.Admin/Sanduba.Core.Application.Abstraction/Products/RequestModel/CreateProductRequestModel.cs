using System;

namespace Sanduba.Core.Application.Abstraction.Products.RequestModel
{
    public record CreateProductRequestModel(
        string Name,
        string Description,
        string Category,
        double UnitPrice
    );
}
