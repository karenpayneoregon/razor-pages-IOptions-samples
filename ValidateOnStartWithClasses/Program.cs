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

        var configuration = builder.Configuration;
        var conn = configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>();
        //builder.Services.AddValidatedOptions<SqlConnectionOptions, SqlConnectionValidator>(configuration);
        //builder.Services.AddValidatedOptions<TenantAzureSettings, TenantAzureValidator>(configuration);


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
