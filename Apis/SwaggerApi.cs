using MinApi.EndpointDefinitions;

namespace MinApi.Apis
{
    public class SwaggerApi : IEndpointDefinitions
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddSwaggerGen();
        }
    }
}