using AlineTech.Linstagram.Api.Infra.Context;
using AlineTech.Linstagram.Api.Interfaces.Repositories;
using AlineTech.Linstagram.Api.Models.Entitys;

namespace AlineTech.Linstagram.Api.Infra.Repositories
{
    public class PerfilRepository : Repository<Perfil>, IPerfilRepository
    {
        public PerfilRepository(LinstagramContext context) : base(context) { }
    }
}
