using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

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
}
