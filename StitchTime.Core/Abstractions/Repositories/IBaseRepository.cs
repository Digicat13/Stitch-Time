using StitchTime.Core.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace StitchTime.Core.Abstractions.Repositories
{
    public interface IBaseRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        public IQueryable<TEntity> GetAll();

        public  Task<TEntity> GetById(TId Id);

        public  Task Insert(TEntity Entity);

        public TEntity Update(TEntity Entity);

        public  Task Delete(TId Id);
    }
}
