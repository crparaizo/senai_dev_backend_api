using Microsoft.EntityFrameworkCore;
using Senai.InLock.CodeFirst.WebApi.Domains;

namespace Senai.InLock.CodeFirst.WebApi.Contexts
{
    public class InLockContext : DbContext
    {
        public DbSet<EstudioDomain> Estudios { get; set; }
        public DbSet<JogoDomain> Jogos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =.\\SqlExpress;Initial Catalog=InLock_CodeFirst;User=sa;Password=132");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
