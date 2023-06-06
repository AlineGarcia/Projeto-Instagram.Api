using AlineTech.Linstagram.Api.Models.Adapters.Requests;
using AlineTech.Linstagram.Api.Models.Adapters.Responses;
using AlineTech.Linstagram.Api.Models.Dtos;
using AlineTech.Linstagram.Api.Models.Entitys;

namespace AlineTech.Linstagram.Api.Interfaces.Services
{
    public interface IPublicacaoService
    {
        Task<(bool success, string message)> CadastrarPublicacao(PublicacaoDto publicacaoDto);
        Task<(bool success, string message)> AtualizarPublicacao(PublicacaoDto publicacaoDto);
        Task<(bool success, string message)> DeletarPublicacao(Guid id);
        Task<List<Publicacao>> ListarPublicacaoUsuario(Guid UsuarioId);
        Task<List<Publicacao>> ListarPublicacaoFeed(Guid perfilId);
    }
}
