using ApiCrud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiCrud.Data.Configuration
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(l => l.Codigo);
            builder.Property(l => l.Nome).HasColumnName("Usu_Nome");
            builder.Property(l => l.Codigo).HasColumnName("Usu_Cod");
            builder.Property(l => l.Ativo).HasColumnName("Usu_Ativo");
            builder.Property(l => l.DataNascimento).HasColumnName("Usu_DataNascimento");
        }
    }
}
