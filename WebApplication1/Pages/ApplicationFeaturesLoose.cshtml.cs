using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Serilog;
using WebApplication1.Classes;
using WebApplication1.Models;

namespace WebApplication1.Pages;

public class ApplicationFeaturesLooseModel : PageModel
{
    [ViewData]
    public string Title { get; set; }

    private readonly IConfiguration _configuration;
    private ApplicationFeatures _features = new();

    private readonly PageDetails _title;

    public ApplicationFeaturesLooseModel(IConfiguration configuration, IOptionsSnapshot<PageDetails> pageTitle)
    {
        _configuration = configuration;
        _configuration.Bind("ApplicationFeatures:IndexPage", _features);

        _title = pageTitle.Get(PageDetails.ApplicationFeaturesLoose);
        Title = _title.Title;
    }
    public void OnGet()
    {
        Log.Information("Loose binding for {P1}", nameof(ApplicationFeatures));
        Log.Information("EnableLogging {P1}", _features.EnableLogging.ToYesNo());
        Log.Information("ConnectionString {P1} \n", _features.ConnectionString);
    }
}