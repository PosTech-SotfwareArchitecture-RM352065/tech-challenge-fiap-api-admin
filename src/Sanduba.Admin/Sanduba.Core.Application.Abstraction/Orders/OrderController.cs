using System;

namespace Sanduba.Core.Application.Abstraction.Orders
{
    public abstract class OrderController<T>
        (IOrderInteractor interactor, OrderPresenter<T> presenter)
    {
        protected readonly IOrderInteractor _interactor = interactor;
        protected readonly OrderPresenter<T> _presenter = presenter;

        public abstract T GetAllOrders();
        public abstract T GetAllOpenOrders();
        public abstract T AcceptOrder(Guid requestModel);
        public abstract T FinalizeOrder(Guid requestModel);
    }
}
