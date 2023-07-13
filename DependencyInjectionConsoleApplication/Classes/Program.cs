using System.Runtime.CompilerServices;
using DependencyInjectionConsoleApplication.LanguageExtensions;

namespace DependencyInjectionConsoleApplication.Classes;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = $"{nameof(DependencyInjectionConsoleApplication).SplitCamelCase()} Code sample";
        W.SetConsoleWindowPosition(W.AnchorWindow.Center);
    }
   
}