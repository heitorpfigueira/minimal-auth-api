namespace Minimal.Auth.Api.Domain.Base
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
        where TId : notnull
    {
        protected Entity(TId id)
        {
            Id = id;
        }

        public TId Id { get; protected init; }

        public static bool operator ==(Entity<TId>? first, Entity<TId>? second)
        {
            return first is not null && second is not null && first.Equals(second);
        }

        public static bool operator !=(Entity<TId>? first, Entity<TId>? second)
        {
            return !(first == second);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null ||
                obj.GetType() != GetType() ||
                obj is not Entity<TId> entity)
                return false;

            return Id.Equals(entity.Id);
        }

        public bool Equals(Entity<TId>? other)
        {
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() * 41;
        }
    }
}
