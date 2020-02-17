namespace StitchTime.Core.Dto
{
    public class TeamDto : IDto<int>
    {
        public int Id { get; set; }

        public string TeamLeadId { get; set; }

        public int ProjectId { get; set; }
    }
}
