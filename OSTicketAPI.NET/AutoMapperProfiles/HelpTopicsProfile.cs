using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using OSTicketAPI.NET.Entities;
using OSTicketAPI.NET.Models;

namespace OSTicketAPI.NET.AutoMapperProfiles
{
    public class HelpTopicsProfile : Profile
    {
        public HelpTopicsProfile()
        {
            CreateMap<OstHelpTopic, HelpTopic>()
                .ForMember(dest => dest.TopicId, opt => opt.MapFrom(src => src.TopicId))
                .ForMember(dest => dest.TopicName, opt => opt.MapFrom(src => src.Topic))
                .ForMember(dest => dest.IsPublic, opt => opt.MapFrom(src => src.Ispublic))
                .ForMember(dest => dest.FormFields, opt => opt.MapFrom<HelpTopicFormFieldsResolver>());
        }
    }

    public class HelpTopicFormFieldsResolver : IValueResolver<OstHelpTopic, HelpTopic, IEnumerable<FormField>>
    {
        public IEnumerable<FormField> Resolve(OstHelpTopic source, HelpTopic destination, IEnumerable<FormField> destMember, ResolutionContext context)
        {
            return (from htForm in source.HelpTopicForms
            from form in htForm.OstForms
            from field in form.OstFormFields
            select new FormField()
            {
                Id = field.Id,
                FormId = field.FormId,
                Flags = field.Flags,
                Type = field.Type,
                Name = field.Label,
                SystemName = field.Name,
                Configuration = field.Configuration,
                Sort = field.Sort,
                Hint = field.Hint,
                Created = field.Created,
                Updated = field.Updated
            }).ToList();
        }
    }
}
