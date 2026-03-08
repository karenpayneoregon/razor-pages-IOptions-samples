using IOptionsMonitorAzureSettingsApp.Models;

namespace IOptionsMonitorAzureSettingsApp.Services;

public class SettingsService
{
    public AzureSettings DefaultSettings { get; private set; } = new();
    public AzureSettings TenantSettings { get; private set; } = new();
    public string LastChangeNotification { get; private set; } = string.Empty;
    public DateTime LastUpdated { get; private set; } = DateTime.UtcNow;

    public void UpdateDefaultSettings(AzureSettings newSettings)
    {
        // Compare old vs. new values
        if (DefaultSettings.ConnectionString != newSettings.ConnectionString)
        {
            LastChangeNotification = $"Default ConnectionString changed at {DateTime.UtcNow}.";
        }
        else if (DefaultSettings.TenantId != newSettings.TenantId)
        {
            LastChangeNotification = $"Default TenantId changed at {DateTime.UtcNow}.";
        }

        DefaultSettings = newSettings;
        LastUpdated = DateTime.UtcNow;
    }

}