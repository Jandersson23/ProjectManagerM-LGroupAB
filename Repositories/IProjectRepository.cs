using ProjectManagerM_LGroupAB.Models;

namespace ProjectManagerM_LGroupAB.Repositories
{
	public interface IProjectRepository
	{
		Task<IEnumerable<Project>> GetAllProjects();
		Task<Project?> GetProjectById(int id);
		Task AddProject(Project project);
		Task UppdateProject(Project project);
		Task DeleteProject(int id);

	}
}
