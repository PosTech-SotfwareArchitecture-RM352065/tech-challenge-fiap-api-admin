using Microsoft.AspNetCore.Mvc;
using Sanduba.Core.Application.Abstraction.Products;
using Sanduba.Core.Application.Abstraction.Products.RequestModel;

namespace Sanduba.Adapter.Mvc.Products
{
    public sealed class ProductApiController : ProductsController<IActionResult>
    {
        private new readonly IProductInteractor interactor;
        private new readonly ProductPresenter<IActionResult> presenter;

        public ProductApiController(IProductInteractor interactor, ProductPresenter<IActionResult> presenter) : base(interactor, presenter)
        {
            this.interactor = interactor;
            this.presenter = presenter;
        }

        public override IActionResult CreateProduct(CreateProductRequestModel requestModel)
        {
            var responseModel = interactor.CreateProduct(requestModel);
            return presenter.Present(responseModel);
        }

        public override IActionResult GetProduct(GetProductRequestModel requestModel)
        {
            var responseModel = interactor.GetProduct(requestModel);
            return presenter.Present(responseModel);
        }

        public override IActionResult RemoveProduct(RemoveProductRequestModel requestModel)
        {
            var responseModel = interactor.RemoveProduct(requestModel);
            return presenter.Present(responseModel);
        }

        public override IActionResult UpdateProduct(UpdateProductRequestModel requestModel)
        {
            var responseModel = interactor.UpdateProduct(requestModel);
            return presenter.Present(responseModel);
        }

        public override IActionResult GetAllProducts()
        {
            var responseModel = interactor.GetAllProducts();
            return presenter.Present(responseModel);
        }
    }
}
