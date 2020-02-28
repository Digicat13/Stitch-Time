using FluentValidation;
using StitchTime.Core.Dto;

namespace StitchTime.Core.Validators
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
        }
    }
}
