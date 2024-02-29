using GetWebAddressesApplication.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Serilog;

namespace GetWebAddressesApplication.Pages;
public class IndexModel : PageModel
{
    private readonly IOptionsSnapshot<ApplicationConfigurations> _applicationConfigurations;
    private readonly IOptionsSnapshot<Youtube> _youtubeConfiguration;

    public IndexModel(IOptionsSnapshot<ApplicationConfigurations> applicationConfiguration, IOptionsSnapshot<Youtube> youtubeConfiguration)
    {
        _applicationConfigurations = applicationConfiguration;
        _youtubeConfiguration = youtubeConfiguration;
    }

    public void OnGet()
    {
        var test = _youtubeConfiguration.Value.Key;
        Log.Information("Host url: {P1}", _applicationConfigurations.Value.ApplicationHostUrl);
        Log.Information("Rest service: {P1}\n", _applicationConfigurations.Value.RestService);

        Youtube youTube = _youtubeConfiguration.Value;
        Log.Information("Youtube Key {P1}", youTube.Key);
        Log.Information("Youtube AppName {P1}", youTube.AppName);
        Log.Information("Youtube Play list id {P1}", youTube.PlayListId);
    }
}
