using Minimal.Auth.Api.Domain.Base;
using Minimal.Auth.Api.Domain.Customer.Enums;
using Minimal.Auth.Api.Domain.Customer.VO;

namespace Minimal.Auth.Api.Domain.Customer.Entities
{
    public class Account : Entity<Guid>
    {
        private Account(Guid id, User user, Profiles profile) : base(id)
        {
            UserId = user.Id;
            User = user;
            ContactEmail = user.Email;
            Profile = Profile.Create(profile);
        }

        public static Account Create(Profiles type, string email, string password)
        {
            var user = User.Create(Guid.NewGuid(), email, password);

            return new(Guid.NewGuid(), user, type);
        }

        public string ContactEmail { get; set; }
        public Profile Profile { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }


        public string Username { get; set; }


        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
