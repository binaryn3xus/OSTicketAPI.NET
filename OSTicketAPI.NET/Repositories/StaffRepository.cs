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
    public class StaffRepository : IStaffRepository<Staff, OstStaff>
    {
        private readonly OSTicketContext _osticketContext;
        private readonly IMapper _mapper;
        private readonly ILog _logger = LogProvider.For<StaffRepository>();

        public StaffRepository(OSTicketContext osticketContext, IMapper mapper)
        {
            _osticketContext = osticketContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Get staff from OSTicket
        /// </summary>
        /// <param name="expression">Optional parameter to filter staff</param>
        /// <returns>Returns a collection of Staff</returns>
        public async Task<IEnumerable<Staff>> GetStaff(Expression<Func<OstStaff, bool>> expression = null)
        {
            var staff = await GetQueryableStaffMembersAsync(expression).ConfigureAwait(false);
            return staff.ToList();
        }

        /// <summary>
        /// Get a Staff member by email address
        /// </summary>
        /// <param name="email">Email Address</param>
        /// <returns>Returns an Staff object or null if staff member does not exist</returns>
        public async Task<Staff> GetStaffByEmail(string email)
        {
            var staffMembers = await GetQueryableStaffMembersAsync(o => o.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase)).ConfigureAwait(false);
            var staff = staffMembers.FirstOrDefault();

            if (staff != null)
                _logger.Debug("{Username} found using the email address of {EmailAddress}", staff.Username, email);
            else
                _logger.Warn("Unable to find a staff member with the email of {EmailAddress}", email);

            return staff;
        }

        /// <summary>
        /// Get a Staff member by Id
        /// </summary>
        /// <param name="id">Staff Member Id</param>
        /// <returns>Returns an Staff object or null if staff member does not exist</returns>
        public async Task<Staff> GetStaffById(int id)
        {
            var staffMembers = await GetQueryableStaffMembersAsync(o => o.StaffId == id).ConfigureAwait(false);
            var staff = staffMembers.FirstOrDefault();

            if (staff != null)
                _logger.Debug("{UserName} found using the Id of {UserId}", staff.Username, id);
            else
                _logger.Warn("Unable to find a staff member with the Id of {UserId}", id);

            return staff;
        }

        /// <summary>
        /// Get a staff member by username
        /// </summary>
        /// <param name="username">Required username of the staff member to retrieve</param>
        /// <returns>Returns an Staff object or null if the staff member does not exist</returns>
        public async Task<Staff> GetStaffByUsername(string username)
        {
            var staff = await GetQueryableStaffMembersAsync(o => o.Username.Equals(username, StringComparison.OrdinalIgnoreCase)).ConfigureAwait(false);

            var staffMember = staff.FirstOrDefault();
            if (staffMember != null)
                _logger.Debug("{UserName} found using the username of {Username}", staffMember.Username, username);
            else
                _logger.Warn("Unable to find a staff member with the username of {Username}", username);

            return staffMember;
        }

        private async Task<IQueryable<Staff>> GetQueryableStaffMembersAsync(Expression<Func<OstStaff, bool>> expression)
        {
            return await Task.Run(() =>
            {
                var query = _osticketContext.OstStaff
                    .Include(o=>o.OstStaffDepartmentAccess)
                    .AsQueryable();

                if (expression != null)
                    query = query.Where(expression);

                var staff = _mapper.Map<IEnumerable<Staff>>(query);

                return staff.AsQueryable();
            }).ConfigureAwait(false);
        }
    }
}
