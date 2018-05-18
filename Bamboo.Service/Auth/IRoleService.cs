using Bamboo.Core.Models.Auth;
using Bamboo.Data.EF;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bamboo.Service.Auth
{
    public interface IRoleService
    {
        Task<bool> CheckRoleExistsAsync(string roleName);
        Task<IEnumerable<RoleModel>> GetAll();
        Task CreateAsync(CreateRoleModel role);
        Task UpdateAsync(RoleModel role);
        Task DeleteAsync(RoleModel role);
        Task<IEnumerable<ClaimModel>> GetClaims();
        Task UpdateClaimsAsync(string roleName, List<ClaimModel> claims);
    }
}
