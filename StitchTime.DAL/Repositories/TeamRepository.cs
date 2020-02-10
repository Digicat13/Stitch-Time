using StitchTime.Core.Abstractions.Repositories;
using StitchTime.Core.Entities;

namespace StitchTime.DAL.Repositories
{
    class TeamRepository : BaseRepository<Team, int>, ITeamRepository
    {
        public TeamRepository(StitchTimeApiContext context) : base(context)
        {
        }
    }
}
