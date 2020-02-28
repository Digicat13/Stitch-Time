using StitchTime.Core.Abstractions.Repositories;
using StitchTime.Core.Entities;

namespace StitchTime.DAL.Repositories
{
    public class ReportRepository : BaseRepository<Report, int>, IReportRepository
    {
        public ReportRepository(StitchTimeApiContext context) : base(context)
        {
        }
    }
}
