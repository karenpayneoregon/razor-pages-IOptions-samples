using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Serilog;
using WebApplication1.Classes;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class OptionsMonitorExampleModel : PageModel
    {
        [BindProperty]
        public bool UseAdal { get; set; }
        private readonly IOptionsMonitor<AzureSettings> _azureSettings;

        public OptionsMonitorExampleModel(IOptionsMonitor<AzureSettings> azureSettings)
        {
            _azureSettings = azureSettings;
        }
        public void OnGet()
        {
            
            ViewData["UseAdal"] = _azureSettings.CurrentValue.UseAdal;

            Log.Information("For {P1}", nameof(AzureSettings));
            Log.Information("UseAdal {P1}", _azureSettings.CurrentValue.UseAdal.ToYesNo());
            Log.Information("Tenant {P1}", _azureSettings.CurrentValue.Tenant);
            Log.Information("Tenant name {P1}", _azureSettings.CurrentValue.TenantName);
            Log.Information("Audience {P1}", _azureSettings.CurrentValue.Audience);
            Log.Information("ClientId {P1}", _azureSettings.CurrentValue.ClientId);
            Log.Information("GraphClientId {P1}", _azureSettings.CurrentValue.GraphClientId);
            Log.Information("GraphClientSecret {P1}", _azureSettings.CurrentValue.GraphClientSecret);
            Log.Information("SignUpSignInPolicyId {P1}", _azureSettings.CurrentValue.SignUpSignInPolicyId);
            Log.Information("AzureGraphVersion {P1}", _azureSettings.CurrentValue.AzureGraphVersion);
            Log.Information("MicrosoftGraphVersion {P1}", _azureSettings.CurrentValue.MicrosoftGraphVersion);
            Log.Information("AadInstance {P1} \n", _azureSettings.CurrentValue.AadInstance);
        }
    }
}
