using System;

namespace Sanduba.Core.Application.Abstraction.Products.ResponseModel
{
    public record GetProductResponseModel(
        Guid Id,
        string Name,
        string Description,
        string Category,
        double UnitPrice,
        bool IsEnabled
    );
}
