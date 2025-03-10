using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ReadSettingsConsoleApplication.Models;

namespace ReadSettingsConsoleApplication.Classes
{
    public class Utilities
    {
        /// <summary>
        /// Builds and returns an <see cref="IConfigurationRoot"/> instance by reading configuration settings
        /// from the appsettings.json file, environment variables, and the current directory.
        /// </summary>
        /// <returns>An <see cref="IConfigurationRoot"/> instance containing the configuration settings.</returns>
        public static IConfigurationRoot ConfigurationRoot() =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

        /// <summary>
        /// Configures and returns a <see cref="ServiceCollection"/> instance with services registered for logging,
        /// configuration, and application-specific dependencies.
        /// </summary>
        /// <remarks>
        /// This method sets up logging providers (Console, Debug, and configuration-based logging),
        /// binds configuration sections to strongly-typed objects (<see cref="ConnectionStrings"/> and <see cref="Category"/>),
        /// and registers transient services for <see cref="DataOperations"/> and <see cref="CategoryOperations"/>.
        /// </remarks>
        /// <returns>A configured <see cref="ServiceCollection"/> instance.</returns>
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
