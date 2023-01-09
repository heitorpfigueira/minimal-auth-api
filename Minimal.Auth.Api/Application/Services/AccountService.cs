using Minimal.Auth.Api.Application.Contracts;
using Minimal.Auth.Api.Domain.Customer.Entities;
using Minimal.Auth.Api.Domain.Customer.Enums;
using Minimal.Auth.Api.Infrastructure;
using Minimal.Auth.Api.Interface.Requests;
using Minimal.Auth.Api.Interface.Requests.Account;
using System.Reflection;

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

        public Account Create(CreateAccountRequest request)
        {
            var id = Guid.NewGuid();

            var password = _encoder.Encode(id, request.Password);

            var account = Account.Create(Profiles.Customer, request.Email, password);

            _context.Accounts.Add(account);
            _context.Users.Add(account.User);

            _context.SaveChanges();
            return account;
        }

        public bool Update(UpdateAccountRequest request) 
        {
            var account = 
                _context.Accounts
                .Where(account => account.Id == request.AccountId)
                .FirstOrDefault();

            if (account is null)
                throw new ArgumentException("No account can be found using this Id, please try again with a valid one.", nameof(request.AccountId));

            UpdatableFields updates = new()
            {
                Address = request.Address,
                ContactEmail = request.ContactEmail,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Profile = request.Profile,
                Username = request.Username
            };

            var updateType = updates.GetType();
            var updateProps = updateType.GetProperties().ToList();

            if (updateProps is not null && 
                updateProps.Count() > 0)
                updateProps.ToList()
                    .ForEach(prop =>
                    {
                        var property = prop.Name;
                        var value = prop.GetValue(updates);

                        var accountProperty = account!.GetType()!.GetProperty(property)!;
                        var currentValue = accountProperty.GetValue(account);

                        if (currentValue != value)
                            accountProperty.SetValue(account, value);
                    });

            _context.Accounts.Update(account);

            _context.SaveChanges();

            return true;
        }
    }
}
