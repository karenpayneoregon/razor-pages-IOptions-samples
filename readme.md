# About

Learn how to fetch properties or values from appsettings.json in .NET Core. We’ll cover it using both IConfiguration and Options Pattern.

Code samples for reading from appsettings.json and is at this time a work in progress, all code works but lacking documentation at this time.

All projects are Razor Pages except one console project. The majority of work is done with dependency injection.

## Projects

- `VariousMethodsApplication` smorgasbord of code samples for obtaining information from appsettings.json
- `ConnectionStringApplication` is a simple example to get a connection string from appsettings.json for EF Core.
- `ControlLoggingApplication` Example to toggle SeriLog on/off via appsettings.json
- `DataAnnotatedValidationApplication` shows how to validate values in appsettings.json using Data Annotations validation in Program.cs
- `ReadListApplication` example for reading an array/list
- `ReadSettingsConsoleApplication` sinple console project for showing reading settings from appsettings.json
- `SectionExistsApplication` demonstrates how to check if a section exists in appsettings.json

## Secrets

See the following article [ASP.NET Core/Razor pages Secret Manager](https://dev.to/karenpayneoregon/aspnet-corerazor-pages-secret-manager-3183) with source code in the following [repository](https://github.com/karenpayneoregon/csharp-11-ef-core-7-features) in the following [project](https://github.com/karenpayneoregon/csharp-11-ef-core-7-features/tree/master/SecretManager1).

## Requires

- Microsoft Visual Studio 2022 or higher
- .NET Core 7

## What’s the difference between IOptionsMonitor vs. IOptionsSnapshot?
The major difference is the lifetime of these instances. IOptionsMonitor is registered as Singleton, whereas the IOptionsSnapshot is registered as Scoped.


-  Use IOptions, when you are not expecting your configuration values to change.
- Use IOptionsSnapshot when you expect your values to change, but want them to be uniform for the entire request cycle.
- Use IOptionsMonitor when you need real-time options data.

## Resources

- [Configuration in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0&viewFallbackFrom=aspnetcore-2.1)
- [Options pattern in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-7.0)
- [Use multiple environments in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-7.0&source=recommendations)