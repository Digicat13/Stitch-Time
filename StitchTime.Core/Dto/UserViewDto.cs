namespace StitchTime.Core.Dto
{
    public class UserViewDto : IDto<string>
    {
        public string Id { get; set; }

        public int PositionId { get; set; }

    }
}
