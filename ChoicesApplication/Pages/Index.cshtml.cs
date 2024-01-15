using ChoicesApplication.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace ChoicesApplication.Pages;


public class IndexModel : PageModel
{

    private readonly IConfiguration _applicationSettingsWeakType;

    private readonly IOptionsSnapshot<ApplicationSettings> _applicationSettingsStrongTyped;

    public IndexModel(IConfiguration configuration, IOptionsSnapshot<ApplicationSettings> applicationSettings)
    {
        _applicationSettingsWeakType = configuration;
        _applicationSettingsStrongTyped = applicationSettings;
    }

    public void OnGet()
    {

        var title = _applicationSettingsWeakType["Position:Title"];
        var name = _applicationSettingsWeakType["Position:Name"];


        var title1 = _applicationSettingsStrongTyped.Value.Title;
        var name1 = _applicationSettingsStrongTyped.Value.Name;

        var title2 = _applicationSettingsStrongTyped
            .Get(ApplicationSettings.Key).Title;


    }
}
