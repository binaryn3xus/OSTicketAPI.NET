using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSTicketAPI.NET.Entities;
using OSTicketAPI.NET.Interfaces;
using OSTicketAPI.NET.Logging;

namespace OSTicketAPI.NET.Repositories
{
    public class HelpTopicsRepository : IHelpTopicsRepository
    {
        private readonly OSTicketContext _osticketContext;
        private readonly ILog _logger = LogProvider.For<HelpTopicsRepository>();

        public HelpTopicsRepository(OSTicketContext osticketContext)
        {
            _osticketContext = osticketContext;
        }

        public async Task<IEnumerable<OstHelpTopic>> GetHelpTopics(bool onlyPublicTopic = true)
        {
            var topics = _osticketContext.OstHelpTopic.AsQueryable();

            if (!onlyPublicTopic)
                topics = topics.Where(o => o.Ispublic == 1);

            var topicsList = await topics.ToListAsync().ConfigureAwait(false);

            if (topicsList != null)
                _logger.Debug("Found {TopicCount} topics", topicsList.Count);

            return topicsList;
        }

        public async Task<OstHelpTopic> GetHelpTopicsByTopicId(int topicId, bool onlyPublicTopic = true)
        {
            var topics = _osticketContext.OstHelpTopic.AsQueryable();

            if (!onlyPublicTopic)
                topics = topics.Where(o => o.Ispublic == 1);

            var topic = await topics.FirstOrDefaultAsync(o => o.TopicId == topicId).ConfigureAwait(false);

            if (topic != null)
                _logger.Debug("Found \"{TopicName}\" using Topic Id {TopicId}", topic.Topic, topicId);

            return topic;
        }

        public async Task<IEnumerable<OstHelpTopic>> GetHelpTopicsByDepartmentId(int departmentId, bool onlyPublicTopic = true)
        {
            var topics = _osticketContext.OstHelpTopic.AsQueryable();

            if (!onlyPublicTopic)
                topics = topics.Where(o => o.Ispublic == 1);

            var topicsByDepartment =
                await topics.Where(o => o.DeptId == departmentId).ToListAsync().ConfigureAwait(false);

            _logger.Debug("Found {TopicCount} topics for Department Id {DepartmentId}", topicsByDepartment.Count, departmentId);

            return topicsByDepartment;
        }
    }
}
