using ApiCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCrud.Data.Configuration
{
    public class VacinaConfig : IEntityTypeConfiguration<Vacina>
    {
        public void Configure(EntityTypeBuilder<Vacina> builder)
        {
            builder.ToTable("Vacinas");
            builder.HasKey(v => v.Codigo);
            builder.Property(v => v.Codigo).HasColumnName("Vac_Cod");
            builder.Property(v => v.CodigoPosto).HasColumnName("Vac_Pst_Cod").IsRequired();
            builder.Property(v => v.Quantidade).HasColumnName("Vac_Quantidade").IsRequired();
            builder.Property(v => v.DataValidade).HasColumnName("Vac_DataValidade").IsRequired();
            builder.Property(v => v.Lote).HasColumnName("Vac_Lote").IsRequired().HasMaxLength(50);
            builder.Property(v => v.Nome).HasColumnName("Vac_Nome").IsRequired().HasMaxLength(100);
            builder.Property(v => v.Fabricante).HasColumnName("Vac_Fabricante").IsRequired().HasMaxLength(100);
            builder.HasOne(v => v.Posto).WithMany(p => p.Vacinas).HasForeignKey(v => v.CodigoPosto).OnDelete(DeleteBehavior.Cascade);
        }
    }
}