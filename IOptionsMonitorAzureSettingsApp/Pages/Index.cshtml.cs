using IOptionsMonitorAzureSettingsApp.Models;
using Serilog;

namespace IOptionsMonitorAzureSettingsApp.Pages;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

public class IndexModel : PageModel
{
    private readonly IOptionsMonitor<AzureSettings> _optionsMonitor;

    // Static variables to persist across requests
    private static string _lastDefaultConnectionString = string.Empty;
    private static string _lastDefaultTenantId = string.Empty;
    private static string _lastTenantConnectionString = string.Empty;
    private static string _lastTenantTenantId = string.Empty;
    private static DateTime _lastUpdated = DateTime.UtcNow;

    public string DefaultConnectionString { get; private set; } = string.Empty;
    public string DefaultTenantId { get; private set; } = string.Empty;
    public string TenantNameConnectionString { get; private set; } = string.Empty;
    public string TenantNameTenantId { get; private set; } = string.Empty;
    public string LastChangeNotification { get; private set; } = "string.Empty";

    public IndexModel(IOptionsMonitor<AzureSettings> optionsMonitor)
    {
        _optionsMonitor = optionsMonitor;
    }

    public void OnGet()
    {
        LoadSettings();
    }

    /// <summary>
    /// Checks for updates in the Azure settings and determines if any configuration values have changed.
    /// </summary>
    /// <returns>
    /// A <see cref="JsonResult"/> indicating whether updates were detected. 
    /// If updates are found, the response includes a message describing the change.
    /// </returns>
    /// <remarks>
    /// This method compares the current Azure settings with the previously stored values.
    /// If any changes are detected in the default or tenant-specific settings, it updates the stored values
    /// and logs the changes using Serilog.
    /// 
    /// The method is triggered via a timer defined in the associated Razor Page script.
    /// </remarks>
    public JsonResult OnGetCheckForUpdate()
    {
        var latestSettings = _optionsMonitor.CurrentValue;
        var latestTenantSettings = _optionsMonitor.Get("TenantName");

        bool hasChanged = false;
        string message = string.Empty;

        // Check if Default settings changed
        if (latestSettings.ConnectionString != _lastDefaultConnectionString)
        {
            hasChanged = true;
            message = "Default ConnectionString changed.";
            LastChangeNotification = message;
            
            Log.Information("Default ConnectionString changed to {P1} from {P2}", 
                latestSettings.ConnectionString,
                _lastDefaultConnectionString);

            _lastDefaultConnectionString = latestSettings.ConnectionString;
        }
        else if (latestSettings.TenantId != _lastDefaultTenantId)
        {
            hasChanged = true;
            message = "Default TenantId changed.";
            LastChangeNotification = message;

            Log.Information("Default TenantId changed to {P1} from {P2}",
                latestSettings.TenantId,
                _lastDefaultTenantId);


            _lastDefaultTenantId = latestSettings.TenantId;
        }

        // Check if TenantName settings changed
        if (latestTenantSettings.ConnectionString != _lastTenantConnectionString)
        {
            hasChanged = true;
            message = "TenantName ConnectionString changed.";
            LastChangeNotification = message;

            Log.Information("TenantName ConnectionString changed to {P1} from {P2}",
                latestTenantSettings.ConnectionString,
                _lastTenantConnectionString);

            _lastTenantConnectionString = latestTenantSettings.ConnectionString;
        }
        else if (latestTenantSettings.TenantId != _lastTenantTenantId)
        {
            hasChanged = true;
            message = "TenantName TenantId changed.";
            LastChangeNotification = message;

            Log.Information("TenantName TenantId changed to {P1} from {P2}",
                latestTenantSettings.TenantId,
                _lastTenantTenantId);
            _lastTenantTenantId = latestTenantSettings.TenantId;
        }

        if (hasChanged)
        {
            _lastUpdated = DateTime.UtcNow;
            return new JsonResult(new { updated = true, message });
        }

        return new JsonResult(new { updated = false });
    }

    private void LoadSettings()
    {
        var defaultSettings = _optionsMonitor.CurrentValue;
        DefaultConnectionString = defaultSettings.ConnectionString;
        DefaultTenantId = defaultSettings.TenantId;

        var tenantSettings = _optionsMonitor.Get("TenantName");
        TenantNameConnectionString = tenantSettings.ConnectionString;
        TenantNameTenantId = tenantSettings.TenantId;

        // Update the stored static values
        _lastDefaultConnectionString = DefaultConnectionString;
        _lastDefaultTenantId = DefaultTenantId;
        _lastTenantConnectionString = TenantNameConnectionString;
        _lastTenantTenantId = TenantNameTenantId;
    }
}

