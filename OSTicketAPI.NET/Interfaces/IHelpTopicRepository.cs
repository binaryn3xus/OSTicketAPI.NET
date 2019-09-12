using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OSTicketAPI.NET.Interfaces
{
    public interface IHelpTopicRepository<T>
    {
        Task<IEnumerable<T>> GetHelpTopics(Expression<Func<T, bool>> expression = null);

        Task<T> GetHelpTopicsByTopicId(int topicId);

        Task<IEnumerable<T>> GetHelpTopicsByDepartmentId(int departmentId,
            Expression<Func<T, bool>> expression = null);
    }
}
