using DataAnnotatedValidationApplication.Models;

namespace DataAnnotatedValidationApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        /*
         * Validate  AzureSettings model data in appsettings.json
         */
        ValidateAzureSettings(builder);

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

    /// <summary>
    /// Validates the <see cref="AzureSettings"/> model data from the application configuration
    /// using data annotations and custom validation rules.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="WebApplicationBuilder"/> used to configure the application.
    /// </param>
    /// <remarks>
    /// This method ensures that the <see cref="AzureSettings"/> configuration section is bound,
    /// validated using data annotations, and adheres to additional custom validation rules:
    /// <list type="bullet">
    /// <item><description>The <c>Audience</c> property must not be null, empty, or whitespace.</description></item>
    /// <item><description>The <c>UseAdal</c> property must be set to <c>false</c>.</description></item>
    /// </list>
    /// Validation is performed during application startup.
    /// </remarks>
    private static void ValidateAzureSettings(WebApplicationBuilder builder)
    {
        builder.Services.AddOptions<AzureSettings>()
            .BindConfiguration(nameof(AzureSettings))
            .ValidateDataAnnotations()
            .Validate(audience
                => !string.IsNullOrWhiteSpace(audience.Audience), "Audience is required")
            .Validate(audience
                => audience.UseAdal == false, "UseAdal must be false")
            .ValidateOnStart();
    }
}
