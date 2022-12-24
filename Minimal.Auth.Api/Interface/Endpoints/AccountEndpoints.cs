using Microsoft.AspNetCore.Mvc;
using Minimal.Auth.Api.Application.Contracts;
using Minimal.Auth.Api.Application.Services;
using Minimal.Auth.Api.Domain.Customer.Entities;
using Minimal.Auth.Api.Domain.Customer.Enums;
using Minimal.Auth.Api.Interface.Requests;

namespace Minimal.Auth.Api.Interface.Endpoints
{
    public class AccountEndpoints : IEndpoint
    {
        public void DefineDependencies(IServiceCollection services)
        {
            services.AddSingleton<IAccountService, AccountService>();
        }

        public void DefineEndpoints(WebApplication app)
        {
            app.MapPost("/account", Create);
            app.MapDelete("/account", Delete);
            app.MapPut("/account", Update);
            app.MapGet("/account", Get);
            app.MapGet("/account/all", GetAll);
        }



        internal Account Create(
            [FromServices] IAccountService service, 
            CreateAccountRequest request) 
        { 
            return service.Create(request.Email, request.Password);
        }

        internal Guid Delete() { return Guid.Empty; }

        internal bool Update() { return false; }

        internal Account Get() { return Account.Create(AccountTypes.Staff, "", ""); }

        internal IEnumerable<Account> GetAll() { return Enumerable.Empty<Account>(); }
    }
}
