using System;
using Sanduba.Core.Domain.Commons.Types;
using Sanduba.Core.Domain.Commons.Assertions;

namespace Sanduba.Core.Domain.Orders
{
    public sealed class Order(Guid id) : Entity<Guid>(id)
    {
        public int? Code { get; init; }
        public Guid CustomerId { get; init; }
        public Status Status { get; private set; }
        public double TotalAmount { get; init; }
        public Guid PaymentId { get; init; }
        public DateTime PayedAt { get; init; }
        public DateTime? AcceptedAt { get; init; }
        public DateTime? FinalizedAt { get; init; }

        public void Accept()
        {
            AssertionConcern.AssertArgumentNotEqual(Status, Status.Payed, "Pedido deve estar com status de PAGO");

            Status = Status.Accepted;
        }

        public void Reject()
        {
            AssertionConcern.AssertArgumentNotEqual(Status, Status.Payed, "Pedido deve estar com status de PAGO");

            Status = Status.Reject;
        }

        public void Cancel()
        {
            AssertionConcern.AssertArgumentNotEqual(Status, Status, "Pedido deve estar com status de RECEBIDO");

            Status = Status.Cancelled;
        }

        public void Ready()
        {
            AssertionConcern.AssertArgumentNotEqual(Status, Status.Accepted, "Pedido deve estar com status de EM PREPARAÇÃO");

            Status = Status.Ready;
        }

        public void Close()
        {
            AssertionConcern.AssertArgumentNotEqual(Status, Status.Ready, "Pedido deve estar com status de PRONTO");

            Status = Status.Concluded;
        }

        public override void ValidateEntity()
        {

        }
    }
}
