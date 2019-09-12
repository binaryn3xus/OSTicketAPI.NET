using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OSTicketAPI.NET.Interfaces
{
    public interface IFormRepository<T>
    {
        Task<IEnumerable<T>> GetForms(Expression<Func<T, bool>> expression = null);
        Task<T> GetFormById(int id);
    }
}
