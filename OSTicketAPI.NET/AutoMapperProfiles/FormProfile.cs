using AutoMapper;
using OSTicketAPI.NET.Entities;
using OSTicketAPI.NET.Models;

namespace OSTicketAPI.NET.AutoMapperProfiles
{
    public class FormProfile : Profile
    {
        public FormProfile()
        {
            CreateMap<OstFormField, FormField>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.FormId, opt => opt.MapFrom(src => src.FormId))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Configuration, opt => opt.MapFrom(src => src.Configuration))
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Label))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Sort, opt => opt.MapFrom(src => src.Sort))
                .ForMember(dest => dest.Hint, opt => opt.MapFrom(src => src.Hint))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.Flags, opt => opt.MapFrom(src => src.Flags))
                .ForSourceMember(source => source.OstForm, opt => opt.DoNotValidate())
                .ForSourceMember(source => source.OstFormEntryValues, opts => opts.DoNotValidate())
                .ForAllOtherMembers(opts => opts.Condition((_, __, srcMember) => srcMember != null));
        }
    }
}
