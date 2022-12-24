namespace Minimal.Auth.Api.Interface.Endpoints
{
    public interface IEndpoint
    {
        public void DefineEndpoints(WebApplication app);
        public void DefineDependencies(IServiceCollection services);
    }
}
