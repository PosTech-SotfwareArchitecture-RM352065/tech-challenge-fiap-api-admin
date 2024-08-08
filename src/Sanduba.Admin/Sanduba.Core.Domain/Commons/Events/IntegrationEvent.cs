using System;

namespace Sanduba.Core.Domain.Commons.Events
{
    public record IntegrationEvent
    {
        public DateTime OccurredAt { get; protected set; } = DateTime.UtcNow;
        public string EventType { get; protected set; }
    }
}
