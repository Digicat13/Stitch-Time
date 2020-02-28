using System.Collections.Generic;

namespace StitchTime.Core.Dto
{
    public class InfoByUserDto
    {
        public UserViewDto User { get; set; }

        public PositionDto Position { get; set; }

        public List<ProjectViewDto> Projects { get; set; } 

        public List<ReportDto> Reports { get; set; }

    }
}
