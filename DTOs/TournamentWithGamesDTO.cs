namespace GameTournamentAPI.DTOs
{
	public class TournamentWithGamesDTO
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public DateTime Date { get; set; }

		public List<GameResponseDTO> Games { get; set; } = new();
	}
}
