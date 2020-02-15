using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace StitchTime.Core.Entities
{
    public class User :  IdentityUser
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }

        public List<Project> ManageProjects { get; set; }

        public List<Team> LeadTeams { get; set; }

        public List<TeamMember> MemberTeams { get; set; }

        public List<Report> Reports { get; set; }

    }
}
