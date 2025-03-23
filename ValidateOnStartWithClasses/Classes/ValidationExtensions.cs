using Microsoft.Extensions.Options;
using ValidateOnStartWithClasses.Models;
using ValidateOnStartWithClasses.Validators;

namespace ValidateOnStartWithClasses.Classes;

/// <summary>
/// Provides extension methods for adding validation logic to the dependency injection container
/// for specific configuration options used in the application.
/// </summary>
/// <remarks>
/// This class includes methods to register validation for configuration options such as
/// <see cref="SqlConnectionOptions"/> and
/// <see cref="TenantAzureSettings"/>. These methods ensure
/// that the application configuration is validated at startup, preventing runtime errors
/// caused by invalid or missing configuration values.
/// </remarks>
public static class ValidationExtensions
{

    /// <summary>
    /// Adds validation for <see cref="SqlConnectionOptions"/> to the dependency injection container.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to which the validation services are added.</param>
    /// <param name="configuration">The application's configuration, used to bind the <see cref="SqlConnectionOptions"/>.</param>
    /// <returns>The updated <see cref="IServiceCollection"/> with the validation services registered.</returns>
    /// <remarks>
    /// This method binds the <c>ConnectionStrings</c> section of the configuration to the
    /// <see cref="SqlConnectionOptions"/> class and registers the <see cref="SqlConnectionValidator"/>
    /// to validate the options at application startup. This ensures that the SQL connection
    /// configuration is valid before the application runs.
    /// </remarks>
    public static IServiceCollection SqlConnectionValidation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<SqlConnectionOptions>()
            .Bind(configuration.GetSection(nameof(ConnectionStrings)))
            .ValidateOnStart();

        services.AddSingleton<IValidateOptions<SqlConnectionOptions>, SqlConnectionValidator>();

        return services;
    }

    /// <summary>
    /// Registers validation for the <see cref="TenantAzureSettings"/> configuration section.
    /// </summary>
    /// <param name="services">
    /// The <see cref="IServiceCollection"/> to which the validation services will be added.
    /// </param>
    /// <param name="configuration">
    /// The <see cref="IConfiguration"/> instance used to bind the <see cref="TenantAzureSettings"/> section.
    /// </param>
    /// <returns>
    /// The updated <see cref="IServiceCollection"/> with the validation services for <see cref="TenantAzureSettings"/> added.
    /// </returns>
    /// <remarks>
    /// This method binds the "TenantAzureSettings" section of the configuration to the <see cref="TenantAzureSettings"/> class
    /// and ensures that it is validated at application startup. It also registers the <see cref="TenantAzureValidator"/>
    /// to provide custom validation logic for the configuration.
    /// </remarks>
    public static IServiceCollection TenantValidation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<TenantAzureSettings>()
            .Bind(configuration.GetSection(nameof(TenantAzureSettings)))
            .ValidateOnStart();

        services.AddSingleton<IValidateOptions<TenantAzureSettings>, TenantAzureValidator>();

        return services;
    }

    public static IServiceCollection AddValidatedOptions<TOptions, TValidator>(
        this IServiceCollection services,
        IConfiguration configuration)
        where TOptions : class
        where TValidator : class, IValidateOptions<TOptions>
    {
        services.AddOptions<TOptions>()
            .Bind(configuration.GetSection(typeof(TOptions).Name))
            .ValidateOnStart();

        services.AddSingleton<IValidateOptions<TOptions>, TValidator>();

        return services;
    }
}
