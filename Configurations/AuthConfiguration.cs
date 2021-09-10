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