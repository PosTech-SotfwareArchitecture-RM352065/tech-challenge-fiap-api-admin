using Microsoft.AspNetCore.Mvc;
using Sanduba.Core.Application.Abstraction.Orders;
using Sanduba.Core.Application.Abstraction.Orders.ResponseModel;
using System.Collections.Generic;

namespace Sanduba.Adapter.Mvc.Orders
{
    public sealed class OrderApiPresenter : OrderPresenter<IActionResult>
    {
        public override IActionResult Present(IEnumerable<GetOrderResponseModel> responseModel)
        {
            return new OkObjectResult(responseModel);
        }

        public override IActionResult Present(UpdateOrderResponseModel responseModel)
        {
            return new OkObjectResult(responseModel);
        }
    }
}
