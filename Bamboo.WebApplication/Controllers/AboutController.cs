using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bamboo.Core.Entities;
using Bamboo.Core.Models;
using Bamboo.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bamboo.WebApplication.Controllers
{
    [Route("api/about")]
    public class AboutController : ApiController
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAboutModel model)
        {
            return Ok(await _aboutService.CreateAsync(model));
        }

        [Route("abouts")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _aboutService.GetAbouts());
        }

        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AboutEntity model)
        {
            var about = await _aboutService.UpdateAsync(model);
            return Ok(about);
        }
    }
}