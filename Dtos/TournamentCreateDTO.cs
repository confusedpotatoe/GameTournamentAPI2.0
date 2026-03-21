

using System.ComponentModel.DataAnnotations;

namespace GameTournamentAPI.Dtos
{
	public class TournamentCreateDTO
	{
		[Required]
		[MinLength(3)]
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;

		[Range(1, 200)]
		public int MaxPlayers { get; set; }
		public DateTime Date { get; set; }

	}
}
