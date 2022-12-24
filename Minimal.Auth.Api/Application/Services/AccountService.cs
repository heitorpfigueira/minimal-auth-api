using Minimal.Auth.Api.Application.Contracts;
using Minimal.Auth.Api.Domain.Customer.Entities;
using Minimal.Auth.Api.Domain.Customer.Enums;
using Minimal.Auth.Api.Infrastructure;
using Minimal.Auth.Api.Interface.Requests;

namespace Minimal.Auth.Api.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApiDbContext _context;
        private readonly IEncoderService _encoder;

        public AccountService(ApiDbContext context, IEncoderService encoder)
        {
            _context = context;
            _encoder = encoder;
        }

        public Account Create(string email, string password)
        {
            var id = Guid.NewGuid();

            password = _encoder.Encode(id, password);

            var account = Account.Create(AccountTypes.Customer, email, password);

            _context.Accounts.Add(account);
            _context.Users.Add(account.User);

            _context.SaveChanges();
            return account;
        }
    }
}
