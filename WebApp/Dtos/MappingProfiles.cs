using AutoMapper;
using Model.Entities;

namespace WebApp.Dtos
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<EventFormDto, Event>().ReverseMap();
		}	
	}
}