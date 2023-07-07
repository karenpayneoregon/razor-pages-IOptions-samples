using DataAnnotatedValidationApplication.Models;

namespace DataAnnotatedValidationApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOptions<AzureSettings>()
            .BindConfiguration(nameof(AzureSettings))
            .ValidateDataAnnotations()
            .Validate(audience 
                => !string.IsNullOrWhiteSpace(audience.Audience), "Audience is required")
            .Validate(audience 
                => audience.UseAdal == false, "UseAdal must be false")
            .ValidateOnStart();

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
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }
}
