using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSTicketAPI.NET.Entities;
using OSTicketAPI.NET.Interfaces;
using OSTicketAPI.NET.Logging;

namespace OSTicketAPI.NET.Repositories
{
    public class ListRepository : IListRepository<OstList>
    {
        private readonly OSTicketContext _osticketContext;
        private readonly ILog _logger = LogProvider.For<HelpTopicRepository>();

        public ListRepository(OSTicketContext osticketContext)
        {
            _osticketContext = osticketContext;
        }

        //TODO: Ticket-status does not have OstTicketItems, instead it has its own table.
        //TODO: Get properties for each list item
        public async Task<IEnumerable<OstList>> GetLists(Expression<Func<OstList, bool>> expression = null)
        {
            return await GetQueryableListsAsync().ConfigureAwait(false);
        }

        private async Task<IQueryable<OstList>> GetQueryableListsAsync(Expression<Func<OstList, bool>> expression = null)
        {
            return await Task.Run(() =>
            {
                var query = _osticketContext.OstList
                    .Include(o=>o.OstListItems)
                    .AsQueryable();

                if (expression != null)
                    query = query.Where(expression);

                return query;
            }).ConfigureAwait(false);
        }
    }
}
