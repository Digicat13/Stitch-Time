using StitchTime.Core.Abstractions;
using StitchTime.Core.Abstractions.Repositories;
using StitchTime.DAL.Repositories;

namespace StitchTime.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StitchTimeApiContext _dbContext;

        private UserRepository _userRepository;
        private ReportRepository _reportRepository;
        private ProjectRepository _projectRepository;
        private TeamMemberRepository _teamMemberRepository;
        private TeamRepository _teamRepository;

        public UnitOfWork(StitchTimeApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_dbContext);

        public IReportRepository ReportRepository => _reportRepository ??= new ReportRepository(_dbContext);

        public IProjectRepository ProjectRepository => _projectRepository ??= new ProjectRepository(_dbContext);

        public ITeamMemberRepository TeamMemberRepository => _teamMemberRepository ??= new TeamMemberRepository(_dbContext);

        public ITeamRepository TeamRepository => _teamRepository ??= new TeamRepository(_dbContext);


        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
