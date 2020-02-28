namespace StitchTime.Core.Dto
{
    public class UserViewDto : IDto<string>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Email { get; set; }
    }
}
