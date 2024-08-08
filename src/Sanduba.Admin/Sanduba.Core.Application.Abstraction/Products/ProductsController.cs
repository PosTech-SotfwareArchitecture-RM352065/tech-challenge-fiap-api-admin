using Sanduba.Core.Application.Abstraction.Products.RequestModel;

namespace Sanduba.Core.Application.Abstraction.Products
{
    public abstract class ProductsController<T>
    {
        protected readonly IProductInteractor interactor;
        protected readonly ProductPresenter<T> presenter;

        protected ProductsController(IProductInteractor interactor, ProductPresenter<T> presenter)
        {
            this.interactor = interactor;
            this.presenter = presenter;
        }

        public abstract T CreateProduct(CreateProductRequestModel requestModel);
        public abstract T RemoveProduct(RemoveProductRequestModel requestModel);
        public abstract T UpdateProduct(UpdateProductRequestModel requestModel);
        public abstract T GetProduct(GetProductRequestModel requestModel);
        public abstract T GetAllProducts();

    }
}
