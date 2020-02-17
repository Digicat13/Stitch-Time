using StitchTime.Core.Abstractions.Repositories;
using System.Threading.Tasks;

namespace StitchTime.Core.Abstractions
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }

        public IReportRepository ReportRepository { get; }

        public IProjectRepository ProjectRepository { get; }

        public ITeamMemberRepository TeamMemberRepository { get; }

        public ITeamRepository TeamRepository { get; }

        public IStatusRepository StatusRepository { get; }

        public IAssignmentRepository AssignmentRepository { get; }


        public void Save();
        public Task SaveAsync();
    }
}
