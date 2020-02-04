namespace StitchTime.Core.Dto
{
    public class PositionDto : IDto<int>
    {
        public int Id { get; set; }

        public string PositionName { get; set; }


    }
}
