namespace GameTournamentAPI.Models
{
	public class Tournament
	{
		public int Id { get; set; }
		public string Titel { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;
		public int MaxPlayers { get; set; }

		public DateTime DateTime { get; set; }

	}
}
