namespace GameTournamentAPI.Dtos
{
	public class TournamentUpdateDTO
	{
		public string Titel { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int maxPlayers { get; set; }
		public DateTime Date { get; set; }

	}
}
