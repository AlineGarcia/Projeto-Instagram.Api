using AlineTech.Linstagram.Api.Infra.Context;
using AlineTech.Linstagram.Api.Interfaces.Repositories;
using AlineTech.Linstagram.Api.Models.Entitys;
using Microsoft.EntityFrameworkCore;

namespace AlineTech.Linstagram.Api.Infra.Repositories
{
    public class PublicacaoRepository : Repository<Publicacao>, IPublicacaoRepository
    {
        public PublicacaoRepository(LinstagramContext context) : base(context) { }

        public async Task<Publicacao> GetById(Guid id)
        {
            return await DbSet.Include(x => x.Perfil).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> ObterQuantidadePorPerfilId(Guid perfilId)
        {
            return await DbSet.CountAsync(_ => _.PerfilId == perfilId);
        }


    }
}
