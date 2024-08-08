using System;
using System.Collections.Generic;

namespace Sanduba.Core.Application.Abstraction.Customers.ResponseModel
{
    public record CustomerRequestResponseModel(
        Guid Id,
        DateTime RequestedAt,
        string Type,
        string Status,
        string Comments
    );

    public record GetCustomerResponseModel(
        Guid Id,
        List<CustomerRequestResponseModel> Requests
    );
}
