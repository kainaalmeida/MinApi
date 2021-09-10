using MinApi.Models.Pessoa;

namespace MinApi.Services
{
    public interface ITokenService
    {
        string BuildToken(Pessoa pessoa);
    }
}