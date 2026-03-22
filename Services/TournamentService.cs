using AutoMapper;
using GameTournamentAPI.Data;
using GameTournamentAPI.DTOs;
using GameTournamentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTournamentAPI.Services
{
	public class TournamentService : ITournamentService
	{
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;

		public TournamentService(AppDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<TournamentResponseDTO>> GetAllAsync(string? search)
		{
			var query = _context.Tournaments
				.AsNoTracking();

			if (!string.IsNullOrEmpty(search))
				query = query.Where(t => t.Title.ToLower().Contains(search.ToLower()));

			var tournaments = await query
				.OrderByDescending(t => t.Date)
				.ToListAsync();

			return _mapper.Map<List<TournamentResponseDTO>>(tournaments);
		}

		public async Task<Tournament?> GetByIdAsync(int id)
		{
			return await _context.Tournaments.FindAsync(id);
		}

		public async Task<Tournament> CreateAsync(Tournament tournament)
		{
			if (tournament.Date < DateTime.UtcNow)
				throw new ArgumentException("Date cannot be in the past");

			_context.Tournaments.Add(tournament);
			await _context.SaveChangesAsync();
			return tournament;
		}

		public async Task<bool> UpdateAsync(int id, TournamentUpdateDTO dto)
		{
			var existing = await _context.Tournaments.FindAsync(id);
			if (existing == null) return false;

			if (dto.Date < DateTime.UtcNow)
				throw new ArgumentException("Date cannot be in the past");
			_mapper.Map(dto, existing);

			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var existing = await _context.Tournaments.FindAsync(id);
			if (existing == null) return false;

			_context.Tournaments.Remove(existing);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<Tournament?> GetWithGamesAsync(int id)
		{
			return await _context.Tournaments
				.Include(t => t.Games)
				.FirstOrDefaultAsync(t => t.Id == id);
		}
	}
}