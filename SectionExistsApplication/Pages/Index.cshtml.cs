using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SectionExistsApplication.Classes;

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
        ForQuestionOfTheDay();
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

        var dictionary = _configuration
            .GetSection(Layout.Root)
            .AsEnumerable()
            .ToDictionary(x => 
                x.Key, x => 
                x.Value);


        if (dictionary.TryGetValue(Layout.Features, out var value))
        {
            // 
        }

    }

    private void ForQuestionOfTheDay1()
    {


        var dictionary = _configuration.GetSection("Layout")
            .AsEnumerable()
            .ToDictionary(x => x.Key, x => x.Value);


        foreach (var key in dictionary.Keys)
        {
            Console.WriteLine($"  {key}");
        }
        

        foreach (var (key, _) in dictionary)
        {
            //
        }

    }


    private void ForQuestionOfTheDay2()
    {
        var section = _configuration.GetSection(Layout.Root);

        var dictionary = section.AsEnumerable()
            .ToDictionary(x => x.Key, x => x.Value);

        if (dictionary.ContainsKey(Layout.Features))
        {
            var value1 = _configuration.GetValue<string>(Layout.Features);
        }

        string? value2 = _configuration.GetValue<string>(Layout.Features);
        if (value2 is not null)
        {
            // . . .
        }

        if (dictionary.TryGetValue(Layout.Features, out var value))
        {
            // . . .
        }
    }
}
