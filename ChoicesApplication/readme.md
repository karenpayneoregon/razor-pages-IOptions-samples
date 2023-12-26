# About

Shows two methods to read settings from appsettings.json, one weak and one strong type methods.

For strong typed, in Program.cs

```csharp
builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection(ApplicationSettings.Key));
```

Index page showing both methods, set a breakpoint to see the results.

```csharp
public class IndexModel : PageModel
{

    private readonly IConfiguration _applicationSettingsWeakType;

    private readonly IOptionsSnapshot<ApplicationSettings> _applicationSettingsStrongTyped;

    public IndexModel(IConfiguration configuration, IOptionsSnapshot<ApplicationSettings> applicationSettings)
    {
        _applicationSettingsWeakType = configuration;
        _applicationSettingsStrongTyped = applicationSettings;
    }

    public void OnGet()
    {

        var title = _applicationSettingsWeakType["Position:Title"];
        var name = _applicationSettingsWeakType["Position:Name"];


        var title1 = _applicationSettingsStrongTyped.Value.Title;
        var name1 = _applicationSettingsStrongTyped.Value.Name;
    }
}
```

## Back story

After seeing [the following](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-8.0#application-configuration-providers), needed to write this as the code presented has issues, can you spot them?