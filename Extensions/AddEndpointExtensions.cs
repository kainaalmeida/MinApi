using MinApi.EndpointDefinitions;

namespace MinApi.Extensions
{
    public static class AddEndpointExtensions
    {
        public static void AddEndpoints(this IServiceCollection services, params Type[] scanMarkers)
        {
            var endpointDefinitions = new List<IEndpointDefinitions>();
            foreach (var marker in scanMarkers)
            {
                endpointDefinitions.AddRange(
                    marker.Assembly.ExportedTypes
                        .Where(x => typeof(IEndpointDefinitions).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                        .Select(Activator.CreateInstance)
                        .Cast<IEndpointDefinitions>()
                );
            }

            foreach (var endpointDefinition in endpointDefinitions)
                endpointDefinition.DefineServices(services);

            services.AddSingleton(endpointDefinitions as IReadOnlyCollection<IEndpointDefinitions>);
        }

        public static void UseEndpoints(this WebApplication app)
        {
            var definitions = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinitions>>();

            foreach (var endpointDefinition in definitions)
                endpointDefinition.DefineEndpoints(app);
        }
    }
}