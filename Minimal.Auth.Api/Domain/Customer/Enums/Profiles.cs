using System.ComponentModel;

namespace Minimal.Auth.Api.Domain.Customer.Enums
{
    public enum Profiles
    {
        [Description("Alguma coisa")]
        Administrator = 0,

        [Description("Alguma coisa 2")]
        Customer = 1,

        [Description("Alguma coisa 3")]
        Staff = 2,
    }
}
