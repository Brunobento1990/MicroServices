using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfig
{
    public class EmpresaConfig : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RazaoSocial).HasMaxLength(250).IsRequired();
            builder.Property(x => x.NomeFantasia).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Cnpj).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Setor).HasMaxLength(100);
            builder.Property(x => x.InscricaoEstadual).HasMaxLength(25);
            builder.Property(x => x.InscricaoMunicipal).HasMaxLength(25);
            builder.Property(x => x.PagamentoEmDia).IsRequired();
            builder.Property(x => x.DataDeCadastro).IsRequired().HasColumnType("datetime");

        }
    }
}
