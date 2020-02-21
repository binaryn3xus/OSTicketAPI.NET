using AutoMapper;
using OSTicketAPI.NET.Entities;
using OSTicketAPI.NET.Models;

namespace OSTicketAPI.NET.AutoMapperProfiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<OstUser, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrgId, opt => opt.MapFrom(src => src.OstOrganization.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.OstUserEmail.Address))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.AccountStatus, opt => opt.MapFrom(src => src.OstUserAccount.Status))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.OstUserAccount.Username))
                .ForMember(dest => dest.Timezone, opt => opt.MapFrom(src => src.OstUserAccount.Timezone))
                .ForMember(dest => dest.Registered, opt => opt.MapFrom(src => src.OstUserAccount.Registered))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ReverseMap();
        }
    }
}
