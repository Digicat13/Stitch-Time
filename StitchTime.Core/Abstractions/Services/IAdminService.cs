using StitchTime.Core.Dto;

namespace StitchTime.Core.Abstractions.Services
{
    public interface IAdminService
    {
        public void CreateRole(RoleDto roleDto);
    }
}
