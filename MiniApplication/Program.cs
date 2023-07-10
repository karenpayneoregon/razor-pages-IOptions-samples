namespace MiniApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        var connectionString = builder.Configuration.GetConnectionString("NorthWindConnection");
        app.MapGet("/", () => $"North: {connectionString}");

        app.Logger.LogInformation($"Connection string: {connectionString}");

        app.Run();
    }
}
