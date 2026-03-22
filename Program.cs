using GameTournamentAPI.Data;
using GameTournamentAPI.Mapping;
using GameTournamentAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace GameTournamentAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Swagger
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new()
				{
					Title = "GameTournamentAPI",
					Version = "v1"
				});
			});

			builder.Services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(
					builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddAutoMapper(typeof(TournamentProfile));

			builder.Services.AddScoped<ITournamentService, TournamentService>();

			builder.Services.AddControllers();

			var app = builder.Build();

			// Swagger middleware
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}