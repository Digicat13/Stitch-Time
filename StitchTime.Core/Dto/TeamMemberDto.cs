namespace StitchTime.Core.Dto
{
    public class TeamMemberDto : IDto<int>
    {
        public int Id { get; set; }

        public string TeamId { get; set; }

        public string UserId { get; set; }

    }
}
