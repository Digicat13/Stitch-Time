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
            NullChecked(result);
            return result;
        }

        public async Task Insert(TEntity Entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(Entity);
        }

        public TEntity Update(TEntity Entity)
        {
            var result = _dbContext.Set<TEntity>().Update(Entity);
            NullChecked(result.Entity);
            return result.Entity; 
        }

        public async Task Delete(TId Id)
        {
            var entityToDelete = await _dbContext.Set<TEntity>().FindAsync(Id);
            NullChecked(entityToDelete);
            _dbContext.Set<TEntity>().Remove(entityToDelete);
            
        }

        private bool NullChecked(TEntity entityToCheck)
        {
            if(entityToCheck != null)
            {
                return true;
            }
            else
            {
                throw new System.NullReferenceException();
            }
        }
    }
}
