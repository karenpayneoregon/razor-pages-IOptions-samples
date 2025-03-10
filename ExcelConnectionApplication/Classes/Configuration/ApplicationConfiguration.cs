using ExcelConnectionApplication.Models.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ExcelConnectionApplication.Classes.Configuration;
internal class ApplicationConfiguration
{
    /// <summary>
    /// Configures and returns a new instance of <see cref="ServiceCollection"/> 
    /// with services required for handling connection strings and setup operations.
    /// </summary>
    /// <remarks>
    /// This method sets up dependency injection for connection strings and Excel connection strings
    /// by reading configurations from the application settings. It also registers 
    /// <see cref="SetupServices"/> as a transient service.
    /// </remarks>
    /// <returns>
    /// A configured instance of <see cref="ServiceCollection"/>.
    /// </returns>
    public static ServiceCollection ConfigureServices()
    {
        static void ConfigureService(IServiceCollection services)
        {

            services.Configure<ConnectionStrings>(Config.JsonRoot().GetSection(nameof(ConnectionStrings)));
            services.Configure<ExcelConnectionStrings>(Config.JsonRoot().GetSection(nameof(ExcelConnectionStrings)));
            services.AddTransient<SetupServices>();
        }

        var services = new ServiceCollection();
        ConfigureService(services);

        return services;

    }
}


