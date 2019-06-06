# OSTicketAPI.NET

[![Build status](https://dev.azure.com/DotNetEvolved/OSTicketAPI.NET/_apis/build/status/OSTicketAPI.NET-ASP.NET%20Core-CI)](https://dev.azure.com/DotNetEvolved/OSTicketAPI.NET/_build/latest?definitionId=3) ![Azure DevOps builds](https://img.shields.io/azure-devops/build/dotnetevolved/a2092f90-85c9-4044-b29a-4a24109f72ee/3.svg) ![GitHub](https://img.shields.io/github/license/joshuagarrison27/osticketapi.net.svg?style=popout) ![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/OSTicketAPI.NET.svg?style=popout) ![GitHub contributors](https://img.shields.io/github/contributors/joshuagarrison27/OSTicketAPI.NET.svg?style=popout)

This project has been created to add more support for interfacing with OSTicket. The current web API provided my OSTicket is sufficient for submitting new Tickets. However, we found that we wanted to be able to do more with the data inside of OSTicket.

## __This project is currently incomplete and is available as a pre-release for testing and further development__

This project is build using `.Net Standard 2.0`

## Getting started

> This project is currently incomplete and is available for testing and further development

This .NET Library tries to make setup as painless as possible.

First, you want to update your `appsettings.json` to include the appropriate configuration.

~~~
{
    "OSTicket": {
        "BaseUrl": "https://YourOSTicketInstance.net/",
        "ApiKey": "__YourOSTicketApiKey__",
        "DatabaseConnectionString": "server=SERVERNAME;uid=USERID;pwd=PASSWORD;database=osticket;Convert Zero Datetime=True"
    }
}
~~~

> Note: It is recommended to leave the `Convert Zero Date` as true.

Add the following to your .Net Core `startup.cs` file in the `ConfigureServices`

~~~
services.AddOSTicketServices();
~~~

Its __Important__ to remember that you need to have the OSTicket configuration in the root off your `appsettings.json` because that is where this helper expects it to be.

However, if you want to embed your setting in a deeper part of your appsettings or get your settings from somewhere else entirely, then you will have to initialize the [`OSTicketInstance`](OSTicketAPI.NET/OSTicketInstance.cs) class yourself.


## Q/A

##### Why do I need an API key if we are accessing the database directly?

When you are creating a new ticket using the official API, all the approrpriate triggers for emails and notifications will be sent as well. If we just manually inject those records into the database, then these triggers would never occur.
