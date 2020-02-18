using System;
using System.Collections.Generic;
using System.Text;

namespace StitchTime.Core.Dto
{
    public class TeamLeadInfoDto
    {
        public List<UserViewDto> Users { get; set; }
        public List<ReportDto> UsersReports { get; set; }
    }
}
