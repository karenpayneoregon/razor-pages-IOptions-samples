using Microsoft.Extensions.DependencyInjection;
using ReadSettingsConsoleApplication.Classes;

namespace ReadSettingsConsoleApplication;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        
        var services = Utilities.ConfigureServices();
        await using var serviceProvider = services.BuildServiceProvider();
        await serviceProvider.GetService<DataOperations>()!.ReadConnectionStringFromAppSettings();
        ExitPrompt();
    }
}