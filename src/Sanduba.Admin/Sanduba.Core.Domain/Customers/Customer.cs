using Sanduba.Core.Domain.Commons.Types;
using System;
using System.Collections.Generic;

namespace Sanduba.Core.Domain.Customers
{
    public sealed class Customer(Guid id) : Entity<Guid>(id)
    {
        public List<Request> Requests { get; init; }

        public override void ValidateEntity()
        {

        }
    }
}
