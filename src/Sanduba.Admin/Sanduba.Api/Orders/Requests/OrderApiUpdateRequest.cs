using System;

namespace Sanduba.API.Orders.Requests
{
    public record OrderApiUpdateRequest(Guid OrderId, string Status);
}
