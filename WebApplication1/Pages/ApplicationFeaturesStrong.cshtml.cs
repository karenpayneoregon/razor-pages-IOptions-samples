using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Serilog;
using WebApplication1.Classes;
using WebApplication1.Models;

namespace WebApplication1.Pages;

public class ApplicationFeaturesStrongModel : PageModel
{

    [ViewData]
    public string Title { get; set; }

    private readonly PageTitles _title;

    [BindProperty]
    public string ConnectionString { get; set; }
    private readonly ApplicationFeatures _features;
    public ApplicationFeaturesStrongModel(IOptionsSnapshot<ApplicationFeatures> applicationFeatures, IOptionsSnapshot<PageTitles> pageTitle)
    {
        _features = applicationFeatures.Value;
        ConnectionString = _features.ConnectionString;

        _title = pageTitle.Get(PageTitles.ApplicationFeaturesStrong);
        Title = _title.Title;
    }
    public void OnGet()
    {
        Log.Information("Strong binding for {P1}", nameof(ApplicationFeatures));
        Log.Information("EnableLogging {P1}", _features.EnableLogging.ToYesNo());
        Log.Information("ConnectionString {P1} \n", _features.ConnectionString);
    }
}