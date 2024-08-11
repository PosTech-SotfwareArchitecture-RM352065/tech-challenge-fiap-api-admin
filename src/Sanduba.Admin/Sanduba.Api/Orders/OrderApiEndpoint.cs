using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using Sanduba.Core.Application.Abstraction.Orders.ResponseModel;
using Sanduba.Core.Application.Abstraction.Orders;
using Sanduba.API.Orders.Requests;
using AutoMapper;

namespace Sanduba.API.Orders
{
    [ApiController]
    [Route("order")]
    public class OrderApiEndpoint(ILogger<OrderApiEndpoint> logger, OrderController<IActionResult> orderController, IMapper mapper) : ControllerBase
    {
        private readonly ILogger<OrderApiEndpoint> _logger = logger;
        private readonly OrderController<IActionResult> orderController = orderController;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [SwaggerOperation(Summary = "Get Orders")]
        [SwaggerResponse(200, "Order details", typeof(GetOrderResponseModel))]
        public IActionResult Get()
        {
            try
            {
                return orderController.GetAllOpenOrders();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while retrivng id from query string: {Request.Query}");
                return BadRequest("Erro durante a consulta de pedidos!");
            }

        }

        [HttpPatch]
        [SwaggerOperation(Summary = "Update order")]
        [SwaggerResponse(200, "Order Id", typeof(UpdateOrderResponseModel))]
        public IActionResult Patch(OrderApiUpdateRequest request)
        {
            if (request.Status == "ACCEPT")
                return orderController.AcceptOrder(request.OrderId);
            if (request.Status == "FINALIZE")
                return orderController.FinalizeOrder(request.OrderId);
            else
            {
                _logger.LogError($"Invalid status {request.Status}");
                return BadRequest($"Status inválido {request.Status}");
            }
        }
    }
}