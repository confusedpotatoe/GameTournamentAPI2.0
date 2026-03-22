using System.ComponentModel.DataAnnotations;

public class GameCreateDTO
{
	[Required]
	[MinLength(3)]
	public string Title { get; set; } = string.Empty;

	public DateTime Time { get; set; }

	public int TournamentId { get; set; }
}