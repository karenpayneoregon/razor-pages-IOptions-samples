using GetWebAddressesApplication.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Serilog;

namespace GetWebAddressesApplication.Pages;
public class IndexModel : PageModel
{
    private readonly IOptionsSnapshot<ApplicationConfigurations> _applicationConfigurations;

    public IndexModel(IOptionsSnapshot<ApplicationConfigurations> applicationConfiguration)
    {
        _applicationConfigurations = applicationConfiguration;
    }

    public void OnGet()
    {
        Log.Information("Host url: {P1}", _applicationConfigurations.Value.ApplicationHostUrl);
        Log.Information("Rest service: {P1}\n", _applicationConfigurations.Value.RestService);
    }
}
