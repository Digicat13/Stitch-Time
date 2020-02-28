namespace StitchTime.Core.Dto
{
    public class AssignmentDto : IDto<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
