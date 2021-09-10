using Microsoft.AspNetCore.Authorization;
using MinApi.EndpointDefinitions;
using MinApi.Models.Pessoa.InputModel;
using MinApi.Repository.Pessoas;
using MinApi.Services;

namespace MinApi.Apis
{
    public class AuthApi : IEndpointDefinitions
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapPost("/autenticar", [AllowAnonymous] async (PessoaRepository repository, PessoaInputModel pessoaInputModel) =>
            {
                if (pessoaInputModel is null)
                    return Results.BadRequest();

                var pessoa = await repository.Obter(pessoaInputModel.Email, pessoaInputModel.Senha);
                if (pessoa == null)
                    return Results.NotFound();

                var token = TokenService.BuildToken(app.Configuration.GetValue<string>("SecretKey"), pessoa);

                pessoa.LimparSenha();
                return Results.Ok(new { pessoa = pessoa, token = token });
            });
        }

        public void DefineServices(IServiceCollection services)
        {
        }
    }
}