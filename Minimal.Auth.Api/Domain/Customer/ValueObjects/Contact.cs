using Minimal.Auth.Api.Domain.Customer.Entities;

namespace Minimal.Auth.Api.Domain.Customer.VO
{
    public class Contact
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
