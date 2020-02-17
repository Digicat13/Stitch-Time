using System.Collections.Generic;

namespace StitchTime.Core.Dto
{
    public class ProjectDto : IDto<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbrevation { get; set; }

        public string Description { get; set; }

        public double InitialEffrort { get; set; }

        public double InitialRisk { get; set; }

        public int ProjectManagerId { get; set; }

        public int TeamLeadId { get; set; }

        public List<UserViewDto> TeamMates { get; set; }
    }
}
