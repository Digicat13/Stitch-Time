using System.Threading.Tasks;
using StitchTime.Core.Dto;

namespace StitchTime.Core.Abstractions.Services
{
    public interface IUserService
    {
        public Task<InfoByUserDto> GetInfoById(string Id);
    }
}
