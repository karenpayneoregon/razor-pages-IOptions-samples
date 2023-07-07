using DataAnnotatedValidationApplication.Models;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace DataAnnotatedValidationApplication.Pages;
public class IndexModel : PageModel
{
    private readonly AzureSettings _azureSettings;

    public IndexModel(IOptions<AzureSettings> azureSettings)
    {
        _azureSettings = azureSettings.Value;
    }

    public void OnGet()
    {

    }
}
