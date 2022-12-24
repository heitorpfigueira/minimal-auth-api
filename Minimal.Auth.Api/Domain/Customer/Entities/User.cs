using Minimal.Auth.Api.Domain.Base;

namespace Minimal.Auth.Api.Domain.Customer.Entities
{
    public class User : Entity<Guid>
    {
        private User(Guid id, string email, string password) : base(id)
        {
            this.Email = email;
            this.Password = password;
        }

        public static User Create(Guid id, string email, string password)
        {
            return new(id, email, password);
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
