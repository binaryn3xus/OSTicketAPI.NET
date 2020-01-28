using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSTicketAPI.NET.Tests.Attributes;
using OSTicketAPI.NET.Tests.Fixtures;
using Xunit;

namespace OSTicketAPI.NET.Tests.Repositories
{
    public class UserRepositoryTests : IClassFixture<ConfigurationFixture>
    {
        private readonly ConfigurationFixture _fixture;

        public UserRepositoryTests(ConfigurationFixture fixture)
        {
            _fixture = fixture;
        }

        [RunnableInDebugOnly]
        public async Task GetUsers_NotUsingAnExpression()
        {
            var forms = await _fixture.OSTicketService.Users.GetUsers().ConfigureAwait(false);
            Assert.NotEmpty(forms);
        }

        [RunnableInDebugOnly]
        public async Task GetUsers_UsingAnExpression()
        {
            var forms = await _fixture.OSTicketService.Users.GetUsers(o => o.OrgId == 1).ConfigureAwait(false);
            Assert.NotEmpty(forms);
        }

        [RunnableInDebugOnly]
        public async Task GetUserByEmail_ShouldReturnOneOstUser()
        {
            var userEmail = _fixture.OSTicketService.OstTicketContext.OstUser.Include(e => e.OstUserAccount).First()
                .OstUserEmail.Address;
            var userByEmail = await _fixture.OSTicketService.Users.GetUserByEmail(userEmail).ConfigureAwait(false);
            Assert.Equal(userEmail, userByEmail.Email);
        }

        [RunnableInDebugOnly]
        public async Task GetUserById_ShouldReturnOneOstUser()
        {
            var user = _fixture.OSTicketService.Users.GetUsers().Result.First();
            var userById = await _fixture.OSTicketService.Users.GetUserById(user.Id).ConfigureAwait(false);
            Assert.Equal(user.Id, userById.Id);
        }

        [RunnableInDebugOnly]
        public async Task GetUserByUsername_ShouldReturnOneOstUser()
        {
            var dbUsername = _fixture.OSTicketService.OstTicketContext.OstUser.Include(e=>e.OstUserAccount).First(e => e.OstUserAccount.Username != null)
                .OstUserAccount.Username;
            var userByUsername = await _fixture.OSTicketService.Users.GetUserByUsername(dbUsername).ConfigureAwait(false);
            Assert.Equal(dbUsername, userByUsername.Username);
        }
    }
}
