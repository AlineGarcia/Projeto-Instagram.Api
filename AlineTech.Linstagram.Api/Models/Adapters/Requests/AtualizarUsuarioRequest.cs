namespace AlineTech.Linstagram.Api.Models.Adapters.Requests
{
    public class AtualizarUsuarioRequest
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
    }
}
