using System;

namespace Sanduba.Core.Application.Abstraction.Products.RequestModel
{
    public record UpdateProductRequestModel(
        Guid Id,
        string Name,
        string Description,
        string Category,
        double UnitPrice,
        bool IsEnabled
    );
}
