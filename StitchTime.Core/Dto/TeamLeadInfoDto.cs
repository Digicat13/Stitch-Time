using System.Collections.Generic;

namespace StitchTime.Core.Dto
{
    public class TeamLeadInfoDto
    {
        public List<UserViewDto> Users { get; set; }

        public List<ReportDto> UsersReports { get; set; }

        public List<ProjectViewDto> Projects { get; set; }
    }
}
