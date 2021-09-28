using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinApi.Data;
using MinApi.Models.Pessoa;

namespace MinApi.Repository.Pessoas
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly MinApiDbContext _dbContext;
        public PessoaRepository(MinApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Pessoa> Adicionar(Pessoa pessoa)
        {
            await _dbContext.Pessoas.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();
            return pessoa;
        }

        public async Task<IList<Pessoa>> ObterTodos()
        {
            var pessoas = await _dbContext.Pessoas.ToListAsync();
            return pessoas;
        }

        public async Task<Pessoa> Obter(string email, string senha)
        {
            var pessoa = await _dbContext.Pessoas.FirstOrDefaultAsync(x => x.Email.ToUpper() == email.ToUpper() && x.Senha == senha);
            return pessoa;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}