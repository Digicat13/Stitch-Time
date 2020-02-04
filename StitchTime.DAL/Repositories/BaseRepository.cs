using Microsoft.EntityFrameworkCore;
using StitchTime.Core.Abstractions.Repositories;
using StitchTime.Core.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace StitchTime.DAL.Repositories
{
    public abstract class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        private readonly StitchTimeApiContext _dbContext;
        public BaseRepository(StitchTimeApiContext context)
        {
            _dbContext = context;
        }
        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(TId id)
        {
            var result = await _dbContext.Set<TEntity>().FindAsync(id);
            return result;
        }

        public async Task Insert(TEntity Entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(Entity);
        }

        public TEntity Update(TEntity Entity)
        {
            var result = _dbContext.Set<TEntity>().Update(Entity);
            return result.Entity; 
        }

        public async Task Delete(TId Id)
        {
            var entityToDelete = await _dbContext.Set<TEntity>().FindAsync(Id);
            new Task(() => _dbContext.Set<TEntity>().Remove(entityToDelete)).Start() ;
        }
    }
}
