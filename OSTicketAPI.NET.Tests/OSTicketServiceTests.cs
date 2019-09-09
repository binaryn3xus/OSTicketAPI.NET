using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OSTicketAPI.NET.DTO;
using OSTicketAPI.NET.Entities;
using OSTicketAPI.NET.Tests.Attributes;
using Xunit;
using Xunit.Abstractions;

namespace OSTicketAPI.NET.Tests
{
    public class OSTicketServiceTests
    {
        private IConfiguration Configuration { get; }
        private readonly OSTicketService _osTicketService;
        private readonly ITestOutputHelper _testOutputHelper;

        public OSTicketServiceTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            Configuration = new ConfigurationBuilder()
                .AddUserSecrets<OSTicketServiceTests>()
                .Build();

            var apiKey = Configuration.GetValue<string>("OSTicket:ApiKey");
            var databaseConnectionString = Configuration.GetValue<string>("OSTicket:DatabaseConnectionString");
            var baseUrl = Configuration.GetValue<string>("OSTicket:BaseUrl");

            if(!string.IsNullOrEmpty(databaseConnectionString) && (!string.IsNullOrWhiteSpace(baseUrl) || !string.IsNullOrWhiteSpace(apiKey)))
                _osTicketService = new OSTicketService(databaseConnectionString, new OSTicketOfficialApi(baseUrl, apiKey));
        }

        [Fact]
        public void ErrorIfConnectionStringIsNull()
        {
            Assert.Throws<ArgumentException>(() => new OSTicketService(null, null));
        }

        [Fact]
        public void ErrorIfAnyDatabaseParametersAreNull()
        {
            Assert.Throws<ArgumentException>(() => new OSTicketService(null, "username", "password", "databaseName", null));
            Assert.Throws<ArgumentException>(() => new OSTicketService("database", null, "password", "databaseName", null));
            Assert.Throws<ArgumentException>(() => new OSTicketService("database", "username", null, "databaseName", null));
            Assert.Throws<ArgumentException>(() => new OSTicketService("database", "username", "password", null, null));
        }

        #region EnvironmentalDebugTests

        [RunnableInDebugOnly]
        public void ShouldBeAbleToGetAllTickets()
        {
            var tickets = _osTicketService.Tickets.GetTickets().Result.ToList();
            _testOutputHelper.WriteLine("Current ticket count: {0}", tickets);
            Assert.True(tickets.Count > 0);
        }

        [RunnableInDebugOnly]
        public void ShouldBeAbleToGetAllTicketStatuses()
        {
            var ticketStatuses = _osTicketService.Tickets.GetTicketStatuses().Result;
            Assert.NotNull(ticketStatuses);
        }

        [RunnableInDebugOnly]
        public void DepartmentsRepository_GetAllDepartments()
        {
            var departments = _osTicketService.Departments.GetDepartments().Result.ToList();
            foreach (var department in departments)
            {
                _testOutputHelper.WriteLine(department.Name);
                foreach(var staff in department.OstStaff)
                    _testOutputHelper.WriteLine("--{0}, {1}",staff.Lastname, staff.Firstname);
            }

            Assert.True(departments.Count > 0);
        }

        [RunnableInDebugOnly]
        public void DepartmentsRepository_ReturnsManagerObject()
        {
            var departments = _osTicketService.Departments.GetDepartments().Result.ToList();
            Assert.Equal(typeof(OstStaff), departments.First().Manager.GetType());
        }

        [RunnableInDebugOnly]
        public void DepartmentsRepository_GetDepartmentById()
        {
            var departments = _osTicketService.Departments.GetDepartments().Result.ToList();
            var singleDepartment = _osTicketService.Departments.GetDepartmentById(departments.First().Id).Result;
            Assert.NotNull(singleDepartment?.Name);
        }

        [RunnableInDebugOnly]
        public void TestServiceConfiguration_AddOSTicketServices_WithValidIConfiguration()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(Configuration);
            serviceCollection.AddOSTicketServices();
            var servicesBuilt = serviceCollection.BuildServiceProvider();
            var osTicketService = servicesBuilt.GetService<OSTicketService>();
            Assert.NotNull(osTicketService);
        }

        [RunnableInDebugOnly]
        public void TestServiceConfiguration_AddOSTicketServices_ReturnException()
        {
            var serviceCollection = new ServiceCollection();
            Assert.Throws<Exception>(() => serviceCollection.AddOSTicketServices());
        }

        [RunnableInDebugOnly]
        public void TestServiceConfiguration_AddOSTicketServices_WithSampleOptions()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOSTicketServices(new OSTicketServiceOptions()
            {
                ApiKey = "KEYEXAMPLE123",
                BaseUrl = "https://localhost/",
                ConnectionString = "datasource=fake;uid=none;password=none;"
            });
            var servicesBuilt = serviceCollection.BuildServiceProvider();
            var osTicketService = servicesBuilt.GetService<OSTicketService>();
            Assert.NotNull(osTicketService);
        }

        #endregion
    }
}
