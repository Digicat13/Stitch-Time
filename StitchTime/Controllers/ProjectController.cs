using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using StitchTime.Core.Abstractions.Services;
using StitchTime.Core.Dto;

namespace StitchTime.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("[controller]")]
    [ApiController]

    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService service)
        {
            _projectService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProjectDto>> GetProjects()
        {
            try
            {
                var result = _projectService.GetAll();
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ProjectDto> GetProject(int id)
        {
            try
            {
                var result = _projectService.GetById(id);
                return Ok(result);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ProjectDto> PutProject(int id, ProjectDto Project)
        {
            try
            {
                var result = _projectService.Update(Project);
                return Ok(result);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> PostProject(ProjectDto Project)
        {
            try
            {
                await _projectService.Insert(Project);
                return Ok(Project);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(int id)
        {
            try
            {
                await _projectService.Delete(id);
                return NoContent();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            catch
            {
                return Problem();
            }
        }
    }
}