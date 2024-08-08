using MassTransit;
using Microsoft.Extensions.Logging;
using Sanduba.Core.Application.Abstraction.Orders;
using Sanduba.Core.Application.Abstraction.Orders.Events;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Sanduba.Infrastructure.Broker.ServiceBus.Orders
{
    [ExcludeFromCodeCoverage]
    public class OrderNotificationBroker(
        ILogger<OrderNotificationBroker> logger
    ) : IConsumer<OrderPaymentCompletedEvent>, IOrderNotification
    {
        private readonly ILogger<OrderNotificationBroker> _logger = logger;

        public Task Consume(ConsumeContext<OrderPaymentCompletedEvent> context)
        {
            _logger.LogInformation($"Message received id: {context.MessageId}");

            throw new System.NotImplementedException();
        }

        public void AcceptOrder(OrderAcceptedEvent eventData)
        {
            throw new System.NotImplementedException();
        }

        public void FinalizeOrder(OrderFinalizedEvent eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}
