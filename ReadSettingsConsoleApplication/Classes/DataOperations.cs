using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ReadSettingsConsoleApplication.Models;

namespace ReadSettingsConsoleApplication.Classes;

public class DataOperations
{
    private readonly ConnectionStrings _options;
    private readonly ILogger<DataOperations> _logger;
    public DataOperations(IOptions<ConnectionStrings> options, ILogger<DataOperations> logger)
    {
        _options = options?.Value;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// Display connection string. In a real application we do something
    /// like read data from a database
    /// </summary>
    public async Task ReadConnectionString()
    {
        _logger.LogInformation("Getting connection string\n");
        AnsiConsole.MarkupLine($"[yellow]Connection string[/] [cyan]{_options.DefaultConnection}[/]");
        await Task.CompletedTask;
    }
}
