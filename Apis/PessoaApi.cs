using Microsoft.AspNetCore.Authorization;
using MinApi.EndpointDefinitions;
using MinApi.Models.Pessoa;
using MinApi.Models.Pessoa.InputModel;
using MinApi.Repository.Pessoas;
using MinApi.Services;

namespace MinApi.Apis
{
    public class PessoaApi : IEndpointDefinitions
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/pessoas", [Authorize(Roles = "manager")] async (PessoaRepository repository) =>
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