using System.Threading.Tasks;
using StitchTime.Core.Dto;

namespace StitchTime.Core.Abstractions.Services
{
    public interface IUserService
    {
        public PmProjectsInfo GetPmProjectsInfo(string Id);
        public InfoByUserDto GetInfoById(string Id);
    }
}
