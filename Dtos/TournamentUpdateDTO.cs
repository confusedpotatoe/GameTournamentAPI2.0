namespace GameTournamentAPI.Dtos
{
	public class TournamentUpdateDTO
	{
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int MaxPlayers { get; set; }
		public DateTime Date { get; set; }

	}
}
