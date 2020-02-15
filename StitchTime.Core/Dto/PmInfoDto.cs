using System;
using System.Collections.Generic;
using System.Text;

namespace StitchTime.Core.Dto
{
    public class PmInfoDto
    {
        public UserViewDto User { get; set; }
        public List<ProjectViewDto> Projects { get; set; }
        public List<ReportDto> TeamMembersReports { get; set; }
        public List<UserViewDto> Developers { get; set; }
        //new dto for creating include all devs and all projects related to pm
    }
}
