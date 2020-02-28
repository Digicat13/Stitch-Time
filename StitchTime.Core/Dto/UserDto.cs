using System.Collections.Generic;

namespace StitchTime.Core.Dto
{
    public class UserDto : IDto<string>
    {
        public string  Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int PositionId { get; set; }
    }
}
