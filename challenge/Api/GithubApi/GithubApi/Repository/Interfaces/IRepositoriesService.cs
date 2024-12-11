using GithubApi.Models;

namespace GithubApi.Repository.Interfaces
{
	public interface IRepositoriesService
	{
		Task<IEnumerable<GithubRepositoryInfo>> GetRepositories(string organization, string language, int topCount);
	}
}
