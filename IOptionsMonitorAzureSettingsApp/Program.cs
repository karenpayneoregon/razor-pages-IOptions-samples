using IOptionsMonitorAzureSettingsApp.Models;
using IOptionsMonitorAzureSettingsApp.Services;

namespace IOptionsMonitorAzureSettingsApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.Configure<AzureSettings>(
            builder.Configuration.GetSection(nameof(AzureSettings)));

        // Register named options for different tenants
        builder.Services.Configure<AzureSettings>(
            "TenantName", builder.Configuration.GetSection("TenantNameAzureSettings"));

        // Register the Singleton Service
        builder.Services.AddSingleton<AzureService>();

        // Add services to the container.
        builder.Services.AddRazorPages();

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
