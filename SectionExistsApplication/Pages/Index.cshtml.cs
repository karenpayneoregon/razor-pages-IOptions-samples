using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SectionExistsApplication.Pages;
public class IndexModel : PageModel
{
    private readonly IConfiguration _configuration;

    [BindProperty]
    public bool LayoutSectionExists { get; set; }

    [BindProperty]
    public bool AzureSectionExists { get; set; }

    public IndexModel(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void OnGet()
    {
        var section = _configuration.GetSection("Layout");
        LayoutSectionExists = section.Exists();

        section = _configuration.GetSection("Azure");
        AzureSectionExists = section.Exists();
    }

    private void ForQuestionOfTheDay()
    {
        var section = _configuration.GetSection("Layout");

        var dictionary = section.AsEnumerable()
            .ToDictionary(x => x.Key, x => x.Value);

        if (dictionary.ContainsKey("Layout:ApplicationFeaturesStrong"))
        {
            var item1 = _configuration.GetValue<string>("Layout:ApplicationFeaturesStrong");
        }

        string? item2 = _configuration.GetValue<string>("Layout:ApplicationFeaturesStrong");
        if (item2 is not null)
        {
            // . . .
        }
    }
}
