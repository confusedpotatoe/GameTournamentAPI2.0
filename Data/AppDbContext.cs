using GameTournamentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTournamentAPI.Data

{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options) { }

		public DbSet<Tournament> Tournaments { get; set; }

		public DbSet<Game> Games { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Tournament>()
				.HasMany(t => t.Games)
				.WithOne(g => g.Tournament)
				.HasForeignKey(g => g.TournamentId);

			base.OnModelCreating(modelBuilder);
		}
	}
}
