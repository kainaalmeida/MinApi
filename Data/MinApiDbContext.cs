using Microsoft.EntityFrameworkCore;
using MinApi.Models.Pessoa;

namespace MinApi.Data
{
    public class MinApiDbContext : DbContext
    {
        public MinApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}