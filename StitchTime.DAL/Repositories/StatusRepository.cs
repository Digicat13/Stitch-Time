using StitchTime.Core.Abstractions.Repositories;
using StitchTime.Core.Entities;

namespace StitchTime.DAL.Repositories
{
    class StatusRepository : BaseRepository<Status, int>, IStatusRepository
    {
        public StatusRepository(StitchTimeApiContext context) : base(context)
        {
        }
    }
}
