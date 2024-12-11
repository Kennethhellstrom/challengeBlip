using GithubApi.Models;

namespace GithubApi.Repository.Interfaces
{
	public interface IGithubRepository
	{
		Task<IEnumerable<GithubRepositoryInfo>> GetRepositories(string organization, string language, int topCount);
	}
}
