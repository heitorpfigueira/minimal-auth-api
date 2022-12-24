using Minimal.Auth.Api.Domain.Customer.Enums;

namespace Minimal.Auth.Api.Domain.Customer.ValueObjects
{
    public class Permission
    {
        public PermissionTypes Id { get; set; }
        public string Description { get; set; }
    }
}
