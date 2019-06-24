using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OSTicketAPI.NET.Entities;

namespace OSTicketAPI.NET.Interfaces
{
    public interface IHelpTopicsRepository
    {
        Task<IEnumerable<OstHelpTopic>> GetHelpTopics(bool onlyPublicTopic = true);
        Task<OstHelpTopic> GetHelpTopicsByTopicId(int topicId, bool onlyPublicTopic = true);
        Task<IEnumerable<OstHelpTopic>> GetHelpTopicsByDepartmentId(int departmentId, bool onlyPublicTopic = true);
    }
}
