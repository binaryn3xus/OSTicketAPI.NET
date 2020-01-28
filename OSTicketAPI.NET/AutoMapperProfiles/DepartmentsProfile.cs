using AutoMapper;
using OSTicketAPI.NET.Entities;
using OSTicketAPI.NET.Models;

namespace OSTicketAPI.NET.AutoMapperProfiles
{
    public class DepartmentsProfile : Profile
    {
        public DepartmentsProfile()
        {
            CreateMap<OstDepartment, Department>()
                .ForMember(dest => dest.StaffMembers, opt => opt.MapFrom(src => src.OstStaff))
                .ForMember(dest => dest.Manager, opt => opt.MapFrom(src => src.Manager))
                .ForAllOtherMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
