using IOptionsMonitorAzureSettingsApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IOptionsMonitorAzureSettingsApp.Pages;

public class IndexModel(AzureService azureService) : PageModel
{
    public void OnGet()
    {
        var connectionString = azureService.DefaultConnectionString;
        Console.WriteLine(connectionString);
    }
}