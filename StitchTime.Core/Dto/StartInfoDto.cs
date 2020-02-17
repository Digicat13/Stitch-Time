using System.Collections.Generic;

namespace StitchTime.Core.Dto
{
    public class StartInfoDto
    {
        public List<StatusDto> statusDto { get; set; }

        public List<AssignmentDto> assignmentDto { get; set; }
    }
}
