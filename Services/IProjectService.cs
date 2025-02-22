using ProjectManagerM_LGroupAB.Models;

namespace ProjectManagerM_LGroupAB.Services
{
	public interface IProjectService
	{
		Task<IEnumerable<Project>> GetAllProjects();
		Task<Project?> GetProjectById(int id);
		Task AddProject(Project project);
		Task UpdateProject(Project project);
		Task DeleteProject(int id);
	}
}
