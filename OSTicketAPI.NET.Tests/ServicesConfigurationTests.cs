using System;
using Microsoft.Extensions.DependencyInjection;
using OSTicketAPI.NET.DTO;
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
    }
}
