using System.Threading.Tasks;
using StitchTime.Core.Dto;

namespace StitchTime.Core.Abstractions.Services
{
    public interface IUserService
    {
        public PmProjectsInfoDto GetPmProjectsInfo(string Id);
        public InfoByUserDto GetInfoById(string Id);
        public PmReportsInfoDto GetPmReportsInfo(string Id);
        public TeamLeadInfoDto GetTeamLeadInfo(string Id);
    }
}
