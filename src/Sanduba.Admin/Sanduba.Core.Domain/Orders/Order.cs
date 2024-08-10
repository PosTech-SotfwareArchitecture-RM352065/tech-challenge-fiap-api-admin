using System;
using Sanduba.Core.Domain.Commons.Types;
using Sanduba.Core.Domain.Commons.Assertions;

namespace Sanduba.Core.Domain.Orders
{
    public sealed class Order(Guid id) : Entity<Guid>(id)
    {
        public int? Code { get; init; }
        public Status Status { get; init; }
        public double TotalAmount { get; init; }
        public Guid PaymentId { get; init; }
        public DateTime PayedAt { get; init; }
        public DateTime? AcceptedAt { get; init; }
        public DateTime? FinalizedAt { get; init; }

        public override void ValidateEntity()
        {

        }
    }
}
