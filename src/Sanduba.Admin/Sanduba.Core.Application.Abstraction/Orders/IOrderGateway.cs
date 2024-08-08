using System;
using Sanduba.Core.Application.Abstraction.Orders.ResponseModel;

namespace Sanduba.Core.Application.Abstraction.Orders
{
    public interface IOrderGateway
    {
        public GetOrderResponseModel GetOrder(Guid requestModel);
    }
}
