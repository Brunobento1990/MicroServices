using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfig
{
    public class EnderecoEmpresaConfig : IEntityTypeConfiguration<EnderecoEmpresa>
    {
        public void Configure(EntityTypeBuilder<EnderecoEmpresa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Cep).HasMaxLength(9).IsRequired();
            builder.Property(x => x.Rua).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Bairro).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Cidade).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Estado).HasMaxLength(2).IsRequired();
            builder.Property(x => x.Numero).HasMaxLength(10).IsRequired();

            builder.HasOne(e => e.Empresa)
                .WithOne(e => e.EnderecoEmpresa)
                .HasForeignKey<EnderecoEmpresa>(e => e.EmpresaId).IsRequired(); 
        }
    }
}
