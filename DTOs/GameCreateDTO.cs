namespace GameTournamentAPI.DTOs
{
	public class GameCreateDTO
	{
		public string Title { get; set; } = string.Empty;

		public DateTime Time { get; set; }

		public int TournamentId { get; set; }

	}
}
