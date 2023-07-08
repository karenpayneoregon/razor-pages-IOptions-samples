# About

Code samples for reading from appsettings.json and is at this time a work in progress, all code works but lacking documentation at this time.

All projects are Razor Pages.

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