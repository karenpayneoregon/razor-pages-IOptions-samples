# About

The idea is to show a developer can store/read API web addresses from appsettings.json.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",

  "ApplicationConfigurations": {
    "ApplicationHostUrl": "https://fake.com/",
    "RestService": "https://someapp/api/"
  }

}
```

:heavy_check_mark: In a real application this would be used in a service.

```csharp
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IOptionsSnapshot<ApplicationConfigurations> _applicationConfigurations;

    public IndexModel(
        ILogger<IndexModel> logger, 
        IOptionsSnapshot<ApplicationConfigurations> applicationConfiguration)
    {
        _logger = logger;
        _applicationConfigurations = applicationConfiguration;
    }

    public void OnGet()
    {
        _logger.LogInformation(
            $"Host url: {_applicationConfigurations.Value.ApplicationHostUrl}");
        _logger.LogInformation(
            $"Rest service: {_applicationConfigurations.Value.RestService}");
    }
}
```
