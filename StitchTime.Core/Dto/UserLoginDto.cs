namespace StitchTime.Core.Dto
{
    public class UserLoginDto : IDto<string>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Email { get; set; }

        public int PositionId { get; set; }
    }
}
