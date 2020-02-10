namespace StitchTime.Core.Dto
{
    public class ProjectDto : IDto<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProjectManagerId { get; set; }
    }
}
