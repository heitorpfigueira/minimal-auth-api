using Microsoft.AspNetCore.Mvc;
using Minimal.Auth.Api.Application.Contracts;
using Minimal.Auth.Api.Application.Services;
using Minimal.Auth.Api.Domain.Customer.Entities;
using Minimal.Auth.Api.Domain.Customer.Enums;
using Minimal.Auth.Api.Interface.Requests.Account;

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
            return service.Create(request);
        }

        internal Guid Delete() { return Guid.Empty; }

        internal bool Update(
            [FromServices] IAccountService service,
            UpdateAccountRequest request) 
        {
            return service.Update(request);
        }

        internal Account Get(
            [FromServices] IAccountService service) 
        { 
            return Account.Create(Profiles.Staff, "", ""); 
        }

        internal IEnumerable<Account> GetAll(
            [FromServices] IAccountService service) 
        { 
            return Enumerable.Empty<Account>(); 
        }
    }
}
