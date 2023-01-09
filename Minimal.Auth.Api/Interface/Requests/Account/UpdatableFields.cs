using Minimal.Auth.Api.Domain.Customer.Enums;
using Minimal.Auth.Api.Domain.Customer.VO;

namespace Minimal.Auth.Api.Interface.Requests.Account
{
    public class UpdatableFields
    {

        public string? ContactEmail { get; set; }
        public Profiles? Profile { get; set; }

        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }


        public string? Username { get; set; }
    }
}
