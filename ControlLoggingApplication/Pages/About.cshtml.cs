using ControlLoggingApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Serilog;

namespace ControlLoggingApplication.Pages
{
    public class AboutModel : PageModel
    {
        [ViewData]
        public string Title { get; set; }
        private readonly ApplicationFeatures _features;

        public AboutModel(IOptionsSnapshot<ApplicationFeatures> features)
        {
            _features = features.Get(ApplicationFeatures.About);
            Title = _features.Title;
        }
        public void OnGet()
        {
            if (_features.EnableLogging)
            {
                Log.Information("OnGet for About Page");
            }
        }
    }
}
