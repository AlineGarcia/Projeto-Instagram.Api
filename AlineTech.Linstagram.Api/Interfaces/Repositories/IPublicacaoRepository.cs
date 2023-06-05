using AlineTech.Linstagram.Api.Models.Entitys;

namespace AlineTech.Linstagram.Api.Interfaces.Repositories
{
    public interface IPublicacaoRepository : IRepository<Publicacao>
    {
        Task<int> ObterQuantidadePorPerfilId(Guid perfilId);
        Task<Publicacao> GetById(Guid id);
    }
}
