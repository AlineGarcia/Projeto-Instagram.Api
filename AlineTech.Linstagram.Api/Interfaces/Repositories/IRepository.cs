using System.Linq.Expressions;

namespace AlineTech.Linstagram.Api.Interfaces.Repositories
{
    public interface IRepository<TEntity>
    {
        Task Inserir(TEntity entity);
        Task Atualizar(TEntity entity);
        Task<bool> Deletar(Guid id);
        Task<TEntity> BuscarPorId(Guid id);
        Task<IEnumerable<TEntity>> ObterTodosAsync();
        Task<List<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> expression);
        Task<bool> SaveChangesAsync();
    }
}
