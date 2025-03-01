using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using VariousMethodsApplication.Models;
#pragma warning disable CS8618, CS9264

namespace VariousMethodsApplication.Pages;

public class AzureChangesModel : PageModel
{
    private readonly IOptionsMonitor<AzureSettings> _azureSettings;

    private AzureSettings _azureSettingsIOptionsMonitor;

    public AzureChangesModel(IOptionsMonitor<AzureSettings> azureSettings)
    {
        _azureSettings = azureSettings;
        _azureSettingsIOptionsMonitor = _azureSettings.CurrentValue;

        _azureSettings.OnChange(OnAzureSettingsValueChange);
    }

    private void OnAzureSettingsValueChange(AzureSettings azureSettings)
    {
        if (_azureSettingsIOptionsMonitor.TenantName != azureSettings.TenantName)
            _azureSettingsIOptionsMonitor.TenantName = azureSettings.TenantName;
    }
    public void OnGet()
    {
    }
}