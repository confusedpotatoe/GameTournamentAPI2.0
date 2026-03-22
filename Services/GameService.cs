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
			return await _context.Games.ToListAsync();
		}

		public async Task<Game> CreateAsync(Game game)
		{
			_context.Games.Add(game);
			await _context.SaveChangesAsync();
			return game;
		}
	}
}
