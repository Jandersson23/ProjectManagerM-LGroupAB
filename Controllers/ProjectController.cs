using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagerM_LGroupAB.Data;
using ProjectManagerM_LGroupAB.Models;
using ProjectManagerM_LGroupAB.Services;

namespace ProjectManagerM_LGroupAB.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectController : ControllerBase
	{
		private readonly IProjectService _projectService;

		public ProjectController(IProjectService projectService)
		{
			_projectService = projectService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
		{
			var projects = await _projectService.GetAllProjects();
			return Ok(projects);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Project>> GetProjectById(int id)
		{
			var project = await _projectService.GetProjectById(id);

			if (project == null)
			{
				return NotFound();
			}

			return Ok(project);

		}

		[HttpPost]

		public async Task<ActionResult<Project>> CreateProject(Project project)
		{

			await _projectService.AddProject(project);
			return CreatedAtAction(nameof(GetProjectById), new { id = project.Id }, project);
		}

		[HttpPut("{id}")]

		public async Task<ActionResult> UppdateProject(int id, Project project)
		{
			if (id != project.Id)
			{
				return BadRequest(new { error = "Id:t i URL:en matchar inte Projektets id" });

			}

			try
			{

				await _projectService.UpdateProject(project);
			}

			catch (DbUpdateConcurrencyException)
			{
				return Conflict(new { error = "Projektet ändras av någon annan, ladda om sidan och försök igen" });
			}

			return NoContent();
		}

		[HttpDelete("{id}")]

		public async Task<ActionResult> DeleteProject (int id)
		{
			var project = await _projectService.GetProjectById(id);
			
			if (project == null)
			{
				return NotFound(new{error = "Project not found"  });
			}

			await DeleteProject(id);
			return NoContent();
		}


	}
}
