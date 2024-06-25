using ApiCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCrud.Data.Configuration
{
    public class PostoConfig : IEntityTypeConfiguration<Posto>
    {
        public void Configure(EntityTypeBuilder<Posto> builder)
        {
            builder.ToTable("Postos");
            builder.HasKey(p => p.Codigo);
            builder.Property(p => p.Codigo).HasColumnName("Pst_Cod");
            builder.Property(p => p.Nome).HasColumnName("Pst_Nome").IsRequired().HasMaxLength(100);
            builder.Property(p => p.Endereco).HasColumnName("Pst_Endereco").IsRequired().HasMaxLength(200);
            builder.HasMany(p => p.Vacinas).WithOne(v => v.Posto).HasForeignKey(v => v.CodigoPosto).OnDelete(DeleteBehavior.Cascade);
        }
    }
}