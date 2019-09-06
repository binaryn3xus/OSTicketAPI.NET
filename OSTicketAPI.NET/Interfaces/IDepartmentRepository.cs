using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OSTicketAPI.NET.Entities;

namespace OSTicketAPI.NET.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<OstDepartment>> GetDepartments(Expression<Func<OstDepartment, bool>> expression = null);
        Task<OstDepartment> GetDepartmentById(int id);
    }
}
