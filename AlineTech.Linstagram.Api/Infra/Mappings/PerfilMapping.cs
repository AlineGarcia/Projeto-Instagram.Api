using AlineTech.Linstagram.Api.Models.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlineTech.Linstagram.Api.Infra.Mappings
{
    public class PerfilMapping : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("Perfils");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataCadastro).HasColumnType("datetime");
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.HasOne(x => x.Usuario).WithMany(x => x.Perfils).HasForeignKey(x => x.UsuarioId);
            builder.Property(x => x.NomeUsuario).HasColumnType("varchar(80)");
            builder.Property(x => x.Foto).HasColumnType("varchar(max)");
            builder.Property(x => x.Descricao).HasColumnType("varchar(100)");
            builder.Property(x => x.Seguidores).HasColumnType("int");
            builder.Property(x => x.Seguindo).HasColumnType("int");
            builder.Property(x => x.Publicacoes).HasColumnType("int");
            builder.Property(x => x.TipoPerfil).HasColumnType("int");
            builder.HasMany(x => x.Publicacaos).WithOne(x => x.Perfil);
            builder.Property(x => x.Tema).HasColumnType("varchar(5)");
        }
    }
}
