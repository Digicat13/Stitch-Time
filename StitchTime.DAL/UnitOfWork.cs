using StitchTime.Core.Abstractions;
using StitchTime.Core.Abstractions.Repositories;
using StitchTime.DAL.Repositories;
using System.Threading.Tasks;

namespace StitchTime.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StitchTimeApiContext _dbContext;

        private UserRepository _userRepository;
        private ReportRepository _reportRepository;

        public UnitOfWork(StitchTimeApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_dbContext);

        public IReportRepository ReportRepository => _reportRepository ??= new ReportRepository(_dbContext);

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
