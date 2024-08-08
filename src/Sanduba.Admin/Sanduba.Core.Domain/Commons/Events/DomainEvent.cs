using System;

namespace Sanduba.Core.Domain.Commons.Events
{
    public record DomainEvent
    {
        public DateTime OccurredAt { get; protected set; } = DateTime.UtcNow;
    }
}
