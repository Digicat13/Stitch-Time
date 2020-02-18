using StitchTime.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StitchTime.Core.Abstractions.Services
{
    public interface IReportService
    {
        public List<ReportDto> GetAll();

        public Task<ReportDto> GetById(int Id);

        public Task<ReportDto> Insert(ReportDto reportDto);

        public ReportDto Update(ReportDto reportDto);

        public Task Delete(int Id);

        public ReportDto Notify(ReportDto reportDto);

        public ReportDto AcceptReport(ReportDto reportDto);

        public ReportDto DeclineReport(ReportDto reportDto);

        public ReportDto TrackStatus(ReportDto reportDto);

    }
}
