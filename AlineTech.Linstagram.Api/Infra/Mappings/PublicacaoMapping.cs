using AlineTech.Linstagram.Api.Models.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlineTech.Linstagram.Api.Infra.Mappings
{
    public class PublicacaoMapping : IEntityTypeConfiguration<Publicacao>
    {
        public void Configure(EntityTypeBuilder<Publicacao> builder)
        {
            builder.ToTable("Publicacaos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DataCadastro).HasColumnType("datetime");
            builder.Property(x => x.DataAtualizacao).HasColumnType("datetime");
            builder.HasOne(x => x.Perfil).WithMany(x => x.Publicacaos).HasForeignKey(x => x.PerfilId);
            builder.Property(x => x.FotoPublicacao).HasColumnType("varbinary(max)");
            builder.Property(x => x.Legenda).HasColumnType("varchar(100)");
            builder.Property(x => x.Arquivar).HasColumnType("bit");
        }
    }
}
