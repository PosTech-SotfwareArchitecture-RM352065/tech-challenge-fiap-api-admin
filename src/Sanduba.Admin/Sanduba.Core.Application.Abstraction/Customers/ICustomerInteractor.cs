using Sanduba.Core.Application.Abstraction.Customers.RequestModel;
using Sanduba.Core.Application.Abstraction.Customers.ResponseModel;
using System.Collections.Generic;

namespace Sanduba.Core.Application.Abstraction.Customers
{
    public interface ICustomerInteractor
    {
        public IEnumerable<GetCustomerResponseModel> GetAllCustomers();
        public GetCustomerResponseModel GetCustomer(GetCustomerRequestModel requestModel);
        public UpdateCustomerResponseModel UpdateCustomerRequest(UpdateCustomerRequestModel requestModel);
    }
}
