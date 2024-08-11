using Sanduba.Core.Application.Abstraction.Orders.Events;

namespace Sanduba.Core.Application.Abstraction.Orders
{
    public interface IOrderNotification
    {
        public void AcceptOrder(OrderPreparationStartedEvent eventData);
        public void FinalizeOrder(OrderPreparationConcludedEvent eventData);
    }
}
