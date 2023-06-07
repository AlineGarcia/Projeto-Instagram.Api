using AlineTech.Linstagram.Api.Models.Dtos;
using AlineTech.Linstagram.Api.Models.Entitys;

namespace AlineTech.Linstagram.Api.Interfaces.Services
{
    public interface IPerfilService
    {
        Task<(bool success, string message)> CadastrarPerfil(PerfilDto perfilDto);
        Task<(bool success, string message)> AtualizarPerfil(PerfilDto perfilDto);
        Task<(bool success, string message)> DeletarPerfil(Guid id);
        Task<(bool success, string message)> AlterarTemaPerfil(Guid perfilId);
        Task<List<Perfil>> ListarPerfilsUsuario(Guid UsuarioId);
        Task<Perfil> ObterPerfilUsuario(Guid PerfilId);
    }
}
