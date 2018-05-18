using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bamboo.Core.Models;
using Bamboo.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bamboo.WebApplication.Controllers
{
    [Route("api/Configuration")]
    public class ConfigurationController : ApiController
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [Route("general-info")]
        [HttpPost]
        public async Task<IActionResult> ConfigGeneralInfo([FromBody] ConfigurationModel model)
        {
            await _configurationService.ConfigGeneralInfo(model).ConfigureAwait(true);
            return NoContent();
        }

        [Route("get-general-info")]
        [HttpGet]
        public async Task<IActionResult> GetGeneralInfo()
        {
            return Ok(await _configurationService.GetGeneralInfo().ConfigureAwait(true));
        }
    }
}