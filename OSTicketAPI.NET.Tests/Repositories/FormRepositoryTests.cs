using System.Linq;
using System.Threading.Tasks;
using OSTicketAPI.NET.Tests.Attributes;
using OSTicketAPI.NET.Tests.Fixtures;
using Xunit;

namespace OSTicketAPI.NET.Tests.Repositories
{
    public class FormRepositoryTests : IClassFixture<ConfigurationFixture>
    {
        private readonly ConfigurationFixture _fixture;

        public FormRepositoryTests(ConfigurationFixture fixture)
        {
            _fixture = fixture;
        }

        [RunnableInDebugOnly]
        public void FormsRepository_GetForms_UsingAnExpression()
        {
            var forms = _fixture.OSTicketService.Forms.GetForms(o => o.Flags.Equals(1)).Result.ToList();
            Assert.NotEmpty(forms);
        }

        [RunnableInDebugOnly]
        public async Task FormsRepository_GetFormById_ShouldReturnAFormObject()
        {
            var form = await _fixture.OSTicketService.Forms.GetFormById(2).ConfigureAwait(false);
            Assert.NotNull(form);
        }

        [RunnableInDebugOnly]
        public async Task FormsRepository_GetFormById_ShouldReturnANullValue()
        {
            var form = await _fixture.OSTicketService.Forms.GetFormById(int.MaxValue).ConfigureAwait(false);
            Assert.Null(form);
        }

        [RunnableInDebugOnly]
        public async Task FormsRepository_GetFormEntries_ShouldReturnSomeEntries()
        {
            var form = await _fixture.OSTicketService.Forms.GetFormEntries(o => o != null).ConfigureAwait(false);
            Assert.NotEmpty(form);
        }
    }
}
