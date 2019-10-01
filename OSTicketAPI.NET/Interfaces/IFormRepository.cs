using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OSTicketAPI.NET.Entities;

namespace OSTicketAPI.NET.Interfaces
{
    public interface IFormRepository<T>
    {
        Task<IEnumerable<T>> GetForms(Expression<Func<T, bool>> expression = null);
        Task<T> GetFormById(int id);
        Task<IEnumerable<OstFormEntry>> GetFormEntries(Expression<Func<OstFormEntry, bool>> expression = null);
    }
}
