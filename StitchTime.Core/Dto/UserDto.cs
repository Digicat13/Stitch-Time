using System.Collections.Generic;

namespace StitchTime.Core.Dto
{
    public class UserDto : IDto<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string Email { get; set; }

        public int PasswordId { get; set; }

        public int PositionId { get; set; }
    }
}
