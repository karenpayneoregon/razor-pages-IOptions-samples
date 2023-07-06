﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Serilog;
using WebApplication1.Classes;
using WebApplication1.Models;

namespace WebApplication1.Pages;

/// <summary>
/// Example that reads settings once from appsettings.json which means if
/// something changes at runtime to get changes the app must restart.
/// </summary>
public class IndexModel : PageModel
{
    [BindProperty]
    public bool UseAdal { get; set; }
    private readonly AzureSettings _azureSettings;
    public IndexModel(IOptions<AzureSettings> azureSettings)
    {
        _azureSettings = azureSettings.Value;
    }

    public void OnGet()
    {
        ViewData["UseAdal"] = _azureSettings.UseAdal;

        Log.Information("For {P1}", nameof(AzureSettings));
        Log.Information("UseAdal {P1}", _azureSettings.UseAdal.ToYesNo());
        Log.Information("Tenant {P1}", _azureSettings.Tenant);
        Log.Information("Tenant name {P1}", _azureSettings.TenantName);
        Log.Information("Audience {P1}", _azureSettings.Audience);
        Log.Information("ClientId {P1}", _azureSettings.ClientId);
        Log.Information("GraphClientId {P1}", _azureSettings.GraphClientId);
        Log.Information("GraphClientSecret {P1}", _azureSettings.GraphClientSecret);
        Log.Information("SignUpSignInPolicyId {P1}", _azureSettings.SignUpSignInPolicyId);
        Log.Information("AzureGraphVersion {P1}", _azureSettings.AzureGraphVersion);
        Log.Information("MicrosoftGraphVersion {P1}", _azureSettings.MicrosoftGraphVersion);
        Log.Information("AadInstance {P1} \n", _azureSettings.AadInstance);

    }
}
