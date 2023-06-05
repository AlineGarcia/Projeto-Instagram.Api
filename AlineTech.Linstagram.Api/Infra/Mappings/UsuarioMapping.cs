using AlineTech.Linstagram.Api.Models.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlineTech.Linstagram.Api.Infra.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataCadastro).HasColumnType("datetime");
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.Property(x => x.NomeCompleto).HasColumnType("varchar(100)");
            builder.Property(x => x.Email).HasColumnType("varchar(100)");
            builder.Property(x => x.Senha).HasColumnType("varchar(30)");
            builder.Property(x => x.Ativo).HasColumnType("bit");
            builder.HasMany(x => x.Perfils).WithOne(x => x.Usuario);
        }
    }
}
