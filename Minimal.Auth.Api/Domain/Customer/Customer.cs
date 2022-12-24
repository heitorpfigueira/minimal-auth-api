using Minimal.Auth.Api.Domain.Base;

namespace Minimal.Auth.Api.Domain.Customer
{
    public class Customer : AggregateRoot
    {
        public Customer(Guid id) : base(id)
        {
        }
    }
}
