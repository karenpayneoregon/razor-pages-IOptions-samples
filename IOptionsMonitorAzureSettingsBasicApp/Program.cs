using IOptionsMonitorAzureSettingsBasicApp.Classes;
using IOptionsMonitorAzureSettingsBasicApp.Models;
using KellermanSoftware.CompareNetObjects;

namespace IOptionsMonitorAzureSettingsBasicApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        SetupLogging.Development();

        // Register CompareLogic with default options
        builder.Services.AddSingleton<CompareLogic>();

        // OR Register CompareLogic with custom configuration
        builder.Services.AddSingleton(sp => new CompareLogic
        {
            Config = new ComparisonConfig
            {
                IgnoreCollectionOrder = true, // Example configuration
                MaxDifferences = 10
            }
        });

        builder.Services.Configure<AzureSettings>(
            builder.Configuration.GetSection(AzureSettings.Settings));

        builder.Services.Configure<AzureSettings>(builder.Configuration.GetSection(nameof(AzureSettings)));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
