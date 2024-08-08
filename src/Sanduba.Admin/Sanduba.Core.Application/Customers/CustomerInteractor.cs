using Sanduba.Core.Application.Abstraction.Customers;
using Sanduba.Core.Application.Abstraction.Customers.RequestModel;
using Sanduba.Core.Application.Abstraction.Customers.ResponseModel;
using Sanduba.Core.Application.Abstraction.Customers.Events;
using Sanduba.Core.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sanduba.Core.Application.Customers
{
    public sealed class CustomerInteractor(
        ICustomerPersistence customerPersistence,
        ICustomerNotification customerNotification) : ICustomerInteractor
    {
        private readonly ICustomerPersistence _customerPersistence = customerPersistence;
        private readonly ICustomerNotification _customerNotification = customerNotification;

        public GetCustomerResponseModel GetCustomer(GetCustomerRequestModel requestModel)
        {
            var customer = _customerPersistence.GetByIdAsync(requestModel.Id).Result;

            return new GetCustomerResponseModel(
                    customer.Id,
                    customer.Requests.Select(request => new CustomerRequestResponseModel(
                        request.Id,
                        request.RequestedAt,
                        request.Type.ToString(),
                        request.Status.ToString(),
                        request.Comments
                    )).ToList()
                );
        }

        public IEnumerable<GetCustomerResponseModel> GetAllCustomers()
        {
            var customers = _customerPersistence.GetAllAsync().Result;

            return customers.Select(customer => new GetCustomerResponseModel(
                    customer.Id,
                    customer.Requests.Select(request => new CustomerRequestResponseModel(
                        request.Id,
                        request.RequestedAt,
                        request.Type.ToString(),
                        request.Status.ToString(),
                        request.Comments
                    )).ToList()
                )).ToList();
        }

        public UpdateCustomerResponseModel UpdateCustomerRequest(UpdateCustomerRequestModel requestModel)
        {
            if (Enum.TryParse(requestModel.Status, out RequestStatus status))
            {
                _customerPersistence.UpdateCustomerRequest(requestModel.RequestId, status, requestModel.Comments);

                _customerNotification.UpdateInactivationRequest(
                    new InactivationRequestCompletedEvent(requestModel.RequestId, status, DateTime.UtcNow)
                );

                return new UpdateCustomerResponseModel(requestModel.RequestId);
            }
            else
            {
                throw new ArgumentException("Invalid status!", nameof(requestModel.Status));
            }

        }
    }
}
