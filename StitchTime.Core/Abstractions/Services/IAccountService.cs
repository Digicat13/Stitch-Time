using StitchTime.Core.Dto;
using System.Threading.Tasks;

namespace StitchTime.Core.Abstractions.Services
{
    public interface IAccountService
    {
        public Task<UserLoginDto> SignUp(UserDto dto);

        public Task<UserLoginDto> SignIn(UserDto dto);

        public Task Logout(string Id);
    }
}
