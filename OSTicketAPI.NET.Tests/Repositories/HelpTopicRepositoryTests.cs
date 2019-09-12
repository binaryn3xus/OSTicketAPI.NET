using System.Linq;
using System.Threading.Tasks;
using OSTicketAPI.NET.Tests.Attributes;
using OSTicketAPI.NET.Tests.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace OSTicketAPI.NET.Tests.Repositories
{
    public class HelpTopicRepositoryTests : IClassFixture<ConfigurationFixture>
    {
        private readonly ConfigurationFixture _fixture;
        private readonly ITestOutputHelper _testOutputHelper;

        public HelpTopicRepositoryTests(ConfigurationFixture fixture, ITestOutputHelper testOutputHelper)
        {
            _fixture = fixture;
            _testOutputHelper = testOutputHelper;
        }

        [RunnableInDebugOnly]
        public async Task GetHelpTopics_ShouldReturnOneOrMoreHelpTopicsAsync()
        {
            var data = await _fixture.OSTicketService.HelpTopics.GetHelpTopics().ConfigureAwait(false);
            var ostHelpTopics = data.ToList();
            foreach (var topic in ostHelpTopics)
            {
                _testOutputHelper.WriteLine(topic.Topic);
            }
            Assert.True(ostHelpTopics.Count > 0);
        }

        [RunnableInDebugOnly]
        public async Task GetHelpTopicsByTopicId_ShouldReturnOneHelpTopic()
        {
            var data = await _fixture.OSTicketService.HelpTopics.GetHelpTopicsByTopicId(1).ConfigureAwait(false);
            Assert.NotNull(data);
        }

        [RunnableInDebugOnly]
        public async Task GetHelpTopicsByTopicId_ShouldReturnNullForInvalidIds()
        {
            var data = await _fixture.OSTicketService.HelpTopics.GetHelpTopicsByTopicId(int.MaxValue).ConfigureAwait(false);
            Assert.Null(data);
        }

        [RunnableInDebugOnly]
        public async Task GetHelpTopicsByDepartmentId_ShouldReturnOneOrMoreHelpTopics_NotUsingExpression()
        {
            var departments = await _fixture.OSTicketService.Departments.GetDepartments().ConfigureAwait(false);
            var data = await _fixture.OSTicketService.HelpTopics.GetHelpTopicsByDepartmentId(departments.First().Id).ConfigureAwait(false);
            Assert.True(data.Any());
        }

        [RunnableInDebugOnly]
        public async Task GetHelpTopicsByDepartmentId_ShouldReturnOneOrMoreHelpTopics_UsingExpression()
        {
            var departments = await _fixture.OSTicketService.Departments.GetDepartments().ConfigureAwait(false);
            var data = await _fixture.OSTicketService.HelpTopics.GetHelpTopicsByDepartmentId(departments.First().Id, o => o.Flags == 2).ConfigureAwait(false);
            Assert.True(data.Any());
        }

        [RunnableInDebugOnly]
        public async Task GetHelpTopicsByDepartmentId_ShouldReturnNone_NotUsingExpression()
        {
            var data = await _fixture.OSTicketService.HelpTopics.GetHelpTopicsByDepartmentId(int.MaxValue).ConfigureAwait(false);
            Assert.False(data.Any());
        }

        [RunnableInDebugOnly]
        public async Task GetHelpTopicsByDepartmentId_ShouldReturnNone_UsingExpression()
        {
            var data = await _fixture.OSTicketService.HelpTopics.GetHelpTopicsByDepartmentId(int.MaxValue, o => o.Flags == 4).ConfigureAwait(false);
            Assert.False(data.Any());
        }
    }
}
