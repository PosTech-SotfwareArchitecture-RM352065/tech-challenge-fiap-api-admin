using Sanduba.Core.Domain.Orders;
using System;

namespace Sanduba.Core.Application.Abstraction.Orders.RequestModel
{
    public record GetOrderRequestModel(Guid Id, Status Status);
}
