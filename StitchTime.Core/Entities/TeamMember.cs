namespace StitchTime.Core.Entities
{
    public class TeamMember : IEntity<int>
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public int MemberId { get; set; }

        public User Member { get; set; }
    }
}
