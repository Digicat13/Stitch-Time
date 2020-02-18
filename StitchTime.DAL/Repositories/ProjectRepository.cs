using StitchTime.Core.Abstractions.Repositories;
using StitchTime.Core.Entities;

namespace StitchTime.DAL.Repositories
{
    public class ProjectRepository : BaseRepository<Project, int>, IProjectRepository
    {
        public ProjectRepository(StitchTimeApiContext context) : base(context)
        {
        }
    }
}
