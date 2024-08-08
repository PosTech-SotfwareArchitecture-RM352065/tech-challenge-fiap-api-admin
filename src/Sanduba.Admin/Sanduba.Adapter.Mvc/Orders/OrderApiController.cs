using Microsoft.AspNetCore.Mvc;
using Sanduba.Core.Application.Abstraction.Orders;
using Sanduba.Core.Application.Abstraction.Orders.RequestModel;
using System;

namespace Sanduba.Adapter.Mvc.Orders
{
    public sealed class OrderApiController(IOrderInteractor interactor, OrderPresenter<IActionResult> presenter)
        : OrderController<IActionResult>(interactor, presenter)
    {
        public override IActionResult AcceptOrder(Guid requestModel)
        {
            var responseModel = interactor.AcceptOrder(requestModel);
            return presenter.Present(responseModel);
        }

        public override IActionResult FinalizeOrder(Guid requestModel)
        {
            var responseModel = interactor.FinalizeOrder(requestModel);
            return presenter.Present(responseModel);
        }

        public override IActionResult GetAllOpenOrders()
        {
            var responseModel = interactor.GetAllOpenOrders();
            return presenter.Present(responseModel);
        }

        public override IActionResult GetAllOrders()
        {
            var responseModel = interactor.GetAllOrders();
            return presenter.Present(responseModel);
        }
    }
}
