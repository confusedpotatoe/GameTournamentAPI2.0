namespace GameTournamentAPI.DTOs
{
	public class GameResponseDTO
	{
		public int Id { get; set; }

		public string title { get; set; } = string.Empty;

		public DateTime Time { get; set; }

		public int TournamentId { get; set; }

	}
}
