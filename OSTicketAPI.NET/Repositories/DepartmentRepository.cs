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
    public class DepartmentRepository : IDepartmentRepository<OstDepartment>
    {
        private readonly OSTicketContext _osticketContext;
        private readonly ILog _logger = LogProvider.GetCurrentClassLogger();

        public DepartmentRepository(OSTicketContext osticketContext)
        {
            _osticketContext = osticketContext;
        }

        /// <summary>
        /// Returns all departments from OSTicket
        /// </summary>
        /// <param name="expression">An optional expression for narrowing the search for departments</param>
        /// <returns>Returns an IEnumerable of OStDepartment objects</returns>
        public async Task<IEnumerable<OstDepartment>> GetDepartments(Expression<Func<OstDepartment, bool>> expression = null)
        {
            var data = await GetQueryableDepartmentsAsync(expression).ConfigureAwait(false);
            return data.ToList();
        }

        /// <summary>
        /// Get a department by the department's Id
        /// </summary>
        /// <param name="id">A required integer value for the Department</param>
        /// <returns>Returns an OstDepartment or a null value if nothing is found</returns>
        public async Task<OstDepartment> GetDepartmentById(int id)
        {
            var data = await GetQueryableDepartmentsAsync(o => o.Id == id).ConfigureAwait(false);
            var department = data.FirstOrDefault(o => o.Id == id);
            if (department != null)
                _logger.Debug("Found Department: '{TicketId}'", department.Name);
            return department;
        }

        private async Task<IQueryable<OstDepartment>> GetQueryableDepartmentsAsync(Expression<Func<OstDepartment, bool>> expression)
        {
            return await Task.Run(() =>
            {
                var deptQuery = _osticketContext.OstDepartment
                .Include(o => o.OstStaff)
                .AsQueryable();

                if (expression != null)
                    deptQuery = deptQuery.Where(expression);

                return deptQuery;
            }).ConfigureAwait(false);
        }
    }
}
