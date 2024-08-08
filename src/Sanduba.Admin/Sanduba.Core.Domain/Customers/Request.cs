using Sanduba.Core.Domain.Commons.Types;
using System;

namespace Sanduba.Core.Domain.Customers
{
    public class Request(Guid id) : Entity<Guid>(id)
    {
        public DateTime RequestedAt { get; init; }
        public RequestType Type { get; init; }
        public RequestStatus Status { get; init; }
        public string? Comments { get; init; }

        public override void ValidateEntity()
        {

        }
    }
}
