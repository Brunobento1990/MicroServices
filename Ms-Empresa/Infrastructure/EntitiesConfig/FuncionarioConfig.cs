using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfig
{
    public class FuncionarioConfig : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Nome).HasMaxLength(250).IsRequired();
            builder.Property(e => e.Cpf).HasMaxLength(20).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(250).IsRequired();
            builder.Property(e => e.Senha).HasMaxLength(100).IsRequired();

            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.Funcionarios)
                .HasForeignKey(x => x.EmpresaId);
        }
    }
}
