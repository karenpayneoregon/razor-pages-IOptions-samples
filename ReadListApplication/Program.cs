using Microsoft.Extensions.Options;
using ReadListApplication.Models;

namespace ReadListApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.Configure<List<Category>>(
            builder.Configuration.GetSection(nameof(Category)));

        /*
         * 1. Ensure that the configuration section exists
         * 2. Ensure that the configuration section has at least one entry for email addresses
         */
        builder.Services.AddOptions<DistributionWhitelist>()
            .Bind(builder.Configuration.GetSection(nameof(DistributionWhitelist)))
            .Validate<IConfiguration>(( _, configuration) => configuration.GetRequiredSection(nameof(DistributionWhitelist)) is not null)
            .Validate(dwl => dwl.Emails is not null, "Emails must have at least one entry")
            .ValidateOnStart();


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
