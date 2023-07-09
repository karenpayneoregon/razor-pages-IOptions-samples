# About

Code samples for reading from appsettings.json and is at this time a work in progress, all code works but lacking documentation at this time.

All projects are Razor Pages except one console project. The majority of work is done with dependency injection.

## Projects

- `VariousMethodsApplication` smorgasbord of code samples for obtaining information from appsettings.json
- `ConnectionStringApplication` is a simple example to get a connection string from appsettings.json for EF Core.
- `ControlLoggingApplication` Example to toggle SeriLog on/off via appsettings.json
- `DataAnnotatedValidationApplication` shows how to validate values in appsettings.json using Data Annotations validation in Program.cs
- `ReadListApplication` example for reading an array/list
- `ReadSettingsConsoleApplication` sinple console project for showing reading settings from appsettings.json

## Requires

- Microsoft Visual Studio 2022 or higher
- .NET Core 7

## What’s the difference between IOptionsMonitor vs. IOptionsSnapshot?
The major difference is the lifetime of these instances. IOptionsMonitor is registered as Singleton, whereas the IOptionsSnapshot is registered as Scoped.


-  Use IOptions, when you are not expecting your configuration values to change.
- Use IOptionsSnapshot when you expect your values to change, but want them to be uniform for the entire request cycle.
- Use IOptionsMonitor when you need real-time options data.

## Resources

- [Options pattern in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-7.0)