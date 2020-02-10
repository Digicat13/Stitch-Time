using System.Collections.Generic;

namespace StitchTime.Core.Entities
{
    public class Team : IEntity<int>
    {
        public int Id { get; set; }

        public int TeamLeadId { get; set; }

        public User TeamLead { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public List<TeamMember> TeamMembers { get; set; }
    }
}
