using System;
using System.Collections.Generic;

namespace Sanduba.Core.Application.Abstraction.Orders.ResponseModel
{
    public record GetOrderResponseModel(
        Guid Id,
        int Code,
        string Status,
        double TotalAmount,
        Guid PaymentId,
        DateTime PayedAt,
        DateTime? AcceptedAt,
        DateTime? FinalizedAt
    );
}
