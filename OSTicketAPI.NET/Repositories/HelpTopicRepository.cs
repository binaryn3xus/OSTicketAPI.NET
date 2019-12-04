using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OSTicketAPI.NET.Entities;
using OSTicketAPI.NET.Interfaces;
using OSTicketAPI.NET.Logging;
using OSTicketAPI.NET.Models;

namespace OSTicketAPI.NET.Repositories
{
    public class HelpTopicRepository : IHelpTopicRepository<HelpTopic, OstHelpTopic>
    {
        private readonly OSTicketContext _osticketContext;
        private readonly IMapper _mapper;
        private readonly ILog _logger = LogProvider.For<HelpTopicRepository>();

        public HelpTopicRepository(OSTicketContext osticketContext, IMapper mapper)
        {
            _osticketContext = osticketContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Help Topics from OSTicket
        /// </summary>
        /// <param name="expression">Parameter expression is optional. Default value is null, if not provided.</param>
        /// <returns>Returns an IEnumerable of OstForm that matches the expression</returns>
        public async Task<IEnumerable<HelpTopic>> GetHelpTopics(Expression<Func<OstHelpTopic, bool>> expression = null)
        {
            try
            {
                var topics = await GetQueryableHelpTopicsAsync(expression).ConfigureAwait(false);
                if (topics.Any())
                    _logger.Debug("Found {TopicCount} topics", topics.Count());
                return topics;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Get a Help Topic by it's Id
        /// </summary>
        /// <param name="topicId">A required parameter of the Help Topic's Id</param>
        /// <returns>Returns an OstHelpTopic object</returns>
        public async Task<HelpTopic> GetHelpTopicsByTopicId(int topicId)
        {
            var topics = await GetQueryableHelpTopicsAsync(o => o.TopicId == topicId).ConfigureAwait(false);
            var topic = topics.FirstOrDefault(o => o.TopicId == topicId);
            _logger.Debug("Topic Id: {TopicId} (Found: {FoundStatus})", topicId, topic != null);
            return topic;
        }

        /// <summary>
        /// Get all Help Topics based on a certain Department
        /// </summary>
        /// <param name="departmentId">Id of the Department</param>
        /// <param name="expression">Optional expression to be used if you want to narrow down the results more</param>
        /// <returns>Return an IEnumerable of OstHelpTopics that first matches Department Id then an expression, if provided</returns>
        public async Task<IEnumerable<HelpTopic>> GetHelpTopicsByDepartmentId(int departmentId)
        {
            var topics = await GetQueryableHelpTopicsAsync(o => o.DeptId == departmentId).ConfigureAwait(false);

            _logger.Debug("{NumberOfTopicsFound} topics found for Department Id {DepartmentId}", topics.Count(), departmentId);
            return topics;
        }

        private async Task<IQueryable<HelpTopic>> GetQueryableHelpTopicsAsync(Expression<Func<OstHelpTopic, bool>> expression)
        {
            return await Task.Run(() =>
            {
                var query = _osticketContext.OstHelpTopic
                    .Include(o => o.HelpTopicForms)
                    .ThenInclude(o => o.OstForm)
                    .ThenInclude(o => o.OstFormFields)
                    .AsQueryable();

                if (expression != null)
                    query = query.Where(expression);

                var mappedQuery = _mapper.Map<IEnumerable<OstHelpTopic>, IEnumerable<HelpTopic>>(query);

                return mappedQuery.AsQueryable();
            }).ConfigureAwait(false);
        }
    }
}
