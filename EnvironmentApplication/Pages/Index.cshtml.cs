using EnvironmentApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
#pragma warning disable CS8618

namespace EnvironmentApplication.Pages;
public class IndexModel : PageModel
{
    private readonly IOptionsSnapshot<ApplicationSettings> _applicationSettings;

    [BindProperty]
    public string ConnectionString { get; set; }
    public IndexModel(IOptionsSnapshot<ApplicationSettings> applicationSettings)
    {
        _applicationSettings = applicationSettings;
        ConnectionString = _applicationSettings.Value.NorthWindConnection!;
    }
}