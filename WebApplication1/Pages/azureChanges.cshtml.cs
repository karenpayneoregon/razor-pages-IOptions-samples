using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using VariousMethodsApplication.Models;
#pragma warning disable MVC1002
#pragma warning disable CS8618, CS9264

namespace VariousMethodsApplication.Pages;

public class AzureChangesModel : PageModel
{
    private readonly IOptionsMonitor<AzureSettings> _azureSettings;

    private AzureSettings _azureSettingsIOptionsMonitor;
    [BindProperty]
    public string TenantName { get; set; }

    public AzureChangesModel(IOptionsMonitor<AzureSettings> azureSettings)
    {
        _azureSettings = azureSettings;
        _azureSettingsIOptionsMonitor = _azureSettings.CurrentValue;

        _azureSettings.OnChange(OnAzureSettingsValueChange);

    }

    private void OnAzureSettingsValueChange(AzureSettings azureSettings)
    {
        if (_azureSettingsIOptionsMonitor.TenantName == azureSettings.TenantName) return;
        _azureSettingsIOptionsMonitor.TenantName = azureSettings.TenantName;
        TenantName = azureSettings.TenantName;
    }
    public void OnGet()
    {
        TenantName = _azureSettingsIOptionsMonitor.TenantName;
    }


    [HttpGet]
    public IActionResult OnGetTenantName()
    {
        return new JsonResult(_azureSettings.CurrentValue.TenantName);
    }

}
