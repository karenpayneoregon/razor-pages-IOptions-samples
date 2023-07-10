using VariousMethodsApplication.Classes;
using VariousMethodsApplication.Models;

namespace VariousMethodsApplication;

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
        builder.Services.Configure<PageDetails>(PageDetails.NamedOptions,
            builder.Configuration.GetSection(PageDetails.NamedOptions));

        builder.Services.Configure<PageDetails>(PageDetails.MainPage,
            builder.Configuration.GetSection(PageDetails.MainPage));

        builder.Services.Configure<PageDetails>(PageDetails.ApplicationFeaturesLoose,
            builder.Configuration.GetSection(PageDetails.ApplicationFeaturesLoose));

        builder.Services.Configure<PageDetails>(PageDetails.ApplicationFeaturesStrong,
            builder.Configuration.GetSection(PageDetails.ApplicationFeaturesStrong));

        builder.Services.Configure<PageDetails>(PageDetails.Monitor,
            builder.Configuration.GetSection(PageDetails.Monitor));

    }
}