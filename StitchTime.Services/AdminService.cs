using Microsoft.AspNetCore.Identity;
using StitchTime.Core.Abstractions.Services;
using StitchTime.Core.Dto;
using System;

namespace StitchTime.Services
{
    public class AdminService : IAdminService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminService(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }

        public async void CreateRole(RoleDto roleDto)
        {
            IdentityRole identityRole = new IdentityRole()
            {
                Name = roleDto.RoleName,
                NormalizedName = roleDto.RoleName.ToUpper()                
            };

            var result = await _roleManager.CreateAsync(identityRole);

            if (!result.Succeeded)
            {
                throw new Exception();
            }
        }
    }
}
