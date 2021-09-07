namespace MinApi.EndpointDefinitions
{
    public interface IEndpointDefinitions
    {
        void DefineServices(IServiceCollection services);
        void DefineEndpoints(WebApplication app);
    }
}