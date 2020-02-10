using StitchTime.Core.Abstractions.Repositories;
using System.Threading.Tasks;

namespace StitchTime.Core.Abstractions
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }

        public IReportRepository ReportRepository { get; }

        public void Save();
        public Task SaveAsync();
    }
}
