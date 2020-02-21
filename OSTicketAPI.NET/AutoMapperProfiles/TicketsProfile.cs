using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using OSTicketAPI.NET.Entities;
using OSTicketAPI.NET.Models;

namespace OSTicketAPI.NET.AutoMapperProfiles
{
    public class TicketsProfile : Profile
    {
        public TicketsProfile()
        {
            CreateMap<OstTicketStatus, TicketStatus>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Mode, opt => opt.MapFrom(src => src.Mode))
                .ForMember(dest => dest.Flags, opt => opt.MapFrom(src => src.Flags))
                .ForMember(dest => dest.Sort, opt => opt.MapFrom(src => src.Sort))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.Properties, opt => opt.MapFrom<TicketStatusPropertiesJsonResolver>());

            CreateMap<TicketStatus, OstTicketStatus>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Mode, opt => opt.MapFrom(src => src.Mode))
                .ForMember(dest => dest.Flags, opt => opt.MapFrom(src => src.Flags))
                .ForMember(dest => dest.Sort, opt => opt.MapFrom(src => src.Sort))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForMember(dest => dest.Properties, opt => opt.MapFrom<TicketStatusPropertiesDictionaryResolver>());

            CreateMap<OstTicket, Ticket>()
                .ForMember(dest => dest.TicketId, opt => opt.MapFrom(src => src.TicketId))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.OstUser))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.OstDepartment))
                .ForMember(dest => dest.HelpTopic, opt => opt.MapFrom(src => src.OstHelpTopic))
                .ForMember(dest => dest.Staff, opt => opt.MapFrom(src => src.OstStaff))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.OstTicketStatus))
                .ForMember(dest => dest.Events, opt => opt.MapFrom(src => src.OstThread.OstThreadEvents.AsEnumerable()))
                .ForMember(dest => dest.ThreadEntries, opt => opt.MapFrom(src => src.OstThread.OstThreadEntries.AsEnumerable()))
                .ForMember(dest => dest.FormFields, opt => opt.MapFrom<TicketFormFieldsResolver>())
                .ForAllOtherMembers(opts => opts.Condition((_, __, srcMember) => srcMember != null));

            CreateMap<Ticket, OstTicket>()
                .ForMember(dest => dest.TicketId, opt => opt.MapFrom(src => src.TicketId))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.UserEmailId, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.Status.Id))
                .ForMember(dest => dest.DeptId, opt => opt.MapFrom(src => src.Department.Id))
                .ForMember(dest => dest.SlaId, opt => opt.MapFrom(src => src.SlaId))
                .ForMember(dest => dest.TopicId, opt => opt.MapFrom(src => src.HelpTopic.TopicId))
                .ForMember(dest => dest.StaffId, opt => opt.NullSubstitute(0))
                .ForMember(dest => dest.OstTicketStatus, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => src.TeamId))
                .ForMember(dest => dest.EmailId, opt => opt.UseDestinationValue())
                .ForMember(dest => dest.LockId, opt => opt.MapFrom(src => src.LockId))
                .ForMember(dest => dest.Flags, opt => opt.MapFrom(src => src.Flags))
                .ForMember(dest => dest.IpAddress, opt => opt.MapFrom(src => src.IpAddress))
                .ForMember(dest => dest.Source, opt => opt.MapFrom(src => src.Source))
                .ForMember(dest => dest.SourceExtra, opt => opt.MapFrom(src => src.SourceExtra))
                .ForMember(dest => dest.IsOverDue, opt => opt.MapFrom(src => src.IsOverDue))
                .ForMember(dest => dest.IsAnswered, opt => opt.MapFrom(src => src.IsAnswered))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.EstDueDate, opt => opt.MapFrom(src => src.EstDuedate))
                .ForMember(dest => dest.Reopened, opt => opt.MapFrom(src => src.Reopened))
                .ForMember(dest => dest.Closed, opt => opt.MapFrom(src => src.Closed))
                .ForMember(dest => dest.LastUpdate, opt => opt.MapFrom(src => src.LastUpdate))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.Created))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(src => src.Updated))
                .ForAllOtherMembers(opts => opts.Condition((_, __, srcMember) => srcMember != null));
        }
    }

    public class TicketStatusPropertiesJsonResolver : IValueResolver<OstTicketStatus, TicketStatus, Dictionary<string, object>>
    {
        public Dictionary<string, object> Resolve(OstTicketStatus source, TicketStatus destination, Dictionary<string, object> destMember, ResolutionContext context)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(source.Properties);
        }
    }

    public class TicketStatusPropertiesDictionaryResolver : IValueResolver<TicketStatus, OstTicketStatus, string>
    {
        public string Resolve(TicketStatus source, OstTicketStatus destination, string destMember, ResolutionContext context)
        {
            return JsonConvert.SerializeObject(source.Properties);
        }
    }

    public class TicketFormFieldsResolver : IValueResolver<OstTicket, Ticket, Dictionary<FormField, OstFormEntryValue>>
    {
        public Dictionary<FormField, OstFormEntryValue> Resolve(OstTicket source, Ticket destination, Dictionary<FormField, OstFormEntryValue> destMember, ResolutionContext context)
        {
            var formFieldDictionary = new Dictionary<FormField, OstFormEntryValue>();

            foreach (var formEntry in source.OstFormEntry)
            {
                foreach (var formEntryValue in formEntry.OstFormEntryValues.Where(fe => fe.OstFormField != null))
                {
                    var formField = context.Mapper.Map<FormField>(formEntryValue.OstFormField);
                    formFieldDictionary.Add(formField, formEntryValue);
                }
            }

            return formFieldDictionary;
        }
    }
}
