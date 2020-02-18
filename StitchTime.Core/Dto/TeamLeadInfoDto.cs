using System;
using System.Collections.Generic;
using System.Text;

namespace StitchTime.Core.Dto
{
    public class TeamLeadInfoDto
    {
        public List<UserDto> Users { get; set; }
        public List<ReportDto> TeamLeadReports { get; set; }
        public List<ReportDto> UsersReports { get; set; }
    }
}
