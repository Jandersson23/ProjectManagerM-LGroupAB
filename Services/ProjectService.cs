using ProjectManagerM_LGroupAB.Models;
using ProjectManagerM_LGroupAB.Repositories;


namespace ProjectManagerM_LGroupAB.Services
{
	public class ProjectService : IProjectService
	{
		private readonly IProjectRepository _projectRepository;

		public ProjectService(IProjectRepository projectRepository)
		{
			_projectRepository = projectRepository;
		}

		public async Task<IEnumerable<Project>> GetAllProjects()
		{
			return await _projectRepository.GetAllProjects();
		}

		public async Task<Project?> GetProjectById(int id)
		{
			return await _projectRepository.GetProjectById(id);
		}

		public async Task AddProject(Project project)
		{
			await _projectRepository.AddProject(project);
		}

		public async Task UpdateProject(Project project)
		{
			await _projectRepository.UppdateProject(project);
		}

		public async Task DeleteProject(int id)
		{
			await _projectRepository.DeleteProject(id);
		}
	}
}
