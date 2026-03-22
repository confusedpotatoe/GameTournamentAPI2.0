namespace GameTournamentAPI.Models
{
	public class Tournament
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;

		public string Description { get; set; } = string.Empty;

		public int MaxPlayers { get; set; }

		public DateTime Date { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		public DateTime? UpdatedAt { get; set; }

		public ICollection<Game> Games { get; set; } = new List<Game>();
	}
}