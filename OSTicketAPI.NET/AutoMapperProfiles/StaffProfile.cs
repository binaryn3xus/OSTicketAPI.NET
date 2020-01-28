using System.Collections.Generic;
using AutoMapper;
using Newtonsoft.Json;
using OSTicketAPI.NET.Entities;
using OSTicketAPI.NET.Models;

namespace OSTicketAPI.NET.AutoMapperProfiles
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<OstStaff, Staff>()
                .ForMember(dest => dest.Extra, opt => opt.MapFrom<StaffExtrasResolver>())
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom<StaffPermissionsResolver>())
                .ForMember(dest => dest.DepartmentManagerOf, opt => opt.MapFrom(src => src.DepartmentManagerOf))
                .ForAllOtherMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
    
    public class StaffExtrasResolver : IValueResolver<OstStaff, Staff, Dictionary<string, object>>
    {
        public Dictionary<string, object> Resolve(OstStaff source, Staff destination, Dictionary<string, object> destMember, ResolutionContext context)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(source.Extra);
        }
    }
    public class StaffPermissionsResolver : IValueResolver<OstStaff, Staff, Dictionary<string, int>>
    {
        public Dictionary<string, int> Resolve(OstStaff source, Staff destination, Dictionary<string, int> destMember, ResolutionContext context)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, int>>(source.Permissions);
        }
    }
}
