using IOptionsMonitorAzureSettingsApp.Models;


namespace IOptionsMonitorAzureSettingsApp.Services;

using Microsoft.Extensions.Options;
using System.Collections.Concurrent;

/// <summary>
/// Provides a service for monitoring and handling changes to Azure settings using <see cref="IOptionsMonitor{TOptions}"/>.
/// </summary>
/// <remarks>
/// This service subscribes to changes in Azure settings and notifies subscribers when updates occur.
/// It is designed to work with the <see cref="AzureSettings"/> model and supports real-time configuration updates.
/// </remarks>
public class AzureService
{
    private readonly IOptionsMonitor<AzureSettings> _optionsMonitor;
    private readonly ConcurrentDictionary<string, string> _lastKnownValues = new();

    public event Action<string>? OnSettingsChanged;

    public AzureService(IOptionsMonitor<AzureSettings> optionsMonitor)
    {
        _optionsMonitor = optionsMonitor;

        // Load initial values
        StoreSettings(_optionsMonitor.CurrentValue, "Default");
        StoreSettings(_optionsMonitor.Get("TenantName"), "TenantName");

        // Subscribe to changes
        _optionsMonitor.OnChange((updatedSettings, name) =>
        {
            if (string.IsNullOrEmpty(name)) // Default settings changed
            {
                CheckForChanges(updatedSettings, "Default");
            }
            else if (name == "TenantName") // Named settings changed
            {
                CheckForChanges(_optionsMonitor.Get("TenantName"), "TenantName");
            }
        });
    }

    private void CheckForChanges(AzureSettings newSettings, string key)
    {
        bool hasChanged = false;
        string message = $"{key} settings changed: ";

        if (_lastKnownValues.TryGetValue($"{key}_ConnectionString", out var oldConnectionString) &&
            oldConnectionString != newSettings.ConnectionString)
        {
            message += "ConnectionString updated. ";
            hasChanged = true;
        }

        if (_lastKnownValues.TryGetValue($"{key}_TenantId", out var oldTenantId) &&
            oldTenantId != newSettings.TenantId)
        {
            message += "TenantId updated.";
            hasChanged = true;
        }

        if (hasChanged)
        {
            StoreSettings(newSettings, key);
            OnSettingsChanged?.Invoke(message);
        }
    }

    private void StoreSettings(AzureSettings settings, string key)
    {
        _lastKnownValues[$"{key}_ConnectionString"] = settings.ConnectionString;
        _lastKnownValues[$"{key}_TenantId"] = settings.TenantId;
    }

    public AzureSettings GetDefaultSettings() => _optionsMonitor.CurrentValue;
    public AzureSettings GetNamedSettings() => _optionsMonitor.Get("TenantName");

}

public class SettingsService
{
    public AzureSettings DefaultSettings { get; private set; } = new AzureSettings();
    public AzureSettings TenantSettings { get; private set; } = new AzureSettings();
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
