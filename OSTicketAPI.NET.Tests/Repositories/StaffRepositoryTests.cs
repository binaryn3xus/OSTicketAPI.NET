using System.Linq;
using System.Threading.Tasks;
using OSTicketAPI.NET.Tests.Attributes;
using OSTicketAPI.NET.Tests.Fixtures;
using Xunit;

namespace OSTicketAPI.NET.Tests.Repositories
{
    public class StaffRepositoryTests : IClassFixture<ConfigurationFixture>
    {
        private readonly ConfigurationFixture _fixture;

        public StaffRepositoryTests(ConfigurationFixture fixture)
        {
            _fixture = fixture;
        }

        [RunnableInDebugOnly]
        public async Task GetStaff_NotUsingAnExpression()
        {
            var staff = await _fixture.OSTicketService.Staff.GetStaff().ConfigureAwait(false);
            Assert.NotEmpty(staff);
        }

        [RunnableInDebugOnly]
        public async Task GetStaff_UsingAnExpression()
        {
            var staff = await _fixture.OSTicketService.Staff.GetStaff(o => o.DeptId == 1).ConfigureAwait(false);
            Assert.NotEmpty(staff);
        }

        [RunnableInDebugOnly]
        public async Task GetUserByEmail_ShouldReturnStaffMemberByEmailAddress()
        {
            var staffMember = _fixture.OSTicketService.Staff.GetStaff().Result.First();
            var staffMemberByEmail = await _fixture.OSTicketService.Staff.GetStaffByEmail(staffMember.Email);
            Assert.Equal(staffMember.Email, staffMemberByEmail.Email);
        }

        [RunnableInDebugOnly]
        public async Task GetUserById_ShouldReturnStaffMemberById()
        {
            var staffMember = _fixture.OSTicketService.Staff.GetStaff().Result.First();
            var staffMemberById = await _fixture.OSTicketService.Staff.GetStaffById(staffMember.StaffId);
            Assert.Equal(staffMember.Username, staffMemberById.Username);
        }

        [RunnableInDebugOnly]
        public async Task GetUserByUsername_ShouldReturnStaffMemberByUsername()
        {
            var staffMember = _fixture.OSTicketService.Staff.GetStaff().Result.First();
            var staffMemberByUsername = await _fixture.OSTicketService.Staff.GetStaffByUsername(staffMember.Username);
            Assert.Equal(staffMember.Username, staffMemberByUsername.Username);
        }
    }
}
