using System;

namespace Sanduba.Core.Application.Abstraction.Orders.Events
{
    public record OrderFinalizedEvent(Guid Id, DateTime FinalizedAt);
}
