using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using VariousMethodsApplication.Models;
#pragma warning disable CS8618

namespace VariousMethodsApplication.Pages;

public class GetSectionExampleModel : PageModel
{

    [BindProperty]
    public List<PageContainer> PageDetailsList { get; set; } = new();

    public GetSectionExampleModel(IConfiguration configuration, IOptionsSnapshot<PageDetails> pageDetails)
    {

        List<IConfigurationSection> sections = 
            configuration.GetSection(nameof(PageDetails)).GetChildren().ToList();

        foreach (var section in sections)
        {
            PageDetailsList.Add(new PageContainer()
            {
                Path = section.Key,
                Details = pageDetails.Get(section.Path)
            });
        }
    }
    public void OnGet()
    {
    }
}

public class PageContainer
{
    public string Path { get; set; }
    public PageDetails Details { get; set; }
    public override string ToString() => Path;

}