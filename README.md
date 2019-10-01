# OSTicketAPI.NET

[![.NETStandard2.0](https://img.shields.io/badge/.NET%20Standard-2.0-blueviolet)](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) [![Build status](https://dev.azure.com/DotNetEvolved/OSTicketAPI.NET/_apis/build/status/OSTicketAPI.NET-ASP.NET%20Core-CI)](https://dev.azure.com/DotNetEvolved/OSTicketAPI.NET/_build/latest?definitionId=3) ![Azure DevOps builds](https://img.shields.io/azure-devops/build/dotnetevolved/a2092f90-85c9-4044-b29a-4a24109f72ee/3.svg) ![GitHub](https://img.shields.io/github/license/joshuagarrison27/osticketapi.net.svg?style=popout) ![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/OSTicketAPI.NET.svg?style=popout) ![GitHub contributors](https://img.shields.io/github/contributors/joshuagarrison27/OSTicketAPI.NET.svg?style=popout)

This project has been created to add more support for interfacing with OSTicket. The current web API provided by OSTicket is sufficient for submitting new Tickets. However, we found that we wanted to be able to do more with the data inside of OSTicket.

__This project is a work in progress__


## Getting started

> This project is currently incomplete and is available for testing and further development

This library tries to make setup as painless as possible. Use the options that best fits your application.

#### Option 1 - Using AppSettings.json

Update your `appsettings.json` to include the appropriate configuration.

~~~
{
    "OSTicket": {
        "BaseUrl": "https://YourOSTicketInstance.net/",
        "ApiKey": "__YourOSTicketApiKey__",
        "DatabaseConnectionString": "server=SERVERNAME;uid=USERID;pwd=PASSWORD;database=osticket;Convert Zero Datetime=True"
    }
}
~~~

> Note: This library enforces the use of these connection string flags: `ConvertZeroDateTime=True;TreatTinyAsBoolean=false`. Be aware they are automatically added for you or changed to these values even if you attempt to provide different flag values.

Add the following to your .Net Core `startup.cs` file in the `ConfigureServices`

~~~
services.AddOSTicketServices();
~~~

Its __Important__ to remember that this library assumes that the OSTicket configuration is in the root of your `appsettings.json` by default.

If you choose to not have the your `OSTicket` configurations at the root of your appsettings.json then you need to provide the location using the following method:

```
serviceCollection.AddOSTicketServices(configuration.GetSection("YourCustomLocation:OSTicket"));
```

#### Option 2 - Defining values outside of appsettings.json

You can also provide your own values outside of using appsettings.json if you want to provide them using some other method.

```
serviceCollection.AddOSTicketServices(options =>
{
    options.ApiKey = "KEYEXAMPLE123";
    options.BaseUrl = "https://localhost/";
    options.ConnectionString = "datasource=fake;uid=none;password=none;";
});
```

#### Option 3 - Create the raw OSTicketService object

In the event that you dont want to use one of the other methods available, you can simply initialize the `OSTicketService` yourself.

```
new OSTicketService(DatabaseConnectionString,
    new OSTicketOfficialApi(BaseUrl, ApiKey))
```

*Remember to add it to your dependancy injection if you are using it*

## Q/A

##### Why do I need an API key if we are accessing the database directly?

When you are creating a new ticket using the official API, all the approrpriate triggers for emails and notifications will be sent as well. If we just manually inject those records into the database, then these triggers would never occur.

##### What versions of OSTicket does this work on?

It has been tested on the versions listed below:

| osTicket Version | osTicket Commit |
| --- | ----------- |
| v1.12 | a076918 |
| v1.12.2 | a5d898b |
