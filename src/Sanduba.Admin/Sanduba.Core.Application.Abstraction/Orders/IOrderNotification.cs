using Sanduba.Core.Application.Abstraction.Orders.Events;

namespace Sanduba.Core.Application.Abstraction.Orders
{
    public interface IOrderNotification
    {
        public void AcceptOrder(OrderAcceptedEvent eventData);
        public void FinalizeOrder(OrderFinalizedEvent eventData);
    }
}
