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
    [Route("api/project")]
    public class ProjectController : ApiController
    {
        private readonly IProjectCategoryService _projectCategoryService;
        private readonly IProjectService _projectService;

        public ProjectController(IProjectCategoryService projectCategoryService, IProjectService projectService)
        {
            _projectCategoryService = projectCategoryService;
            _projectService = projectService;
        }

        [Route("category/create")]
        [HttpPost]
        public async Task<IActionResult> CreateProjectCategory([FromBody] CreateProjectCategoryModel model)
        {
            var result = await _projectCategoryService.Create(model).ConfigureAwait(true);
            return Ok(result);
        }

        [Route("category/gets")]
        [HttpGet]
        public async Task<IActionResult> GetProjectCategory()
        {
            return Ok(await _projectCategoryService.GetAll().ConfigureAwait(true));
        }

        [Route("category/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProjectCategory(int id)
        {
            await _projectCategoryService.DeleteAsync(id).ConfigureAwait(true);
            return NoContent();
        }

        [Route("category/update")]
        [HttpPut]
        public async Task<IActionResult> UpdateProjectCategory([FromBody] ProjectCategoryModel model)
        {
            await _projectCategoryService.UpdateAsync(model);
            return NoContent();
        }

        [Route("create")]
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectModel model)
        {
            var result = await _projectService.CreateAsync(model).ConfigureAwait(true);
            return Ok(result);
        }

        [Route("getall")]
        [HttpGet]
        public async Task<IActionResult> GetAllProject()
        {
            return Ok(await _projectService.GetAllAsync().ConfigureAwait(true));
        }

        [Route("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            return Ok(await _projectService.GetById(id).ConfigureAwait(true));
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectService.Delete(id).ConfigureAwait(true);
            return NoContent();
        }

        [Route("edit")]
        [HttpPut]
        public async Task<IActionResult> EditProject([FromBody] EditProjectModel model)
        {
            await _projectService.UpdateAsync(model).ConfigureAwait(true);
            return NoContent();
        }

    }
}