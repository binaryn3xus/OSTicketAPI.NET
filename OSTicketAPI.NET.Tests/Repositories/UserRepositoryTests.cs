using System.Linq;
using System.Threading.Tasks;
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
            var user = _fixture.OSTicketService.Users.GetUsers().Result.First();
            var userByEmail = await _fixture.OSTicketService.Users.GetUserByEmail(user.OstUserEmail.Address);
            Assert.Equal(user.OstUserEmail.Address, userByEmail.OstUserEmail.Address);
        }

        [RunnableInDebugOnly]
        public async Task GetUserById_ShouldReturnOneOstUser()
        {
            var user = _fixture.OSTicketService.Users.GetUsers().Result.First();
            var userById = await _fixture.OSTicketService.Users.GetUserById(user.Id);
            Assert.Equal(user.Id, userById.Id);
        }

        [RunnableInDebugOnly]
        public async Task GetUserByUsername_ShouldReturnOneOstUser()
        {
            var user = _fixture.OSTicketService.Users.GetUsers(o => o.OstUserAccount.Username != null).Result.First();
            var userByUsername = await _fixture.OSTicketService.Users.GetUserByUsername("GARRISJ");
            Assert.Equal(user.OstUserAccount.Username, userByUsername.OstUserAccount.Username);
        }
    }
}
