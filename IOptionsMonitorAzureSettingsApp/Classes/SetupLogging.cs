﻿using Serilog;
using SeriLogThemesLibrary;

namespace IOptionsMonitorAzureSettingsApp.Classes;


public class SetupLogging
{
    /// <summary>
    /// Configure SeriLog
    /// </summary>
    public static void Development()
    {

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console(theme: SeriLogCustomThemes.Default())
            .CreateLogger();
    }


}
