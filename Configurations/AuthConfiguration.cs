using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MinApi.EndpointDefinitions;

namespace MinApi.Configurations
{
    public class AuthConfiguration : IEndpointDefinitions
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }

        public void DefineServices(IServiceCollection services)
        {

        }
    }
}