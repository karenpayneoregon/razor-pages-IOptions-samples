using ConnectionStringApplication.Classes;
using EF_Core2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ConnectionStringApplication;

public class Program
{
    public static void Main(string[] args)
    {
        // for SeriLog to write to the current folder, only for development
        Environment.CurrentDirectory = AppContext.BaseDirectory;
        
        var builder = WebApplication.CreateBuilder(args);
        builder.Configuration.Sources.Clear();
        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        builder.Configuration.AddCommandLine(args);


        // Add services to the container.
        builder.Services.AddRazorPages();
        
        builder.Services.AddDbContextPool<Context>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("NorthWindConnection"))
                .EnableSensitiveDataLogging()
                .LogTo(new DbContextLogger().Log, (id, _) => id == RelationalEventId.CommandExecuting));
        

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            // Configure Serilog
            SetupLogging.Production();
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        else
        {
            // Configure Serilog
            SetupLogging.Development();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.Run();
    }

}
