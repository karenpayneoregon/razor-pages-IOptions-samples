using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ReadSettingsConsoleApplication.Models;

namespace ReadSettingsConsoleApplication.Classes
{
    public class Utilities
    {
        /// <summary>
        /// Read sections from appsettings.json
        /// </summary>
        public static IConfigurationRoot ConfigurationRoot() =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

        public static ServiceCollection ConfigureServices()
        {
            static void ConfigureService(IServiceCollection services)
            {
                services.AddLogging(builder =>
                {
                    builder.AddConsole();
                    builder.AddDebug();
                    builder.AddConfiguration(ConfigurationRoot().GetSection("Logging"));
                });

                services.Configure<ConnectionStrings>(ConfigurationRoot().GetSection(nameof(ConnectionStrings)));

                services.Configure<Category>(ConfigurationRoot().GetSection(nameof(Category)));

                services.AddTransient<DataOperations>();
                services.AddTransient<CategoryOperations>();
            }

            var services = new ServiceCollection();
            ConfigureService(services);

            return services;

        }
    }
}
