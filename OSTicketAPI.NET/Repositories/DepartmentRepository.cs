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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly OSTicketContext _osticketContext;
        private readonly ILog _logger = LogProvider.GetCurrentClassLogger();

        public DepartmentRepository(OSTicketContext osticketContext)
        {
            _osticketContext = osticketContext;
        }

        public async Task<OstDepartment> GetDepartmentById(int id)
        {
            var data = await GetQueryableDepartmentsAsync(o => o.Id == id).ConfigureAwait(false);
            var department = data.FirstOrDefault(o => o.Id == id);
            if (department != null)
                _logger.Debug("Found Department: '{TicketId}'", department.Name);
            return department;
        }

        public async Task<IEnumerable<OstDepartment>> GetDepartments(Expression<Func<OstDepartment, bool>> expression = null)
        {
            var data = await GetQueryableDepartmentsAsync(expression).ConfigureAwait(false);
            return data.ToList();
        }

        private async Task<IQueryable<OstDepartment>> GetQueryableDepartmentsAsync(Expression<Func<OstDepartment, bool>> expression)
        {
            var deptQuery = _osticketContext.OstDepartment
                .Include(o => o.OstStaff)
                .AsQueryable();

            if (expression != null)
                deptQuery = deptQuery.Where(expression);
            
            return deptQuery;
        }
    }
}
