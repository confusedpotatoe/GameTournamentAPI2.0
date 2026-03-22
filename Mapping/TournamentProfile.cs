using AutoMapper;
using GameTournamentAPI.DTOs;
using GameTournamentAPI.Models;

namespace GameTournamentAPI.Mapping
{
	public class TournamentProfile : Profile
	{
		public TournamentProfile()
		{
			CreateMap<Tournament, TournamentResponseDTO>();

			CreateMap<TournamentCreateDTO, Tournament>();

			CreateMap<TournamentUpdateDTO, Tournament>()
				.ForAllMembers(opt =>
					opt.Condition((src, dest, srcMember) => srcMember != null));
		}
	}
}