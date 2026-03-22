using GameTournamentAPI.DTOs;
using GameTournamentAPI.Models;

public interface ITournamentService
{
	Task<List<TournamentResponseDTO>> GetAllAsync(string? search);
	Task<Tournament?> GetByIdAsync(int id);
	Task<Tournament> CreateAsync(Tournament tournament);
	Task<bool> UpdateAsync(int id, TournamentUpdateDTO dto);
	Task<bool> DeleteAsync(int id);
}
