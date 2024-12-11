using GithubApi.Repository;
using GithubApi.Repository.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configurar o Serilog para logs no console e em arquivo
Log.Logger = new LoggerConfiguration()
	.WriteTo.Console()
	.WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7)
	.CreateLogger();

builder.Host.UseSerilog();

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

// Registrar servi�os
builder.Services.AddScoped<IRepositoriesService, RepositoriesService>();
builder.Services.AddScoped<IGithubRepository, GithubRepository>();

var app = builder.Build();

app.MapGet("/api/repositories", async (IRepositoriesService service) =>
{
	try
	{
		Log.Information("Iniciando busca pelos reposit�rios mais antigos...");

		var repositories = await service.GetRepositories("takenet", "C#", 5);

		if (!repositories.Any())
		{
			Log.Warning("Nenhum reposit�rio encontrado para os crit�rios especificados.");
			return Results.NotFound("Nenhum reposit�rio encontrado para os crit�rios especificados.");
		}

		Log.Information("Reposit�rios recuperados com sucesso.");
		return Results.Ok(repositories);
	}
	catch (Exception ex)
	{
		Log.Error(ex, "Erro ao recuperar os reposit�rios.");
		return Results.Problem(
			detail: ex.Message,
			statusCode: StatusCodes.Status500InternalServerError,
			title: "Erro ao recuperar os reposit�rios."
		);
	}
})
.WithName("GetOldestCSharpRepositories")
.WithTags("Repositories");


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.Run();

Log.CloseAndFlush();

