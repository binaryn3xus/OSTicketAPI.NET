using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OSTicketAPI.NET.Interfaces
{
    public interface IListRepository<T>
    {
        Task<IEnumerable<T>> GetLists(Expression<Func<T, bool>> expression = null);
    }
}
