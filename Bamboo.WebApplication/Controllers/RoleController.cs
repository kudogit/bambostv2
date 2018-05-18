using System.Collections.Generic;
using System.Threading.Tasks;
using Bamboo.Core.Constants;
using Bamboo.Core.Models.Auth;
using Bamboo.Service.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bamboo.WebApplication.Controllers
{
    [Route(Endpoint)]
    public class RoleController : ApiController
    {
        public const string Endpoint = AreaName + "/role";

        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [Route("get-claims")]
        [HttpGet]
        public IActionResult GetClaims()
        {
            return Ok(_roleService.GetClaims());
        }

        [Route("get-all")]
        [Authorize(Policy = ClaimsConst.ClaimsValues.ViewRole)]
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _roleService.GetAll());
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleModel model)
        {
            await _roleService.CreateAsync(model).ConfigureAwait(true);
            return NoContent();
        }

        [Route("update-claims/{roleName}")]
        [HttpPost]
        public async Task<IActionResult> UpdateClaims([FromRoute] string roleName, [FromBody] List<ClaimModel> claims)
        {
            await _roleService.UpdateClaimsAsync(roleName, claims).ConfigureAwait(true);
            return Ok();
        }
    }
}