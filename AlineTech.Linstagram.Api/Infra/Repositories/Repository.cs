using AlineTech.Linstagram.Api.Infra.Context;
using AlineTech.Linstagram.Api.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AlineTech.Linstagram.Api.Infra.Repositories
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly LinstagramContext _context;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(LinstagramContext context)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task Atualizar(TEntity entity)
        {
            await Task.FromResult(DbSet.Update(entity));
        }

        public async Task<TEntity> BuscarPorId(Guid id)
        {
            var entity = await DbSet.FindAsync(id);
            return entity;
        }

        public async Task<bool> Deletar(Guid id)
        {
            var entity = await DbSet.FindAsync(id);

            if (entity is null) return false;

            DbSet.Remove(entity);

            return true;
        }

        public async Task Inserir(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> ObterTodosAsync()
        {
            var entity = await DbSet.ToListAsync();
            return entity;
        }

        public async Task<List<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await DbSet.Where(expression).ToListAsync();
            return entity;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result != 0;
        }

        public void CloseConnection()
        {
            _context.Database.CloseConnection();
        }

        public void Dispose()
        {
            //CloseConnection();
            _context.Dispose();
            GC.SuppressFinalize(this);  
        }
    }
}
