using AutoMapper;
using GameTournamentAPI.DTOs;
using GameTournamentAPI.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TournamentController : ControllerBase
{
	private readonly ITournamentService _service;
	private readonly IMapper _mapper;

	public TournamentController(ITournamentService service, IMapper mapper)
	{
		_service = service;
		_mapper = mapper;
	}

	[HttpGet]
	public async Task<ActionResult<List<TournamentResponseDTO>>> GetAll(string? search)
	{
		var tournaments = await _service.GetAllAsync(search);
		return Ok(_mapper.Map<List<TournamentResponseDTO>>(tournaments));
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<TournamentResponseDTO>> GetById(int id)
	{
		var tournament = await _service.GetByIdAsync(id);
		if (tournament == null) return NotFound();

		return Ok(_mapper.Map<TournamentResponseDTO>(tournament));
	}

	[HttpPost]
	public async Task<ActionResult> Create([FromBody] TournamentCreateDTO dto)
	{
		var model = _mapper.Map<Tournament>(dto);

		var created = await _service.CreateAsync(model);

		return CreatedAtAction(nameof(GetById),
			new { id = created.Id },
			_mapper.Map<TournamentResponseDTO>(created));
	}

	[HttpPut("{id}")]
	public async Task<ActionResult> Update(int id, [FromBody] TournamentUpdateDTO dto)
	{
		var success = await _service.UpdateAsync(id, dto);
		if (!success) return NotFound();

		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> Delete(int id)
	{
		var success = await _service.DeleteAsync(id);
		if (!success) return NotFound();

		return NoContent();
	}

	[HttpGet("{id}/with-games")]
	public async Task<ActionResult<TournamentWithGamesDTO>> GetWithGames(int id)
	{
		var tournament = await _service.GetWithGamesAsync(id);
		if (tournament == null) return NotFound();

		return Ok(_mapper.Map<TournamentWithGamesDTO>(tournament));
	}

	[HttpGet("/api/tournaments/{tournamentId}/games")]
	public async Task<ActionResult<List<GameResponseDTO>>> GetGamesByTournament(int tournamentId)
	{
		var games = await _service.GetByTournamentIdAsync(tournamentId);
		return Ok(_mapper.Map<List<GameResponseDTO>>(games));
	}
}