using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using Sanduba.Core.Application.Abstraction.Customers.RequestModel;
using Sanduba.Core.Application.Abstraction.Customers.ResponseModel;
using Sanduba.Core.Application.Abstraction.Customers;
using AutoMapper;

namespace Sanduba.API.Customers
{
    [ApiController]
    [Route("customer")]
    public class CustomerApiEndpoint(ILogger<CustomerApiEndpoint> logger, CustomerController<IActionResult> customerController, IMapper mapper) : ControllerBase
    {
        private readonly ILogger<CustomerApiEndpoint> _logger = logger;
        private readonly CustomerController<IActionResult> customerController = customerController;

        [HttpGet]
        [SwaggerOperation(Summary = "Get all requests")]
        [SwaggerResponse(200, "Request details", typeof(List<GetCustomerResponseModel>))]
        public IActionResult Get()
        {
            try
            {
                return customerController.GetAllCustomers();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while retrivng customers requests: {ex.Message}");
                return BadRequest();
            }

        }

        [HttpPatch(Name = "UpdateRequest")]
        [SwaggerOperation(Summary = "Update order")]
        [SwaggerResponse(200, "Update detail", typeof(UpdateCustomerResponseModel))]
        public IActionResult Post(UpdateCustomerRequestModel request)
        {
            return customerController.UpdateCustomerRequest(request);
        }
    }
}