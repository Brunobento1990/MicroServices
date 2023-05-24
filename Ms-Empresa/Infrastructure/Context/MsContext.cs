using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class MsContext : DbContext
    {
        public MsContext(DbContextOptions<MsContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<ContatoEmpresa> ContatosEmpresas { get; set; }
        public DbSet<EnderecoEmpresa> EnderecosEmpresas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MsContext).Assembly);
        }
    }
}
