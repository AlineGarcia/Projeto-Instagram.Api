namespace AlineTech.Linstagram.Api.Models.Entitys
{
    public class Publicacao : Entity
    {
        public Guid PerfilId { get; set; }
        public byte[] FotoPublicacao { get; set; }
        public string? Legenda { get; set; }
        public bool Arquivar { get; set; }
        public virtual Perfil? Perfil { get; set; }
    }
}
