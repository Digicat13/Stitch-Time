using System.Collections.Generic;

namespace StitchTime.Core.Dto
{
    public class PmReportsInfoDto
    {
        public List<ProjectViewDto> Projects { get; set; }
        public List<UserViewDto> PmDevelopers { get; set; }
        public List<ReportDto> DevelopersReports { get; set; }
    }
}
