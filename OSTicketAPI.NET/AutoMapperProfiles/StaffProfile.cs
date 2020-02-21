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
                .ForMember(dest => dest.Extra, opt => opt.MapFrom<StaffExtrasJsonResolver>())
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom<StaffPermissionsJsonResolver>())
                .ForMember(dest => dest.DepartmentManagerOf, opt => opt.MapFrom(src => src.DepartmentManagerOf))
                .ForAllOtherMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Staff, OstStaff>()
                .ForMember(dest => dest.Extra, opt => opt.MapFrom<StaffExtrasDictionaryResolver>())
                .ForMember(dest => dest.Permissions, opt => opt.MapFrom<StaffPermissionsDictionaryResolver>())
                .ForMember(dest => dest.DepartmentManagerOf, opt => opt.MapFrom(src => src.DepartmentManagerOf))
                .ForAllOtherMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
    
    public class StaffExtrasJsonResolver : IValueResolver<OstStaff, Staff, Dictionary<string, object>>
    {
        public Dictionary<string, object> Resolve(OstStaff source, Staff destination, Dictionary<string, object> destMember, ResolutionContext context)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(source.Extra);
        }
    }

    public class StaffExtrasDictionaryResolver : IValueResolver<Staff, OstStaff, string>
    {
        public string Resolve(Staff source, OstStaff destination, string destMember, ResolutionContext context)
        {
            return JsonConvert.SerializeObject(source.Extra);
        }
    }

    public class StaffPermissionsJsonResolver : IValueResolver<OstStaff, Staff, Dictionary<string, int>>
    {
        public Dictionary<string, int> Resolve(OstStaff source, Staff destination, Dictionary<string, int> destMember, ResolutionContext context)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, int>>(source.Permissions);
        }
    }

    public class StaffPermissionsDictionaryResolver : IValueResolver<Staff, OstStaff, string>
    {
        public string Resolve(Staff source, OstStaff destination, string destMember, ResolutionContext context)
        {
            return JsonConvert.SerializeObject(source.Permissions);
        }
    }
}
