using System;

namespace Sanduba.Core.Application.Abstraction.Customers.RequestModel
{
    public record UpdateCustomerRequestModel(Guid RequestId, string Status, string Comments);
}
