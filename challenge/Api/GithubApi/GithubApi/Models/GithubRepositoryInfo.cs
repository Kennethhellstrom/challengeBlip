using System.Text.Json.Serialization;

namespace GithubApi.Models
{
	public class GithubRepositoryInfo
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("description")] 
		public string Description { get; set; }

		[JsonPropertyName("owner")] 
		public Owner Owner { get; set; }

		[JsonPropertyName("language")]
		public string Language { get; set; }

		[JsonPropertyName("created_at")] 
		public DateTime PublishedDate { get; set; }
	}


	public class Owner
	{
		[JsonPropertyName("avatar_url")] 
		public string AvatarUrl { get; set; }
	}
}
