using AlineTech.Linstagram.Api.Models.Entitys;

namespace AlineTech.Linstagram.Api.Models.Dtos
{
    public class PublicacaoDto
    {
        public Guid PerfilId { get; set; }
        public string? Foto { get; set; }
        public string? Legenda { get; set; }
        public bool Arquivar { get; set; }

    }
}
