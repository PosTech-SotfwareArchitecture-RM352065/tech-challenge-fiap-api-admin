using Sanduba.Core.Domain.Orders;
using System;

namespace Sanduba.Core.Application.Abstraction.Orders.Events
{
    public record OrderPaymentCompletedEvent(
        Guid OrderId,
        int Code,
        Status Status,
        double TotalAmount,
        Guid PaymentId,
        DateTime PayedAt
    );
}
