using AutoMapper;
using GameTournamentAPI.DTOs;
using GameTournamentAPI.Models;
using GameTournamentAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameTournamentAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]

	public class GameController : ControllerBase
	{
		private readonly IGameService _service;
		private readonly IMapper _mapper;

		public GameController(IGameService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<List<GameResponseDTO>>> GetAll()
		{
			var games = await _service.GetAllAsync();
			var gameDTOs = _mapper.Map<List<GameResponseDTO>>(games);
			return Ok(gameDTOs);
		}

		[HttpPost]
		public async Task<ActionResult> Create(GameCreateDTO dto)
		{
			var game = _mapper.Map<Game>(dto);
			var created = await _service.CreateAsync(game);

			return Ok(_mapper.Map<GameResponseDTO>(created));
		}
	}
}
