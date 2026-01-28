using AutoMapper;
using eCommers.Core.DTO;
using eCommers.Domain;

namespace eCommers.Core.Mappers
{
    public class ApplicatoinUserToUserDTOMappingProfile : Profile
    {
        public ApplicatoinUserToUserDTOMappingProfile()
        {
            CreateMap<ApplicationUser,UserDTO>()
            .ForMember(x => x.UserID,options => options.MapFrom(x => x.UserId))
            .ForMember(x => x.Email,options => options.MapFrom(x => x.Email))
            .ForMember(x => x.Gender,options => options.MapFrom(x => x.Gender))
            .ForMember(x => x.PersonName,options => options.MapFrom(x => x.PersonName));
            
        }
    }
}