using System;
using System.Linq;
using System.Threading.Tasks;
using OSTicketAPI.NET.Tests.Attributes;
using OSTicketAPI.NET.Tests.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace OSTicketAPI.NET.Tests.Repositories
{
    public class ListRepositoryTests : IClassFixture<ConfigurationFixture>
    {
        private readonly ConfigurationFixture _fixture;
        private readonly ITestOutputHelper _testOutputHelper;

        public ListRepositoryTests(ConfigurationFixture fixture, ITestOutputHelper testOutputHelper)
        {
            _fixture = fixture;
            _testOutputHelper = testOutputHelper;
        }

        [RunnableInDebugOnly]
        public async Task GetLists_NotUsingAnExpression()
        {
            var lists = await _fixture.OSTicketService.Lists.GetLists().ConfigureAwait(false);
            var ostLists = lists.ToList();
            foreach (var list in ostLists)
            {
                _testOutputHelper.WriteLine("\"{0}\" with the item names of \"{1}\"", list.Name,
                    string.Join(',', list.OstListItems?.Select(o => o.Value)));
            }

            Assert.NotEmpty(ostLists);
        }

        [RunnableInDebugOnly]
        public async Task GetLists_UsingAnExpression()
        {
            var lists = await _fixture.OSTicketService.Lists.GetLists(o => o.Type.Equals("ticket-status",StringComparison.OrdinalIgnoreCase)).ConfigureAwait(false);
            var ostLists = lists.ToList();
            foreach (var list in ostLists)
            {
                _testOutputHelper.WriteLine("\"{0}\" with the item names of \"{1}\"", list.Name,
                    string.Join(',', list.OstListItems?.Select(o => o.Value)));
            }

            Assert.NotEmpty(ostLists);
        }
    }
}
