using System.Runtime.CompilerServices;
using DependencyInjectionConsoleApplication.LanguageExtensions;

namespace DependencyInjectionConsoleApplication;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = $"{nameof(DependencyInjectionSimple).SplitCamelCase()} Code sample";
        W.SetConsoleWindowPosition(W.AnchorWindow.Center);
    }
   
}