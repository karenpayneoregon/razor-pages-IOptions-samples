using ControlLoggingApplication.Classes;
using ControlLoggingApplication.Models;

namespace ControlLoggingApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        SetupLogging.Development();

        ApplicationConfigurations(builder);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }

    private static void ApplicationConfigurations(WebApplicationBuilder builder)
    {
        builder.Services.Configure<ApplicationFeatures>(ApplicationFeatures.Index,
            builder.Configuration.GetSection(ApplicationFeatures.Index));

        builder.Services.Configure<ApplicationFeatures>(ApplicationFeatures.About,
            builder.Configuration.GetSection(ApplicationFeatures.About));
    }
}
