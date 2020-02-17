namespace StitchTime.Core.Entities
{
    public class TeamMember : IEntity<int>
    {
        public int Id { get; set; }

        public string TeamId { get; set; }

        public Team Team { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
