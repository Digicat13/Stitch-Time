using System;
using System.Collections.Generic;
using System.Text;

namespace StitchTime.Core.Dto
{
    public class InfoByUserDto
    {
        public UserViewDto User { get; set; }

        public List<ProjectViewDto> Projects { get; set; }

        public List<AssignmentDto> Assignments { get; set; }

        public List<ReportDto> Reports { get; set; }

        public List<StatusDto> Statuses { get; set; }
    }
}
