namespace AlineTech.Linstagram.Api.Models.Entitys
{
    public class Usuario : Entity
    {
        public string? Email { get; set; }
        public string? NomeCompleto { get; set; }
        public string? Senha { get; set; }
        public bool Ativo { get; set; }
        public virtual List<Perfil>? Perfils { get; set; }
    }
}
