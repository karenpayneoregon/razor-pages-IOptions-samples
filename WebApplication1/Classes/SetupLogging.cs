using Serilog;
using SeriLogThemesLibrary;

namespace WebApplication1.Classes;


public class SetupLogging
{
    public static void Development()
    {

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console(theme: SeriLogCustomThemes.Default())
            .CreateLogger();
    }


}
