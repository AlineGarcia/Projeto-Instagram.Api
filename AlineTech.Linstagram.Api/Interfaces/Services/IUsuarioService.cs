using AlineTech.Linstagram.Api.Models.Adapters.Requests;
using AlineTech.Linstagram.Api.Models.Adapters.Responses;
using AlineTech.Linstagram.Api.Models.Dtos;
using AlineTech.Linstagram.Api.Models.Entitys;

namespace AlineTech.Linstagram.Api.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<(bool success, string message)> CadastrarUsuario(UsuarioDto usuario);
        Task<(UsuarioResponse? usuario, string message)> LogarUsuario(string email, string senha);
        Task<(bool success, string message)> AtualizarUsuario(AtualizarUsuarioRequest atualizar);
    }
}
