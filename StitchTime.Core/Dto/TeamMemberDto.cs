namespace StitchTime.Core.Dto
{
    public class TeamMemberDto : IDto<int>
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public int UserId { get; set; }

    }
}
