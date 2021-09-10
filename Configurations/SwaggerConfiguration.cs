
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using MinApi.EndpointDefinitions;

namespace MinApi.Configurations
{
    public class SwaggerConfiguration : IEndpointDefinitions
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Coloque **_APENAS_** seu JWT Bearer token na caixa de texto abaixo!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
            });
        }
    }
}