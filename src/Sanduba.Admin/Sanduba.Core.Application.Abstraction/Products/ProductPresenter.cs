using Sanduba.Core.Application.Abstraction.Products.ResponseModel;
using System.Collections.Generic;

namespace Sanduba.Core.Application.Abstraction.Products
{
    public abstract class ProductPresenter<T>
    {
        public abstract T Present(CreateProductResponseModel responseModel);
        public abstract T Present(UpdateProductResponseModel responseModel);
        public abstract T Present(RemoveProductResponseModel responseModel);
        public abstract T Present(GetProductResponseModel responseModel);
        public abstract T Present(List<GetProductResponseModel> responseModel);
    }
}
