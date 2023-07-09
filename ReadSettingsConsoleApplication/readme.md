# About

This project shows dependency injection to read a connection string from appsettings.json and configure logging.

## Required NuGet packages

Copy and paste into your project file

```xml
<ItemGroup>
   <PackageReference Include="Microsoft.Extensions.Configuration" Version="6.0.1" />
   <PackageReference Include="Microsoft.Extensions.Configuration.EnvironmentVariables" Version="6.0.1" />
   <PackageReference Include="Microsoft.Extensions.Configuration.FileExtensions" Version="6.0.0" />
   <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="6.0.0" />
   <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="6.0.0" />
   <PackageReference Include="Microsoft.Extensions.DependencyInjection.Abstractions" Version="6.0.0" />
   <PackageReference Include="Microsoft.Extensions.Logging" Version="6.0.0" />
   <PackageReference Include="Microsoft.Extensions.Logging.Console" Version="6.0.0" />
   <PackageReference Include="Microsoft.Extensions.Logging.Debug" Version="6.0.0" />
   <PackageReference Include="Microsoft.Extensions.Options" Version="6.0.0" />
</ItemGroup>
```
