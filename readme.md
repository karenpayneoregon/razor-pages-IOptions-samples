# Storing and reading values from appsettings.json code samples

Learn how to fetch properties or values from **appsettings.json** in **.NET Core** Razor Pages and console projects, using both IConfiguration and Options Patterns.

All projects are Razor Pages except one console project. The majority of work is done with dependency injection.

> **Warning**
> This article is not a step-by-step on how to work with appsettings.json so if that is what you are looking for you may be disappointed. The intent is to provide working code samples to learn from.

## First steps

- If you are new to dependency injection see [Dependency injection in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-7.0&source=recommendations)
- Decide what to place in appsettings.json
- Do the values change will determine which interface to use.
- Examine include soure code
- Read Microsoft documentation, see the resource section at end of this article.
- Get stuck, ask on [Stackoverflow](https://stackoverflow.com/questions/tagged/appsettings)

## What not to store

- User names and passwords
- Any sensitive information that may compromise data and/or the company. This may also include connection strings to databases unless protected by a DMZ for instance.

## Not included

Working with [vaults](https://learn.microsoft.com/en-us/aspnet/core/security/key-vault-configuration?view=aspnetcore-7.0) and different environments.

## Enviroments

For working with different environments see [Use multiple environments in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-7.0&source=recommendations) which will assist a developer learning how to work with multiple environments. I see no reason to repeat good documentation.

Also see project EnvironmentApplication


## Projects

Take time to review these projects, more likely than not there will be a solution to what a developer needs to store and read data.


- `VariousMethodsApplication` smorgasbord of code samples for obtaining information from appsettings.json
    - **Index page**: demonstrates how to read nested sections using `IOptions` and `IOptionsSnapshot`
    - **ApplicationFeaturesLoose page**: demonstrates [IConfiguration.Bind](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.configurationbinder.bind?view=dotnet-plat-ext-7.0) while in `ApplicationFeaturesStrong` the same section is accessed using `IOptionsSnapshot` which is a better option if the application needs to get fresh values if the appsetting.json file changes.
    - **GetSectionExample page**: provides sample code to read a section in appsettings.json
    - **NamedOption page** variations on the Index Page
    - **OptionsMonitorExample page** [IOptionsMonitor](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptionsmonitor-1?view=dotnet-plat-ext-7.0) code sample. Note there seems to be issues with the [OnChange](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptionsmonitor-1.onchange?view=dotnet-plat-ext-7.0#microsoft-extensions-options-ioptionsmonitor-1-onchange(system-action((-0-system-string)))) event.
- `ConnectionStringApplication` is a simple example to get a connection string from appsettings.json for EF Core and using a data provider, in this case Microsoft.Data.SqlClient.
- `ControlLoggingApplication` Example to toggle SeriLog on/off via appsettings.json
- `DataAnnotatedValidationApplication` shows how to validate values in appsettings.json using Data Annotations validation in Program.cs
- `ReadListApplication` example for reading an array/list
- `ReadSettingsConsoleApplication` sinple console project for showing reading settings from appsettings.json
- `SectionExistsApplication` demonstrates how to check if a section exists in appsettings.json
- `EnvironmentApplication` demonstrates reading a connection string dependent on the current environment.
- `UpdaterApplication` how to update appsettings.json at runtime
- `GetWebAddressesApplication` the idea is to show a developer might store web addresses for services in appsettings.json
- `ExcelConnectionApplication` demonstrates how to read a connection string for Excel from appsettings.json

## Secrets

See the following article [ASP.NET Core/Razor pages Secret Manager](https://dev.to/karenpayneoregon/aspnet-corerazor-pages-secret-manager-3183) with source code in the following [repository](https://github.com/karenpayneoregon/csharp-11-ef-core-7-features) in the following [project](https://github.com/karenpayneoregon/csharp-11-ef-core-7-features/tree/master/SecretManager1).

## Requires

- Microsoft Visual Studio 2022 or higher
- .NET Core 8

## What’s the difference between IOptionsMonitor vs. IOptionsSnapshot?
The major difference is the lifetime of these instances. IOptionsMonitor is registered as Singleton, whereas the IOptionsSnapshot is registered as Scoped.


-  Use IOptions, when you are not expecting your configuration values to change.
- Use IOptionsSnapshot when you expect your values to change, but want them to be uniform for the entire request cycle.
- Use IOptionsMonitor when you need real-time options data.

## Resources

- [Configuration in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0&viewFallbackFrom=aspnetcore-2.1)
- [Options pattern in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-7.0)
- [Use multiple environments in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-7.0&source=recommendations)
- [Get started with Razor Pages in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-7.0&tabs=visual-studio)


## Source code

Clone the following [GitHub repository](https://github.com/karenpayneoregon/razor-pages-IOptions-samples).

## Article

https://dev.to/karenpayneoregon/storing-and-reading-values-from-appsettingsjson-io