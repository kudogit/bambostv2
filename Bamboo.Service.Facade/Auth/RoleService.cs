using Bamboo.Core.Constants;
using Bamboo.Core.Models.Auth;
using Bamboo.Data.EF;
using Bamboo.DependencyInjection.Attributes;
using Bamboo.Service.Auth;
using Bamboo.Util.Exceptions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bamboo.Service.Facade.Auth
{
    [ScopeDependency(ServiceType = typeof(IRoleService))]
    public class RoleService : IRoleService
    {
        private RoleManager<RoleEntity> _roleManager;

        public RoleService(RoleManager<RoleEntity> roleManager)
        {
            _roleManager = roleManager;
        }

        public Task<bool> CheckRoleExistsAsync(string roleName)
        {
            return _roleManager.RoleExistsAsync(roleName);
        }

        public Task<IEnumerable<RoleModel>> GetAll()
        {
            return Task.FromResult(_roleManager.Roles.Select(x => new RoleModel{ 
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
                }).AsEnumerable());
        }

        public async Task CreateAsync(CreateRoleModel role)
        {
            var isExisted = await _roleManager.RoleExistsAsync(role.Name).ConfigureAwait(true);
            if (isExisted)
                throw new BambooException(Core.Constants.ErrorCode.RoleExisted);

            var entity = new RoleEntity
            {
                Name = role.Name,
                Description = role.Description
            };

            var result = await _roleManager.CreateAsync(entity).ConfigureAwait(true);

            if(!result.Succeeded)
                throw new Exception(result.Errors.First().Description);
        }

        public async Task DeleteAsync(RoleModel role)
        {
            var entity = await _roleManager.FindByNameAsync(role.Name).ConfigureAwait(true);
            await _roleManager.DeleteAsync(entity).ConfigureAwait(true);
        }

        public async Task UpdateAsync(RoleModel role)
        {
            //  check exist role name
            var any = _roleManager.Roles.Any(x => x.Name == role.Name && x.Id != role.Id);
            if (any) 
                throw new BambooException(Core.Constants.ErrorCode.RoleExisted);

            var entity = _roleManager.Roles.SingleOrDefault(x => x.Id == role.Id);

            entity.Name = role.Name;
            entity.Description = role.Description;
            await _roleManager.UpdateAsync(entity);
        }

        public Task<IEnumerable<ClaimModel>> GetClaims()
        {
            return Task.FromResult(ClaimsDefined.Claims.AsEnumerable());
        }

        public async Task UpdateClaimsAsync(string roleName, List<ClaimModel> claims)
        {
            var roleEntity = await _roleManager.FindByNameAsync(roleName);
            if (roleEntity == null)
                throw new Exception("Role is not existed");

            var claimsExisted = await _roleManager.GetClaimsAsync(roleEntity);

            foreach(var claim in claims)
            {
                    // If selected, add
                    if (claim.IsSelected)
                    {
                        if(!claimsExisted.Any(x => x.Type == claim.Type && x.Value == x.Value))
                            await _roleManager.AddClaimAsync(roleEntity, new Claim(claim.Type, claim.Value));
                    }
                    //  Remove
                    else
                    {
                        if(claimsExisted.Any(x => x.Type == claim.Type && x.Value == claim.Value))
                            await _roleManager.RemoveClaimAsync(roleEntity, new Claim(claim.Type, claim.Value));
                    }
            }
        }

        
    }
}
