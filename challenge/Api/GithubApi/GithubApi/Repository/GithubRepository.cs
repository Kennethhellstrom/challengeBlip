using GithubApi.Models;
using GithubApi.Repository.Interfaces;

namespace GithubApi.Repository
{
	public class GithubRepository : IGithubRepository
	{
		private readonly HttpClient _httpClient;

		public GithubRepository(IHttpClientFactory httpClientFactory)
		{
			_httpClient = httpClientFactory.CreateClient("GitHubApi");
		}


		public async Task<IEnumerable<GithubRepositoryInfo>> GetRepositories(string organization, string language, int topCount)
		{
			var response = await _httpClient.GetAsync($"orgs/{organization}/repos");
			response.EnsureSuccessStatusCode();

			var repositories = await response.Content.ReadFromJsonAsync<IEnumerable<GithubRepositoryInfo>>();

			// Filtrar por linguagem e ordenar pelos mais antigos
			var filteredRepos = repositories?
				.Where(repo => string.Equals(repo.Language, language, StringComparison.OrdinalIgnoreCase))
				.OrderBy(repo => repo.PublishedDate)
				.Take(topCount);

			return filteredRepos ?? Enumerable.Empty<GithubRepositoryInfo>();
		}
	}
}

