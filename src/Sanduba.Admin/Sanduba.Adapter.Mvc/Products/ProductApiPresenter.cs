using Microsoft.AspNetCore.Mvc;
using Sanduba.Core.Application.Abstraction.Products;
using Sanduba.Core.Application.Abstraction.Products.ResponseModel;
using System.Collections.Generic;

namespace Sanduba.Adapter.Mvc.Products
{
    public sealed class ProductApiPresenter : ProductPresenter<IActionResult>
    {
        public override IActionResult Present(CreateProductResponseModel responseModel)
        {
            return new OkObjectResult(responseModel);
        }

        public override IActionResult Present(UpdateProductResponseModel responseModel)
        {
            return new OkObjectResult(responseModel);
        }

        public override IActionResult Present(RemoveProductResponseModel responseModel)
        {
            return new OkObjectResult(responseModel);
        }

        public override IActionResult Present(GetProductResponseModel responseModel)
        {
            return new OkObjectResult(responseModel);
        }

        public override IActionResult Present(List<GetProductResponseModel> responseModel)
        {
            return new OkObjectResult(responseModel);
        }
    }
}
