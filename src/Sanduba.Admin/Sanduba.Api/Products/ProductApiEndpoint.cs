using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sanduba.API.Products.Requests;
using Sanduba.Core.Application.Abstraction.Products;
using Sanduba.Core.Application.Abstraction.Products.RequestModel;
using Sanduba.Core.Application.Abstraction.Products.ResponseModel;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace Sanduba.API.Products
{
    [ApiController]
    [Route("product")]
    public class ProductApiEndpoint
        (ILogger<ProductApiEndpoint> logger, ProductsController<IActionResult> productController) : ControllerBase
    {
        private readonly ILogger<ProductApiEndpoint> _logger = logger;
        private readonly ProductsController<IActionResult> _productController = productController;

        [HttpGet(Name = "GetProducts")]
        [SwaggerOperation(Summary = "Get all products")]
        [SwaggerResponse(200, "Products", typeof(List<GetProductResponseModel>))]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Getting all products");
            return _productController.GetAllProducts();
        }

        [HttpPost(Name = "CreateProduct")]
        [SwaggerOperation(Summary = "Create new product to catalog")]
        [SwaggerResponse(200, "Product Id", typeof(CreateProductResponseModel))]
        public IActionResult Post(CreateProductRequest request)
        {
            _logger.LogInformation("Creating new product");

            var controllerRequest = new CreateProductRequestModel(
                request.Name,
                request.Description,
                request.Category,
                request.UnitPrice
            );

            return _productController.CreateProduct(controllerRequest);
        }

        [HttpDelete(Name = "RemoveProduct")]
        [SwaggerOperation(Summary = "Remove produto do Cart")]
        [SwaggerResponse(200, "Número do Produto", typeof(RemoveProductRequest))]
        public IActionResult Delete(RemoveProductRequest request)
        {
            _logger.LogInformation("Delete product");

            var controllerRequest = new RemoveProductRequestModel(request.Id);

            return _productController.RemoveProduct(controllerRequest);
        }
    }
}