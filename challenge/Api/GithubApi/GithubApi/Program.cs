using GithubApi.Repository;
using GithubApi.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("GitHubApi", client =>
{
	client.BaseAddress = new Uri("https://api.github.com/");
	client.DefaultRequestHeaders.Add("User-Agent", "GitHubApiProxy");
	client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
});

// Registrar serviços
builder.Services.AddScoped<IRepositoriesService, RepositoriesService>();
builder.Services.AddScoped<IGithubRepository, GithubRepository>();


var app = builder.Build();

app.MapGet("/api/repositories", async (IRepositoriesService service) =>
{
	try
	{
		var repositories = await service.GetRepositories("takenet", "C#", 5);
		return Results.Ok(repositories);
	}
	catch (Exception ex)
	{
		return Results.Problem(ex.Message);
	}
})
.WithName("GetOldestCSharpRepositories")
.WithTags("Repositories");

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();



app.Run();

