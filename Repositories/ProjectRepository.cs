

using Microsoft.EntityFrameworkCore;
using ProjectManagerM_LGroupAB.Data;
using ProjectManagerM_LGroupAB.Models;

namespace ProjectManagerM_LGroupAB.Repositories
{
	public class ProjectRepository : IProjectRepository
	{
		private readonly AppDbContext _context;

		public ProjectRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Project>> GetAllProjects()
		{
			return await _context.Projects.ToListAsync();
		}

		public async Task <Project?> GetProjectById(int id)
		{
			return await _context.Projects.FindAsync();
		}

		public async Task AddProject(Project project)
		{
			_context.Projects.Add(project);
			await _context.SaveChangesAsync();
		}

		public async Task UppdateProject(Project project)
		{
			_context.Entry(project).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteProject(int id)
		{
			var project = await _context.Projects.FindAsync(id);
			if (project != null)
			{
				_context.Projects.Remove(project);
				await _context.SaveChangesAsync();
			}
		}
	}
}
