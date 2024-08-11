using System;
using MassTransit;
using MassTransit.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sanduba.Core.Application.Abstraction.Orders;
using Sanduba.Core.Application.Abstraction.Orders.Events;
using Sanduba.Core.Domain.Orders;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Sanduba.Infrastructure.Broker.ServiceBus.Orders
{
    [ExcludeFromCodeCoverage]
    public class OrderNotificationBroker(
        ILogger<OrderNotificationBroker> logger,
        IOrderPersistence orderPersistence,
        Bind<IOrderBus, IPublishEndpoint> publishClient
    ) : IConsumer<OrderPreparationRequestedEvent>, IOrderNotification
    {
        private readonly ILogger<OrderNotificationBroker> _logger = logger;
        private readonly IOrderPersistence _orderPersistence = orderPersistence;
        private readonly IPublishEndpoint _publishEndpoint = publishClient.Value;

        public Task Consume(ConsumeContext<OrderPreparationRequestedEvent> context)
        {
            try
            {
                _logger.LogInformation($"Message received id: {context.MessageId}");

                orderPersistence.SaveAsync(new Order(context.Message.OrderId)
                {
                    Code = context.Message.Code,
                    PaymentId = context.Message.PaymentId,
                    Status = context.Message.Status,
                    TotalAmount = context.Message.TotalAmount,
                    PayedAt = context.Message.PayedAt
                }).Wait();

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error consuming message id: {context.MessageId}");

                return Task.FromException(ex);
            }

        }

        public void AcceptOrder(OrderPreparationStartedEvent eventData)
        {
            _publishEndpoint.Publish<OrderPreparationStartedEvent>(eventData);
        }

        public void FinalizeOrder(OrderPreparationConcludedEvent eventData)
        {
            _publishEndpoint.Publish<OrderPreparationConcludedEvent>(eventData);
        }
    }
}
