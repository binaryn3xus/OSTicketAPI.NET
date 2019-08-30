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

            return await topics.ToListAsync().ConfigureAwait(false);
        }

        public async Task<OstHelpTopic> GetHelpTopicsByTopicId(int topicId, bool onlyPublicTopic = true)
        {
            var topics = _osticketContext.OstHelpTopic.AsQueryable();

            if (!onlyPublicTopic)
                topics = topics.Where(o => o.Ispublic == 1);

            return await topics.FirstOrDefaultAsync(o => o.TopicId == topicId).ConfigureAwait(false);
        }

        public async Task<IEnumerable<OstHelpTopic>> GetHelpTopicsByDepartmentId(int departmentId, bool onlyPublicTopic = true)
        {
            var topics = _osticketContext.OstHelpTopic.AsQueryable();

            if (!onlyPublicTopic)
                topics = topics.Where(o => o.Ispublic == 1);

            return await topics.Where(o => o.DeptId == departmentId).ToListAsync().ConfigureAwait(false);
        }
    }
}
