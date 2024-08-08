using Sanduba.Core.Application.Abstraction.Orders.RequestModel;
using Sanduba.Core.Application.Abstraction.Orders.ResponseModel;
using System;
using System.Collections.Generic;

namespace Sanduba.Core.Application.Abstraction.Orders
{
    public interface IOrderInteractor
    {
        public IEnumerable<GetOrderResponseModel> GetAllOrders();
        public IEnumerable<GetOrderResponseModel> GetAllOpenOrders();
        public UpdateOrderResponseModel AcceptOrder(Guid id);
        public UpdateOrderResponseModel FinalizeOrder(Guid id);
    }
}
