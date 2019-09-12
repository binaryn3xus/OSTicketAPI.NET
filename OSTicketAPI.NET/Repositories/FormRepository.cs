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
    public class FormRepository : IFormRepository<OstForm>
    {
        private readonly OSTicketContext _osticketContext;
        private readonly ILog _logger = LogProvider.GetCurrentClassLogger();

        public FormRepository(OSTicketContext osticketContext)
        {
            _osticketContext = osticketContext;
        }

        /// <summary>
        /// Get all forms available in OSTicket based on an expression
        /// </summary>
        /// <param name="expression">Parameter expression is optional. Default value is null, if not provided.</param>
        /// <returns>Returns an IEnumerable of OstForm that matches the expression</returns>
        public async Task<IEnumerable<OstForm>> GetForms(Expression<Func<OstForm, bool>> expression = null)
        {
            if (expression == null)
                expression = (o => o.Flags != 3);
            var data = await GetQueryableFormsAsync(expression).ConfigureAwait(false);
            _logger.Debug("GetForms: Returning {0} OstForms", data.Count());
            return data.ToList();
        }

        /// <summary>
        /// Get an OSTicket Form object by using the form's Id.
        /// </summary>
        /// <param name="id">Parameter id requires an integer argument</param>
        /// <returns>The method returns an OstForm or NULL if no form exists.</returns>
        public async Task<OstForm> GetFormById(int id)
        {
            var data = await GetQueryableFormsAsync(o => o.Id == id).ConfigureAwait(false);
            var returnData = data?.FirstOrDefault();
            _logger.Debug("GetFormsById: Found = {0} {1}",
                data != null,
                returnData != null ? $"({returnData})" : "");
            return data?.FirstOrDefault();
        }

        /// <summary>
        /// A private method for getting OstForm objects and related objects
        /// </summary>
        /// <param name="expression">An expression to narrow down the search for OstForm objects</param>
        /// <returns>Returns a queryable object of OstForm objects</returns>
        private async Task<IQueryable<OstForm>> GetQueryableFormsAsync(Expression<Func<OstForm, bool>> expression)
        {
            return await Task.Run(() =>
            {
                var query = _osticketContext.OstForm
                    .Include(o => o.OstFormFields)
                    .AsQueryable();

                if (expression != null)
                    query = query.Where(expression);

                return query;
            }).ConfigureAwait(false);
        }
    }
}
