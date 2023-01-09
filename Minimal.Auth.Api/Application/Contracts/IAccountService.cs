using Minimal.Auth.Api.Domain.Customer.Entities;
using Minimal.Auth.Api.Interface.Requests;
using Minimal.Auth.Api.Interface.Requests.Account;

namespace Minimal.Auth.Api.Application.Contracts
{
    public interface IAccountService
    {
        public Account Create(CreateAccountRequest request);
        public bool Update(UpdateAccountRequest request);
    }
}
