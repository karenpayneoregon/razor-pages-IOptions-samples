using ConsoleApp1.Classes;
using Serilog;
using static ConsoleApp1.Classes.SpectreConsoleHelpers;

namespace ConsoleApp1;
internal partial class Program
{
    static void Main(string[] args)
    {
        DataOperations.Connect();
        Log.Information("Today is {0}", DateTime.Now.ToShortDateString());
        AnsiConsole.MarkupLine("[cyan]Welcome[/]");

        ExitPrompt();
    }
}