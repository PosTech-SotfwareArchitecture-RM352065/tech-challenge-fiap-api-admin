using Microsoft.AspNetCore.Mvc;
using Sanduba.Core.Application.Abstraction.Customers;
using Sanduba.Core.Application.Abstraction.Customers.ResponseModel;
using System.Collections.Generic;

namespace Sanduba.Adapter.Mvc.Customers
{
    public sealed class CustomerApiPresenter : CustomerPresenter<IActionResult>
    {
        public override IActionResult Present(IEnumerable<GetCustomerResponseModel> responseModel)
        {
            return new OkObjectResult(responseModel);
        }

        public override IActionResult Present(GetCustomerResponseModel responseModel)
        {
            return new OkObjectResult(responseModel);
        }

        public override IActionResult Present(UpdateCustomerResponseModel responseModel)
        {
            return new OkObjectResult(responseModel);
        }
    }
}
