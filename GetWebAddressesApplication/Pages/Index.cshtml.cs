using GetWebAddressesApplication.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace GetWebAddressesApplication.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IOptionsSnapshot<ApplicationConfigurations> _applicationConfigurations;

    public IndexModel(
        ILogger<IndexModel> logger, 
        IOptionsSnapshot<ApplicationConfigurations> applicationConfiguration)
    {
        _logger = logger;
        _applicationConfigurations = applicationConfiguration;
    }

    public void OnGet()
    {
        _logger.LogInformation(
            $"Host url: {_applicationConfigurations.Value.ApplicationHostUrl}");
        _logger.LogInformation(
            $"Rest service: {_applicationConfigurations.Value.RestService}");
    }
}
