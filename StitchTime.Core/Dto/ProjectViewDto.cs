namespace StitchTime.Core.Dto
{
    public class ProjectViewDto : IDto<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
