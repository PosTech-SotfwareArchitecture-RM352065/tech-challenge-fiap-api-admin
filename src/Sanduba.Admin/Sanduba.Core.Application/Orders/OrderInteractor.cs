using Sanduba.Core.Application.Abstraction.Orders;
using Sanduba.Core.Application.Abstraction.Orders.Events;
using Sanduba.Core.Application.Abstraction.Orders.RequestModel;
using Sanduba.Core.Application.Abstraction.Orders.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sanduba.Core.Application.Orders
{
    public sealed class OrderInteractor(
        IOrderPersistence orderPersistence,
        IOrderNotification orderNotification) : IOrderInteractor
    {
        private readonly IOrderPersistence _orderPersistence = orderPersistence;
        private readonly IOrderNotification _orderNotification = orderNotification;

        public GetOrderResponseModel GetOrder(GetOrderRequestModel requestModel)
        {
            var order = _orderPersistence.GetByIdAsync(requestModel.Id).Result;

            return new GetOrderResponseModel(
                Id: order.Id,
                Code: (int)order.Code,
                Status: order.Status.ToString(),
                TotalAmount: order.TotalAmount,
                PaymentId: order.PaymentId,
                PayedAt: order.PayedAt,
                AcceptedAt: order.AcceptedAt,
                FinalizedAt: order.FinalizedAt
            );
        }

        public IEnumerable<GetOrderResponseModel> GetAllOrders()
        {
            var orders = _orderPersistence.GetAllAsync().Result;

            return orders.Select(order => new GetOrderResponseModel(
                Id: order.Id,
                Code: (int)order.Code,
                Status: order.Status.ToString(),
                TotalAmount: order.TotalAmount,
                PaymentId: order.PaymentId,
                PayedAt: order.PayedAt,
                AcceptedAt: order.AcceptedAt,
                FinalizedAt: order.FinalizedAt
            ));
        }

        public IEnumerable<GetOrderResponseModel> GetAllOpenOrders()
        {
            var orders = _orderPersistence.GetAllOpenOrders();

            return orders.Select(order => new GetOrderResponseModel(
                Id: order.Id,
                Code: (int)order.Code,
                Status: order.Status.ToString(),
                TotalAmount: order.TotalAmount,
                PaymentId: order.PaymentId,
                PayedAt: order.PayedAt,
                AcceptedAt: order.AcceptedAt,
                FinalizedAt: order.FinalizedAt
            ));
        }

        public UpdateOrderResponseModel AcceptOrder(Guid requestModel)
        {
            var acceptedAt = DateTime.UtcNow;

            _orderPersistence.AcceptOrder(requestModel, acceptedAt);
            _orderNotification.AcceptOrder(new OrderAcceptedEvent(requestModel, acceptedAt));

            return new UpdateOrderResponseModel(requestModel);
        }

        public UpdateOrderResponseModel FinalizeOrder(Guid requestModel)
        {
            var finalizedAt = DateTime.UtcNow;

            _orderPersistence.FinalizeOrder(requestModel, finalizedAt);
            _orderNotification.FinalizeOrder(new OrderFinalizedEvent(requestModel, finalizedAt));

            return new UpdateOrderResponseModel(requestModel);
        }
    }
}
