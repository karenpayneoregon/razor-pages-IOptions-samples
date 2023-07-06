using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Serilog;
using WebApplication1.Classes;
using WebApplication1.Models;

namespace WebApplication1.Pages;

public class ApplicationFeaturesStrongModel : PageModel
{
    private readonly ApplicationFeatures _features;
    public ApplicationFeaturesStrongModel(IOptionsSnapshot<ApplicationFeatures> applicationFeatures)
    {
        _features = applicationFeatures.Value;
    }
    public void OnGet()
    {
        Log.Information("Strong binding for {P1}", nameof(ApplicationFeatures));
        Log.Information("EnableLogging {P1}", _features.EnableLogging.ToYesNo());
        Log.Information("ConnectionString {P1} \n", _features.ConnectionString);
    }
}