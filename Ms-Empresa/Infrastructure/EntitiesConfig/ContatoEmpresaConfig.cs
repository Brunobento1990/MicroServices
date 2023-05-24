using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfig
{
    public class ContatoEmpresaConfig : IEntityTypeConfiguration<ContatoEmpresa>
    {
        public void Configure(EntityTypeBuilder<ContatoEmpresa> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Telefone).HasMaxLength(20);
            builder.Property(e => e.Ddd).HasMaxLength(2);
            builder.Property(e => e.Email).HasMaxLength(250);

            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.ContatosEmpresa)
                .HasForeignKey(x => x.EmpresaId);
        }
    }
}
