using MinApi.EndpointDefinitions;
using MinApi.Models;
using MinApi.Repository.Pessoas;

namespace MinApi.Apis
{
    public class PessoaApi : IEndpointDefinitions
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/pessoas", async (PessoaRepository repository) =>
            {
                var result = await repository.ObterTodos();
                return Results.Ok(result);
            });

            app.MapPost("/pessoas", async (PessoaRepository repository, Pessoa pessoa) =>
            {
                var result = await repository.Adicionar(pessoa);
                return result;
            });
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddScoped<PessoaRepository>();
        }
    }
}