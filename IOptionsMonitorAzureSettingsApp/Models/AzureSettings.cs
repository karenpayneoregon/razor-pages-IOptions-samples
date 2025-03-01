namespace IOptionsMonitorAzureSettingsApp.Models;

public class AzureSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string TenantId { get; set; } = string.Empty;
}

public class TenantNameAzureSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string TenantId { get; set; } = string.Empty;
}

