using Minimal.Auth.Api.Domain.Customer.Entities;
using Minimal.Auth.Api.Interface.Requests;

namespace Minimal.Auth.Api.Application.Contracts
{
    public interface IAccountService
    {
        public Account Create(string Email, string Password);
    }
}
