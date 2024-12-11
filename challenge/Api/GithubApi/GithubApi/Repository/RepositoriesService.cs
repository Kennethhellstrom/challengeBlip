using GithubApi.Models;
using GithubApi.Repository.Interfaces;

namespace GithubApi.Repository
{
	public class RepositoriesService : IRepositoriesService
	{
		private readonly IGithubRepository _repository;

		public RepositoriesService(IGithubRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<GithubRepositoryInfo>> GetRepositories(string organization, string language, int topCount)
		{
			if (string.IsNullOrWhiteSpace(organization))
				throw new ArgumentException("Organization cannot be null or empty.", nameof(organization));
			if (string.IsNullOrWhiteSpace(language))
				throw new ArgumentException("Language cannot be null or empty.", nameof(language));

			return await _repository.GetRepositories(organization, language, topCount);
		}
	}
}
