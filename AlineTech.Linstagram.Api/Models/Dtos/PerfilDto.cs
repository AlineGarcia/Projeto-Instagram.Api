using AlineTech.Linstagram.Api.Models.Entitys;

namespace AlineTech.Linstagram.Api.Models.Dtos
{
    public class PerfilDto
    {
        public Guid? UsuarioId { get; set; }
        public string? FotoPerfil { get; set; }
        public string? NomeUsuario { get; set; }
        public string? Descricao { get; set; }
        public int? TipoPerfil { get; set; }
    }
}
