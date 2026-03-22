using GameTournamentAPI.Data;
using GameTournamentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTournamentAPI.Services
{
	public class GameService : IGameService
	{
		private readonly AppDbContext _context;

		public GameService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<List<Game>> GetAllAsync()
		{
			return await _context.Games
			.AsNoTracking()
			.OrderBy(g => g.Time)
			.ToListAsync();
		}

		public async Task<List<Game>> GetByTournamentIdAsync(int tournamentId)
		{
			return await _context.Games
			.AsNoTracking()
			.Where(g => g.TournamentId == tournamentId)
			.OrderBy(g => g.Time)
			.ToListAsync();
		}
		public async Task<Game> CreateAsync(Game game)
		{
			if (game.Time < DateTime.UtcNow)
				throw new ArgumentException("Game time cannot be in the past");

			var tournamentExists = await _context.Tournaments
				.AnyAsync(t => t.Id == game.TournamentId);

			if (!tournamentExists)
				throw new ArgumentException("Tournament does not exist");

			_context.Games.Add(game);
			await _context.SaveChangesAsync();

			return game;
		}
	}
}
