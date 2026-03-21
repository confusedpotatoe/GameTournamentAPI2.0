

using System.ComponentModel.DataAnnotations;

namespace GameTournamentAPI.Dtos
{
	public class TournamentCreateDTO
	{
		[Required]
		[MinLength(3)]
		public string Titel { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int maxPlayers { get; set; }
		public DateTime Date { get; set; }

	}
}
