using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MinApi.EndpointDefinitions
{
    public interface IEndpointDefinitions
    {
        void DefineServices(IServiceCollection services);
        void DefineEndpoints(WebApplication app);
    }
}