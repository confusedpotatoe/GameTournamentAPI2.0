using GameTournamentAPI.Dtos;
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
		public async Task<ActionResult<List<Tournament>>> GetAll([FromQuery] string? search)
		{
			var tournaments = await _service.GetAllSyncs(search);
			return Ok(tournaments);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Tournament>> GetById(int id)
		{
			var tournament = await _service.GetByIdAsync(id);
			if (tournament == null)
			{
				return NotFound();
			}
			return Ok(tournament);
		}

		[HttpPost]
		public async Task<ActionResult> Create(TournamentCreateDTO dto)
		{
			var tournament = new Tournament
			{
				Titel = dto.Titel,
				Description = dto.Description,
				MaxPlayers = dto.maxPlayers,
				DateTime = dto.Date
			};
			var created = await _service.CreateAsync(tournament);
			return Ok(new TournamentResponseDTO { Id = created.Id });
		}
	}

}

