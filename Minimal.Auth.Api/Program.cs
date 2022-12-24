using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Minimal.Auth.Api.Application.Contracts;
using Minimal.Auth.Api.Application.Services;
using Minimal.Auth.Api.Infrastructure;
using Minimal.Auth.Api.Interface.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddEndpoints(typeof(IEndpoint))
    .AddAuthorization(options =>
    {
        options.FallbackPolicy = 
            new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(
                    JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
    })
    .AddAuthentication(
        JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

services
    .AddDbContext<ApiDbContext>(options =>
        options.UseInMemoryDatabase(databaseName: "ApplicationLocalDb"));

services.AddScoped<IEncoderService, EncoderService>();
services.AddScoped<IAccountService, AccountService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
    app
       .UseSwagger()
       .UseSwaggerUI();

app
    .UseHttpsRedirection()
    .UseAuthentication()
    .UseAuthorization();

app.UseEndpoints();

app.Run();