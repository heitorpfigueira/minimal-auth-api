using Minimal.Auth.Api.Domain.Customer.Enums;

namespace Minimal.Auth.Api.Interface.Requests.Account;

public record UpdateAccountRequest(Guid AccountId, string ContactEmail, string Name, string Address, string PhoneNumber, string Username, Profiles Profile);
