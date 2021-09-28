using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MinApi.Models.Pessoa;

namespace MinApi.Repository.Pessoas
{
    public interface IPessoaRepository : IDisposable
    {
        Task<Pessoa> Adicionar(Pessoa pessoa);
        Task<IList<Pessoa>> ObterTodos();
        Task<Pessoa> Obter(string email, string senha);
    }
}