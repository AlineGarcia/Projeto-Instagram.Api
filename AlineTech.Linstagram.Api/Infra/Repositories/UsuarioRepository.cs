using AlineTech.Linstagram.Api.Infra.Context;
using AlineTech.Linstagram.Api.Interfaces.Repositories;
using AlineTech.Linstagram.Api.Models.Entitys;

namespace AlineTech.Linstagram.Api.Infra.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(LinstagramContext context) : base(context) { }
    }
}
