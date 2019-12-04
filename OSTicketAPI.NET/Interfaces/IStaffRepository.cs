using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OSTicketAPI.NET.Interfaces
{
    public interface IStaffRepository<T, TExpression>
    {
            Task<IEnumerable<T>> GetStaff(Expression<Func<TExpression, bool>> expression = null);
            Task<T> GetStaffById(int id);
            Task<T> GetStaffByEmail(string email);
            Task<T> GetStaffByUsername(string username);
    }
}
