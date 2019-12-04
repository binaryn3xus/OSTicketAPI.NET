using System;
using Microsoft.Extensions.DependencyInjection;
using OSTicketAPI.NET.Tests.Attributes;
using OSTicketAPI.NET.Tests.Fixtures;
using Xunit;

namespace OSTicketAPI.NET.Tests
{
    public class ServicesConfigurationTests : IClassFixture<ConfigurationFixture>
    {
        private readonly ConfigurationFixture _fixture;

        public ServicesConfigurationTests(ConfigurationFixture fixture)
        {
            _fixture = fixture;
        }

        [RunnableInDebugOnly]
        public void TestServiceConfiguration_AddOSTicketServices_WithValidIConfiguration()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(_fixture.Configuration);
            serviceCollection.AddOSTicketServices();
            var servicesBuilt = serviceCollection.BuildServiceProvider();
            var osTicketService = servicesBuilt.GetService<OSTicketService>();
            Assert.NotNull(osTicketService);
        }

        [RunnableInDebugOnly]
        public void TestServiceConfiguration_AddOSTicketServices_WithCustomValidIConfiguration()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(_fixture.Configuration);
            serviceCollection.AddOSTicketServices(_fixture.Configuration.GetSection("Custom:OSTicket"));
            var servicesBuilt = serviceCollection.BuildServiceProvider();
            var osTicketService = servicesBuilt.GetService<OSTicketService>();
            Assert.NotNull(osTicketService);
        }

        [RunnableInDebugOnly]
        public void TestServiceConfiguration_AddOSTicketServices_ReturnExceptionForNullIConfiguration()
        {
            var serviceCollection = new ServiceCollection();
            Assert.Throws<ArgumentNullException>(() => serviceCollection.AddOSTicketServices());
        }

        [RunnableInDebugOnly]
        public void TestServiceConfiguration_AddOSTicketServices_ReturnExceptionForInvalidConfigurationSection()
        {
            var serviceCollection = new ServiceCollection();
            Assert.Throws<ArgumentNullException>(() => serviceCollection.AddOSTicketServices(_fixture.Configuration.GetSection("Invalid:OSTicket")));
        }

        [RunnableInDebugOnly]
        public void TestServiceConfiguration_AddOSTicketServices_WithSampleOptions()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOSTicketServices(options =>
            {
                options.ApiKey = "KEYEXAMPLE123";
                options.BaseUrl = "https://localhost/";
                options.ConnectionString = "datasource=fake;uid=none;password=none;";
            });
            var servicesBuilt = serviceCollection.BuildServiceProvider();
            var osTicketService = servicesBuilt.GetService<OSTicketService>();
            Assert.NotNull(osTicketService);
        }
    }
}
