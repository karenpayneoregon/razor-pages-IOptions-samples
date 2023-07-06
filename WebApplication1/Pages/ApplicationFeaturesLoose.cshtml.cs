using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using WebApplication1.Classes;
using WebApplication1.Models;

namespace WebApplication1.Pages;

public class ApplicationFeaturesLooseModel : PageModel
{
    private readonly IConfiguration _configuration;
    private ApplicationFeatures _features = new();

    public ApplicationFeaturesLooseModel(IConfiguration configuration)
    {
        _configuration = configuration;
        _configuration.Bind("ApplicationFeatures:IndexPage", _features);
    }
    public void OnGet()
    {
        Log.Information("Loose binding for {P1}", nameof(ApplicationFeatures));
        Log.Information("EnableLogging {P1}", _features.EnableLogging.ToYesNo());
        Log.Information("ConnectionString {P1} \n", _features.ConnectionString);
    }
}