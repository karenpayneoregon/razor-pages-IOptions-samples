using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using SeriLogThemesLibrary;
using static System.DateTime;

namespace GetWebAddressesApplication.Classes;

/// <summary>
/// For setting up SeriLog to keep Program.Main clean and allows code to be easily copied to other projects.
/// </summary>
public class SetupLogging
{

    public static void Development()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console(theme: SeriLogCustomThemes.Default())
            .CreateLogger();
    }
}


