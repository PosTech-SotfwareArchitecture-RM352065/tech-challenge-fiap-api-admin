using MassTransit;
using Microsoft.Extensions.Logging;
using Sanduba.Core.Application.Abstraction.Customers;
using Sanduba.Core.Application.Abstraction.Customers.Events;
using System;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Sanduba.Core.Domain.Customers;
using System.Threading;
using MassTransit.DependencyInjection;

namespace Sanduba.Infrastructure.Broker.ServiceBus.Customers
{
    [ExcludeFromCodeCoverage]
    public class CustomerNotificationBroker(
        ILogger<CustomerNotificationBroker> logger,
        ICustomerPersistence customerPersistence,
        Bind<ICustomerBus, IPublishEndpoint> publishClient
    ) : IConsumer<InactivationRequestedEvent>, ICustomerNotification
    {
        private readonly ILogger<CustomerNotificationBroker> _logger = logger;
        private readonly ICustomerPersistence _customerPersistence = customerPersistence;
        private readonly IPublishEndpoint _publishClient = publishClient.Value;

        public Task Consume(ConsumeContext<InactivationRequestedEvent> context)
        {
            try
            {
                _logger.LogInformation($"Customer request received id: {context.MessageId}");

                _customerPersistence.CreateCustomerRequest(context.Message.Id, context.Message.CustomerId, RequestType.Delete, RequestStatus.Requested, "");

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error consuming customer request id: {context.MessageId}, exception: {ex.Message}");
                return Task.FromException(ex);
            }
        }

        public Task UpdateInactivationRequest(InactivationRequestCompletedEvent eventData)
        {
            try
            {
                _logger.LogInformation($"Customer request send id: {eventData.Id}");

                return _publishClient.Publish<InactivationRequestCompletedEvent>(eventData, CancellationToken.None);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error consuming customer send id: {eventData.Id}, exception: {ex.Message}");
                return Task.FromException(ex);
            }

        }
    }
}
