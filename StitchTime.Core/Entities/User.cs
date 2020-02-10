using System.Collections.Generic;

namespace StitchTime.Core.Entities
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Email { get; set; }

        public int PasswordId { get; set; }

        public Password Password { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }

        public List<Project> ManageProjects { get; set; }

        public List<Team> LeadTeams { get; set; }

        public List<TeamMember> MemberTeams { get; set; }

        public List<Report> Reports { get; set; }

    }
}
