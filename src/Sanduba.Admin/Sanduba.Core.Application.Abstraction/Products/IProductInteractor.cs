using Sanduba.Core.Application.Abstraction.Products.RequestModel;
using Sanduba.Core.Application.Abstraction.Products.ResponseModel;
using System.Collections.Generic;

namespace Sanduba.Core.Application.Abstraction.Products
{
    public interface IProductInteractor
    {
        public CreateProductResponseModel CreateProduct(CreateProductRequestModel requestModel);
        public UpdateProductResponseModel RemoveProduct(RemoveProductRequestModel requestModel);
        public UpdateProductResponseModel UpdateProduct(UpdateProductRequestModel requestModel);
        public List<GetProductResponseModel> GetAllProducts();
        public GetProductResponseModel GetProduct(GetProductRequestModel requestModel);
    }
}
