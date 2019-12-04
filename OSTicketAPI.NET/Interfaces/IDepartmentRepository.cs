using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OSTicketAPI.NET.Interfaces
{
    public interface IDepartmentRepository<T, TExpression>
    {
        Task<IEnumerable<T>> GetDepartments(Expression<Func<TExpression, bool>> expression = null);
        Task<T> GetDepartmentById(int id);
    }
}
