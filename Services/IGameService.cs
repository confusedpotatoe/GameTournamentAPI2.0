using GameTournamentAPI.Models;

namespace GameTournamentAPI.Services

{
	public interface IGameService
	{
		Task<List<Game>> GetAllAsync();
		Task<Game> CreateAsync(Game game);
	}
}
