using MinApi.Models;

namespace MinApi.Repository.Pessoas
{
    public interface IPessoaRepository : IDisposable
    {
        Task<Pessoa> Adicionar(Pessoa pessoa);
        Task<IList<Pessoa>> ObterTodos();
    }
}