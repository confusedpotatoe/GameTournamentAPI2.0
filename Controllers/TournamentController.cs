using GameTournamentAPI.DTOs;
using GameTournamentAPI.Models;
using GameTournamentAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameTournamentAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TournamentController : ControllerBase
	{
		private readonly ITournamentService _service;

		public TournamentController(ITournamentService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<List<TournamentResponseDTO>>> GetAll([FromQuery] string? search)
		{
			var tournaments = await _service.GetAllSyncs(search);

			var result = tournaments.Select(t => new TournamentResponseDTO
			{
				Id = t.Id,
				Title = t.Title,
				Description = t.Description,
				MaxPlayers = t.MaxPlayers,
				Date = t.DateTime
			});

			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<TournamentResponseDTO>> GetById(int id)
		{
			var tournament = await _service.GetByIdAsync(id);

			if (tournament == null)
			{
				return NotFound();
			}

			var dto = new TournamentResponseDTO
			{
				Id = tournament.Id,
				Title = tournament.Title,
				Description = tournament.Description,
				MaxPlayers = tournament.MaxPlayers,
				Date = tournament.DateTime
			};

			return Ok(dto);
		}

		[HttpPost]
		public async Task<ActionResult> Create(TournamentCreateDTO dto)
		{
			var tournament = new Tournament
			{
				Title = dto.Title,
				Description = dto.Description,
				MaxPlayers = dto.MaxPlayers,
				DateTime = dto.Date
			};
			var created = await _service.CreateAsync(tournament);
			return CreatedAtAction(nameof(GetById), new { id = created.Id }, new TournamentResponseDTO
			{
				Id = created.Id,
				Title = created.Title,
				Description = created.Description,
				MaxPlayers = created.MaxPlayers,
				Date = created.DateTime
			});
		}
	}

}

