using Microsoft.AspNetCore.Authorization;
using MinApi.EndpointDefinitions;

namespace MinApi.Apis
{
    public class DesenvolvedorApi : IEndpointDefinitions
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/dev", (Func<string>)([Authorize(Roles = "developer")]() => "Developer"));
        }

        public void DefineServices(IServiceCollection services)
        {

        }
    }
}