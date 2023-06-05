namespace AlineTech.Linstagram.Api.Models.Entitys
{
    public class Perfil : Entity
    {
        public Guid UsuarioId { get; set; }
        public string? Foto { get; set; }
        public string? NomeUsuario { get; set; }
        public string? Descricao { get; set; }
        public int Publicacoes { get; set;}
        public int Seguidores { get; set; }
        public int Seguindo { get; set; }
        public int TipoPerfil { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual List<Publicacao>? Publicacaos { get; set; }
    }
}
