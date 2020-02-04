using StitchTime.Core.Abstractions.Repositories;

namespace StitchTime.Core.Abstractions
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }

        public IReportRepository ReportRepository { get; }

        public void Save();
    }
}
