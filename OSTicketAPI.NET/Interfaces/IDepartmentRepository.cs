using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OSTicketAPI.NET.Interfaces
{
    public interface IDepartmentRepository<T>
    {
        Task<IEnumerable<T>> GetDepartments(Expression<Func<T, bool>> expression = null);
        Task<T> GetDepartmentById(int id);
    }
}
