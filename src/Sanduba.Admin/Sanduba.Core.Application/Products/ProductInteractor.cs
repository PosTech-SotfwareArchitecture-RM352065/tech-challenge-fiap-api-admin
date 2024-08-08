using System.Collections.Generic;
using System.Linq;
using System;
using Sanduba.Core.Domain.Commons.Exceptions;
using Sanduba.Core.Application.Abstraction.Products.ResponseModel;
using Sanduba.Core.Application.Abstraction.Products.RequestModel;
using Sanduba.Core.Application.Abstraction.Products;
using Sanduba.Core.Domain.Products;

namespace Sanduba.Core.Application.Products
{
    public class ProductInteractor(IProductPersistence productPersistence) : IProductInteractor
    {
        private readonly IProductPersistence _productPersistence = productPersistence;

        public CreateProductResponseModel CreateProduct(CreateProductRequestModel requestModel)
        {
            try
            {
                var product = new Product(Guid.NewGuid())
                {
                    Name = requestModel.Name,
                    Description = requestModel.Description,
                    Category = Enum.Parse<Category>(requestModel.Category, true),
                    UnitPrice = requestModel.UnitPrice,
                    IsEnabled = true
                };

                _productPersistence.SaveAsync(product);

                return new CreateProductResponseModel(product.Id);
            }
            catch (DomainException ex)
            {
                throw;
            }
        }

        public UpdateProductResponseModel UpdateProduct(UpdateProductRequestModel requestModel)
        {
            try
            {
                var product = new Product(requestModel.Id)
                {
                    Name = requestModel.Name,
                    Description = requestModel.Description,
                    Category = Enum.Parse<Category>(requestModel.Category, true),
                    UnitPrice = requestModel.UnitPrice,
                    IsEnabled = requestModel.IsEnabled
                };

                _productPersistence.UpdateAsync(product);

                return new UpdateProductResponseModel(product.Id);
            }
            catch (DomainException ex)
            {
                throw;
            }
        }

        public List<GetProductResponseModel> GetAllProducts()
        {
            var products = _productPersistence.GetAllAsync().Result;
            return products.Select(product =>
                new GetProductResponseModel
                (
                    Id: product.Id,
                    Name: product.Name,
                    Description: product.Description,
                    Category: product.Category.ToString(),
                    UnitPrice: product.UnitPrice,
                    IsEnabled: product.IsEnabled
                )).ToList();
        }

        public GetProductResponseModel GetProduct(GetProductRequestModel requestModel)
        {
            var product = _productPersistence.GetByIdAsync(requestModel.Id).Result;

            return new GetProductResponseModel(
                Id: product.Id,
                Name: product.Name,
                Description: product.Description,
                Category: product.Category.ToString(),
                UnitPrice: product.UnitPrice,
                IsEnabled: product.IsEnabled
            );
        }

        public UpdateProductResponseModel RemoveProduct(RemoveProductRequestModel requestModel)
        {
            _productPersistence.RemoveAsync(requestModel.Id);
            return new UpdateProductResponseModel
            (
                Id: requestModel.Id
            );
        }
    }
}
