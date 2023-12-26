#pragma warning disable CS8604 // Possible null reference argument.
namespace MiniApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        var connectionString = builder.Configuration.GetConnectionString("NorthWindConnection");
        var variables = (app.Configuration as IConfigurationRoot).GetDebugView();

        if (variables.Contains(Environment.NewLine))
        {
            var parts = variables.Split(Environment.NewLine);
        }
        app.MapGet("/", () => $"North: {connectionString}\n{variables}");

        app.Logger.LogInformation($"Connection string: {connectionString}");

        app.Run();
    }
}
