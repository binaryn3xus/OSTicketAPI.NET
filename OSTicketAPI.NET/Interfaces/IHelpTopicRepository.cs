using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OSTicketAPI.NET.Interfaces
{
    public interface IHelpTopicRepository<T, TExpression>
    {
        Task<IEnumerable<T>> GetHelpTopics(Expression<Func<TExpression, bool>> expression = null);

        Task<T> GetHelpTopicsByTopicId(int topicId);

        Task<IEnumerable<T>> GetHelpTopicsByDepartmentId(int departmentId);
    }
}
