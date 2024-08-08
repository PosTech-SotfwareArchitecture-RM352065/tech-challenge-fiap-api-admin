using Sanduba.Core.Application.Abstraction.Customers.RequestModel;
using Sanduba.Core.Application.Abstraction.Customers.ResponseModel;

namespace Sanduba.Core.Application.Abstraction.Customers
{
    public interface ICustomerGateway
    {
        public GetCustomerResponseModel GetCustomer(GetCustomerRequestModel requestModel);
        public GetCustomerResponseModel GetAllCustomers();
    }
}
