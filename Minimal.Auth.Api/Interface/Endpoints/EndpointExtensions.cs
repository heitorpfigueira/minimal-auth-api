namespace Minimal.Auth.Api.Interface.Endpoints
{
    public static class EndpointExtensions
    {
        public static IServiceCollection AddEndpoints(this IServiceCollection services, params Type[] scanMarkers)
        {
            var endpoints = new List<IEndpoint>();

            foreach (var marker in scanMarkers) 
            {
                endpoints.AddRange(
                    marker
                        .Assembly.ExportedTypes
                        .Where(type => typeof(IEndpoint).IsAssignableFrom(type) && 
                                       !(type.IsInterface || type.IsAbstract))
                        .Select(Activator.CreateInstance)
                        .Cast<IEndpoint>());
            }

            //foreach (var endpoint in endpoints)
            //{
            //    endpoint.DefineDependencies(services);
            //}

            services.AddSingleton(endpoints as IReadOnlyCollection<IEndpoint>);

            return services;
        }

        public static WebApplication UseEndpoints(this WebApplication app)
        {
            var endpoints = app.Services
                               .GetRequiredService<
                                   IReadOnlyCollection<IEndpoint>>();

            foreach (var endpoint in endpoints)
            {
                endpoint.DefineEndpoints(app);
            }

            return app;
        }
    }
}
