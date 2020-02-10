namespace StitchTime.Core.Dto
{
    public class PasswordDto : IDto<int>
    {
        public int Id { get; set; }

        public string Password { get; set; }

    }
}
