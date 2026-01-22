using AutoMapper;
using eCommers.Core.DTO;
using eCommers.Domain;

namespace eCommers.Core.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser,AuthenticationResponse>()
            .ForMember(temp => temp.Email,option => option.MapFrom(src => src.Email))
            .ForMember(temp => temp.PersonName,option => option.MapFrom(src => src.PersonName))
            .ForMember(temp => temp.UserId,option => option.MapFrom(scr => scr.UserId))
            .ForMember(temp => temp.Gender,option => option.MapFrom(src => src.Gender))
            .ForMember(temp => temp.Success,option => option.Ignore())
            .ForMember(temp => temp.Token,option => option.Ignore());

            CreateMap<RegisterRequest,ApplicationUser>()
            .ForMember(temp => temp.Email,option => option.MapFrom(src => src.Email))
            .ForMember(temp => temp.Gender,option => option.MapFrom(src => src.Gender))
            .ForMember(temp => temp.Password,option => option.MapFrom(src => src.Password))
            .ForMember(temp => temp.PersonName,option => option.MapFrom(src => src.PersonName))
            .ForMember(temp => temp.UserId,option => option.Ignore());
        }
    }
}