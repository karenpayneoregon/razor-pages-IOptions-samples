using KeyPerFileProviderSample.Classes;
using KeyPerFileProviderSample.Models;
using Microsoft.Extensions.Options;
using Serilog;

namespace KeyPerFileProviderSample;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure Serilog
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();

        builder.Host.UseSerilog();

        // Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.Configure<DirectoryOptions>(builder.Configuration.GetSection(DirectoryOptions.Key));
        builder.Services.AddSingleton<IValidateOptions<DirectoryOptions>, DirectoryValidator>();

        // Enable validation on application startup
        builder.Services.AddOptions<DirectoryOptions>().ValidateOnStart();

        var directoryOptions = builder.Configuration.GetSection(DirectoryOptions.Key)
            .Get<DirectoryOptions>();

        var secretsPath = directoryOptions!.DirectoryPath;

        // Add Key-per-file configuration provider
        builder.Configuration.AddKeyPerFile(directoryPath: secretsPath, optional: true);

        builder.Services.Configure<HelpDesk>(builder.Configuration);
        builder.Services.Configure<Connections>(builder.Configuration);

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapRazorPages()
           .WithStaticAssets();

        app.Run();
    }
}
