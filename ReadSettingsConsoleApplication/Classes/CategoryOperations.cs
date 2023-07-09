using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ReadSettingsConsoleApplication.Models;
using static ReadSettingsConsoleApplication.Classes.Utilities;

namespace ReadSettingsConsoleApplication.Classes;
public class CategoryOperations
{
    private readonly ILogger<CategoryOperations> _logger;


    public CategoryOperations(ILogger<CategoryOperations> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// No dependency injection, read section and return a list
    /// </summary>
    /// <returns></returns>
    public async Task ReadCategories()
    {
        Console.WriteLine();

        _logger.LogInformation("Getting categories\n");

        var table = CreateViewTable();

        List<Category> categories = ConfigurationRoot().GetSection(nameof(Category)).Get<List<Category>>();

        foreach (var category in categories)
        {
            table.AddRow(category.Id.ToString(), category.Name);
        }

        AnsiConsole.Write(table);

        await Task.CompletedTask;

    }
    private static Table CreateViewTable() =>
        new Table()
            .Border(TableBorder.Square)
            .BorderColor(Color.Grey100)
            .Alignment(Justify.Center)
            .Title("[white on blue][B]Categories[/][/]")
            .AddColumn(new TableColumn("[u]Id[/]"))
            .AddColumn(new TableColumn("[u]Name[/]"));
}
