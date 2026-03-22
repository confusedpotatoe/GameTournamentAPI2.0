using System.ComponentModel.DataAnnotations;

namespace GameTournamentAPI.DTOs
{
	public class TournamentUpdateDTO
	{
		[MinLength(3)]
		public string? Title { get; set; }

		public string? Description { get; set; }

		[Range(2, 1000)]
		public int? MaxPlayers { get; set; }

		public DateTime? Date { get; set; }
	}
}