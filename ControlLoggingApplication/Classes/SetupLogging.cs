using Serilog;
using SeriLogThemesLibrary;

namespace ControlLoggingApplication.Classes;


public class SetupLogging
{
    public static void Development()
    {

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console(theme: SeriLogCustomThemes.Default())
            .CreateLogger();
    }


}
