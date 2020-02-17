using System.Collections.Generic;

namespace StitchTime.Core.Dto
{
    public class PmProjectsInfoDto
    {
        public List<ProjectViewDto> Projects { get; set; }
        public List<UserViewDto> Users { get; set; }
    }
}
