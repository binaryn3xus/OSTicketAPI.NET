using System.Linq;
using OSTicketAPI.NET.Entities;
using OSTicketAPI.NET.Tests.Attributes;
using OSTicketAPI.NET.Tests.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace OSTicketAPI.NET.Tests.Repositories
{
    public class DepartmentRepositoryTests : IClassFixture<ConfigurationFixture>
    {
        private readonly ConfigurationFixture _fixture;
        private readonly ITestOutputHelper _testOutputHelper;

        public DepartmentRepositoryTests(ConfigurationFixture fixture, ITestOutputHelper testOutputHelper)
        {
            _fixture = fixture;
            _testOutputHelper = testOutputHelper;
        }

        [RunnableInDebugOnly]
        public void GetAllDepartments_ShouldReturnOneOrMoreDepartments()
        {
            var departments = _fixture.OSTicketService.Departments.GetDepartments().Result.ToList();
            foreach (var department in departments)
            {
                _testOutputHelper.WriteLine(department.Name);
                foreach (var staff in department.OstStaff)
                    _testOutputHelper.WriteLine("--{0}, {1}", staff.Lastname, staff.Firstname);
            }

            Assert.True(departments.Count > 0);
        }

        [RunnableInDebugOnly]
        public void GetDepartments_ShouldReturnADepartmentWithAValidManagerObject()
        {
            var departments = _fixture.OSTicketService.Departments.GetDepartments().Result.ToList();
            Assert.Equal(typeof(OstStaff),departments[0].Manager.GetType());
        }

        [RunnableInDebugOnly]
        public void GetDepartmentById_ShouldReturnANotNullDepartment()
        {
            var departments = _fixture.OSTicketService.Departments.GetDepartments().Result.ToList();
            var singleDepartment = _fixture.OSTicketService.Departments.GetDepartmentById(departments[0].Id).Result;
            Assert.NotNull(singleDepartment?.Name);
        }
    }
}
