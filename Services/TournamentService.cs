using GameTournamentAPI.Data;
using GameTournamentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTournamentAPI.Services

{
	public class TournamentService : ITournamentService
	{
		private readonly AppDbContext _context;

		public TournamentService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<List<Tournament>> GetAllSyncs(string? search)
		{
			var query = _context.Tournaments.AsQueryable();
			if (!string.IsNullOrEmpty(search))
			{
				query = query.Where(t => t.Titel.Contains(search));
			}
			return await query.ToListAsync();
		}

		public async Task<Tournament?> GetByIdAsync(int id)
		{
			return await _context.Tournaments.FindAsync(id);
		}

		public async Task<Tournament> CreateAsync(Tournament tournament)
		{
			_context.Tournaments.Add(tournament);
			await _context.SaveChangesAsync();
			return tournament;
		}

		public async Task<bool> UpdateAsync(int id, Tournament tournament)
		{
			var existingTournament = await _context.Tournaments.FindAsync(id);
			if (existingTournament == null)
			{
				return false;
			}
			existingTournament.Titel = tournament.Titel;
			existingTournament.Description = tournament.Description;
			existingTournament.MaxPlayers = tournament.MaxPlayers;
			existingTournament.DateTime = tournament.DateTime;
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var existingTournament = await _context.Tournaments.FindAsync(id);
			if (existingTournament == null)
			{
				return false;
			}
			_context.Tournaments.Remove(existingTournament);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}
