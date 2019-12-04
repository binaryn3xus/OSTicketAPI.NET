using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json.Linq;
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
                .ForMember(dest => dest.Flags, opt => opt.MapFrom(src => src.Flags))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
                .ForMember(dest => dest.PriorityId, opt => opt.MapFrom(src => src.PriorityId))
                .ForMember(dest => dest.DeptId, opt => opt.MapFrom(src => src.DeptId))
                .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => src.TeamId))
                .ForMember(dest => dest.SlaId, opt => opt.MapFrom(src => src.SlaId))
                .ForMember(dest => dest.PageId, opt => opt.MapFrom(src => src.PageId))
                .ForMember(dest => dest.SequenceId, opt => opt.MapFrom(src => src.SequenceId))
                .ForMember(dest => dest.Sort, opt => opt.MapFrom(src => src.Sort))
                .ForMember(dest => dest.NumberFormat, opt => opt.MapFrom(src => src.NumberFormat))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.FormFields, opt => opt.MapFrom<HelpTopicFormFieldsResolver>());
        }
    }

    public class HelpTopicFormFieldsResolver : IValueResolver<OstHelpTopic, HelpTopic, IEnumerable<FormField>>
    {
        public IEnumerable<FormField> Resolve(OstHelpTopic source, HelpTopic destination, IEnumerable<FormField> destMember, ResolutionContext context)
        {
            var formFields = new List<FormField>();
            foreach (var htForm in source.HelpTopicForms)
            {
                var disabled = JObject.Parse(htForm.Extra)["disable"].Select(o => (int)o).ToArray();
                formFields.AddRange(from field in htForm.OstForm.OstFormFields
                where !disabled.Contains(field.Id)
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
                });
            }

            return formFields;
        }
    }
}
