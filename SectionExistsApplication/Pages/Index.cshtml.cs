using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SectionExistsApplication.Classes;
using SectionExistsApplication.Models;

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

        ForQuestionOfTheDay1();
        Console.WriteLine();
        InMemory2();

    }

    private void ForQuestionOfTheDay1()
    {

        var dictionary = _configuration.GetSection("Layout")
            .AsEnumerable()
            .ToDictionary(x => x.Key, x => x.Value);


        foreach (var kvp in dictionary)
        {
            Console.WriteLine($"  {kvp.Key,-50}{kvp.Value}");
        }

    }

    private void InMemory1()
    {
        var configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
            {
                { "Layout:Header", "Visible" },
                { "Layout:Footer", "Hidden" }
            }).Build();

        var dictionary = configuration.GetSection("Layout")
            .AsEnumerable()
            .Where(x => x.Key != null) // Filter out null keys
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var kvp in dictionary)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }
    }

    public void InMemory2()
    {

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                {
                    "ConnectionStrings:MainConnection",
                    "Server=(localdb)\\MSSQLLocalDB;Database=NorthWind2024;Trusted_Connection=True"
                },
                { "Layout:Header", "Visible" },
                { "Layout:Title", "Some title" },
                { "Layout:Footer", "Hidden" }
            }).Build();

        foreach (var kvp in configuration.GetSection("Layout").AsEnumerable())
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }

        Console.WriteLine("Connection string:  " + configuration
            .GetSection(nameof(ConnectionStrings))
            .GetValue<string>(nameof(ConnectionStrings.MainConnection))
        );


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
