using Microsoft.AspNetCore.Mvc;
using Sanduba.Core.Application.Abstraction.Customers;
using Sanduba.Core.Application.Abstraction.Customers.RequestModel;

namespace Sanduba.Adapter.Mvc.Customers
{
    public sealed class CustomerApiController(ICustomerInteractor interactor, CustomerPresenter<IActionResult> presenter)
        : CustomerController<IActionResult>(interactor, presenter)
    {
        public override IActionResult GetAllCustomers()
        {
            var responseModel = interactor.GetAllCustomers();
            return presenter.Present(responseModel);
        }

        public override IActionResult GetCustomer(GetCustomerRequestModel requestModel)
        {
            var responseModel = interactor.GetCustomer(requestModel);
            return presenter.Present(responseModel);
        }

        public override IActionResult UpdateCustomerRequest(UpdateCustomerRequestModel requestModel)
        {
            var responseModel = interactor.UpdateCustomerRequest(requestModel);
            return presenter.Present(responseModel);
        }
    }
}
