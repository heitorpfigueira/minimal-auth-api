namespace Minimal.Auth.Api.Domain.Base
{
    public abstract class AggregateRoot : Entity<Guid>
    {
        protected AggregateRoot(Guid id) : base(id)
        {
        }
    }
}
