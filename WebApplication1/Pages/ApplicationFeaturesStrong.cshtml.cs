using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Serilog;
using VariousMethodsApplication.Classes;
using VariousMethodsApplication.Models;

namespace VariousMethodsApplication.Pages;

public class ApplicationFeaturesStrongModel : PageModel
{

    [ViewData]
    public string Title { get; set; }

    public string Subject { get; set; }

    private readonly PageDetails _pageDetails;

    [BindProperty]
    public string ConnectionString { get; set; }
    private readonly ApplicationFeatures _features;
    public ApplicationFeaturesStrongModel(IOptionsSnapshot<ApplicationFeatures> applicationFeatures, IOptionsSnapshot<PageDetails> pageDetails)
    {
        _features = applicationFeatures.Value;
        ConnectionString = _features.ConnectionString;

        _pageDetails = pageDetails.Get(PageDetails.ApplicationFeaturesStrong);
        Title = _pageDetails.Title;
        Subject = _pageDetails.Subject;
    }
    public void OnGet()
    {
        Log.Information("Strong binding for {P1}", nameof(ApplicationFeatures));
        Log.Information("EnableLogging {P1}", _features.EnableLogging.ToYesNo());
        Log.Information("ConnectionString {P1} \n", _features.ConnectionString);
    }
}