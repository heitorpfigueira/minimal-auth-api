using Minimal.Auth.Api.Domain.Base;
using Minimal.Auth.Api.Domain.Customer.Enums;

namespace Minimal.Auth.Api.Domain.Customer.Entities
{
    public class Account : Entity<Guid>
    {
        private Account(Guid id, User user, AccountTypes type) : base(id)
        {
            this.UserId = user.Id;
            this.User = user;
            this.ContactEmail = user.Email;
            this.AccountType = type;
        }

        public static Account Create(AccountTypes type, string email, string password)
        {
            var user = User.Create(Guid.NewGuid(), email, password);

            return new(Guid.NewGuid(), user, type);
        }

        public string ContactEmail { get; set; }
        public AccountTypes AccountType { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }


        public string Username { get; set; }


        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
