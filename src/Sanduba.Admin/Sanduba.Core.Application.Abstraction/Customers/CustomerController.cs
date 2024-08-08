using Sanduba.Core.Application.Abstraction.Customers.RequestModel;

namespace Sanduba.Core.Application.Abstraction.Customers
{
    public abstract class CustomerController<T>
        (ICustomerInteractor interactor, CustomerPresenter<T> presenter)
    {
        protected readonly ICustomerInteractor _interactor = interactor;
        protected readonly CustomerPresenter<T> _presenter = presenter;

        public abstract T GetAllCustomers();
        public abstract T GetCustomer(GetCustomerRequestModel requestModel);
        public abstract T UpdateCustomerRequest(UpdateCustomerRequestModel requestModel);
    }
}
