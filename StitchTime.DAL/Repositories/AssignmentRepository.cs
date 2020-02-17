using StitchTime.Core.Abstractions.Repositories;
using StitchTime.Core.Entities;

namespace StitchTime.DAL.Repositories
{
    class AssignmentRepository : BaseRepository<Assignment, int>, IAssignmentRepository
    {
        public AssignmentRepository(StitchTimeApiContext context) : base(context)
        {
        }
    }
}
