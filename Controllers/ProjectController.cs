using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagerM_LGroupAB.Data;
using ProjectManagerM_LGroupAB.Models;

namespace ProjectManagerM_LGroupAB.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProjectController : ControllerBase
	{
		private readonly AppDbContext _context;

		public ProjectController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
		{
			return await _context.Projects.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Project>> GetProjects(int id)
		{
			var project = await _context.Projects.FindAsync(id);

			if (project == null)
			{
				return NotFound();
			}

			return project;

		}

		[HttpPost]

		public async Task<ActionResult<Project>> CreateProject(Project project)
		{
		
			if (project == null)
			{
				return BadRequest("Fyll i alla projektfält");
			}

			project.ProjectNumber = $"P-{Guid.NewGuid().ToString().Substring(0, 5)}";
			
			_context.Projects.Add(project);

			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetProjects), new { id = project.Id }, project);
		}

		[HttpPut("{id}")] 

		public async Task<ActionResult> UppdateProject(int id, Project project)
		{
			if (id != project.Id)
			{
				return BadRequest(new { error = "Id:t i URL:en matchar inte Projektets id" });

			}

			_context.Entry(project).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
				return NoContent();
			}

			catch (DbUpdateConcurrencyException)
			{
				return Conflict(new { error = "Projektet ändras av någon annan, ladda om sidan och försök igen" });
			}

			catch(Exception ex)
			{
				Console.WriteLine($"Fel vid uppdatering: {ex.Message}");
				return StatusCode(500, new { error = "Ett oväntat fel inträffade, försök igen senare!" });
			}
		}


	}
}
