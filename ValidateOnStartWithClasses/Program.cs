using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Serilog;
using ValidateOnStartWithClasses.Classes;
using ValidateOnStartWithClasses.Models;
using ValidateOnStartWithClasses.Validators;

namespace ValidateOnStartWithClasses;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Override("System", Serilog.Events.LogEventLevel.Warning)
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();

        builder.Services
            .SqlConnectionValidation(builder.Configuration)
            .TenantValidation(builder.Configuration);

        //ForArticle(builder);

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

    private static void ForArticle(WebApplicationBuilder builder)
    {
        builder.Services.AddOptions<ConnectionStrings>()
            .BindConfiguration(nameof(ConnectionStrings))
            .ValidateDataAnnotations()
            .Validate(cs =>
                {
                    try
                    {

                        var sb = new SqlConnectionStringBuilder(cs.MainConnection)
                        {
                            ConnectTimeout = 2
                        };

                        using SqlConnection connection = new(sb.ConnectionString);

                        connection.Open();
                        connection.Close();
                        return true;

                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }, $"Failed to open SQL connection: {nameof(ConnectionStrings.MainConnection)} ")
            .ValidateOnStart();
    }
}
