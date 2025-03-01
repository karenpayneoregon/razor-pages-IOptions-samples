using IOptionsMonitorAzureSettingsApp.Models;
using Microsoft.Extensions.Options;

namespace IOptionsMonitorAzureSettingsApp.Services;

using Microsoft.Extensions.Options;

public class AzureService
{
    private readonly IOptionsMonitor<AzureSettings> _optionsMonitor;

    public string DefaultConnectionString { get; private set; }
    public string DefaultTenantId { get; private set; }
    public string TenantNameConnectionString { get; private set; }
    public string TenantNameTenantId { get; private set; }

    public AzureService(IOptionsMonitor<AzureSettings> options)
    {
        _optionsMonitor = options;

        // Fetching default options
        var defaultOptions = _optionsMonitor.CurrentValue;
        DefaultConnectionString = defaultOptions.ConnectionString;
        DefaultTenantId = defaultOptions.TenantId;

        // Fetching named options
        var namedOptions = _optionsMonitor.Get("TenantName");
        TenantNameConnectionString = namedOptions.ConnectionString;
        TenantNameTenantId = namedOptions.TenantId;
    }

    public void ReloadSettings()
    {
        var defaultOptions = _optionsMonitor.CurrentValue;
        DefaultConnectionString = defaultOptions.ConnectionString;
        DefaultTenantId = defaultOptions.TenantId;

        var namedOptions = _optionsMonitor.Get("TenantName");
        TenantNameConnectionString = namedOptions.ConnectionString;
        TenantNameTenantId = namedOptions.TenantId;
    }
}
