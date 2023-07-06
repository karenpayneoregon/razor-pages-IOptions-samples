using WebApplication1.Classes;
using WebApplication1.Models;

namespace WebApplication1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        SetupLogging.Development();

        MainConfigurations(builder);
        ConfigurePageTitles(builder);


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
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }

    private static void MainConfigurations(WebApplicationBuilder builder)
    {
        builder.Services.Configure<ApplicationFeatures>(
            builder.Configuration.GetSection(ApplicationFeatures.Settings));

        builder.Services.Configure<TopItemSettings>(TopItemSettings.Month,
            builder.Configuration.GetSection(TopItemSettings.Month));

        builder.Services.Configure<TopItemSettings>(TopItemSettings.Year,
            builder.Configuration.GetSection(TopItemSettings.Year));
    }

    private static void ConfigurePageTitles(WebApplicationBuilder builder)
    {
        builder.Services.Configure<PageTitles>(PageTitles.NamedOptions,
            builder.Configuration.GetSection(PageTitles.NamedOptions));

        builder.Services.Configure<PageTitles>(PageTitles.MainPage,
            builder.Configuration.GetSection(PageTitles.MainPage));

        builder.Services.Configure<PageTitles>(PageTitles.ApplicationFeaturesLoose,
            builder.Configuration.GetSection(PageTitles.ApplicationFeaturesLoose));

        builder.Services.Configure<PageTitles>(PageTitles.ApplicationFeaturesStrong,
            builder.Configuration.GetSection(PageTitles.ApplicationFeaturesStrong));

        builder.Services.Configure<PageTitles>(PageTitles.Monitor,
            builder.Configuration.GetSection(PageTitles.Monitor));

    }
}
