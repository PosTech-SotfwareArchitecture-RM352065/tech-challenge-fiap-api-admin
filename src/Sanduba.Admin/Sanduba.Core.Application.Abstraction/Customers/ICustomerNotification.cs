using Sanduba.Core.Application.Abstraction.Customers.Events;
using System.Threading.Tasks;

namespace Sanduba.Core.Application.Abstraction.Customers
{
    public interface ICustomerNotification
    {
        public Task UpdateInactivationRequest(InactivationRequestCompletedEvent eventData);
    }
}
