using Microsoft.Extensions.Options;
using ValidatorLibrary.Models;

namespace ValidatorLibrary.Validators;

/// <summary>
/// Provides validation logic for <see cref="TenantAzureSettings"/> to ensure required properties
/// such as <c>ConnectionString</c> and <c>TenantId</c> are properly configured.
/// </summary>
/// <remarks>
/// This validator checks that the <c>ConnectionString</c> is not null or whitespace, 
/// the <c>TenantId</c> is not null or whitespace, and that the <c>TenantId</c> is a valid GUID.
/// </remarks>
public class TenantAzureValidator : IValidateOptions<TenantAzureSettings>
{
    /// <summary>
    /// Validates the specified <see cref="TenantAzureSettings"/> instance to ensure that all required properties
    /// are properly configured.
    /// </summary>
    /// <param name="name">
    /// The name of the options instance being validated. This parameter can be <c>null</c>.
    /// </param>
    /// <param name="options">
    /// The <see cref="TenantAzureSettings"/> instance to validate. This parameter must not be <c>null</c>.
    /// </param>
    /// <returns>
    /// A <see cref="ValidateOptionsResult"/> indicating the success or failure of the validation. 
    /// If validation fails, the result contains error messages describing the issues.
    /// </returns>
    /// <remarks>
    /// This method ensures that:
    /// <list type="bullet">
    /// <item><description>The <c>ConnectionString</c> property is not null, empty, or whitespace.</description></item>
    /// <item><description>The <c>TenantId</c> property is not null, empty, or whitespace.</description></item>
    /// <item><description>The <c>TenantId</c> property is a valid GUID.</description></item>
    /// </list>
    /// </remarks>
    public ValidateOptionsResult Validate(string? name, TenantAzureSettings options)
    {

        if (options == null || string.IsNullOrWhiteSpace(options.ConnectionString))
        {
            return ValidateOptionsResult.Fail($"The '{nameof(TenantAzureSettings)}.{nameof(ConnectionStrings)}' section is missing or not configured.");
        }

        if (string.IsNullOrWhiteSpace(options.ConnectionString))
        {
            return ValidateOptionsResult.Fail($"{nameof(TenantAzureSettings)}.{nameof(TenantAzureSettings.ConnectionString)} is required.");
        }

        if (string.IsNullOrWhiteSpace(options.TenantId))
        {
            return ValidateOptionsResult.Fail($"{nameof(TenantAzureSettings)}.{nameof(TenantAzureSettings.TenantId)} is required.");
        }

        if (!Guid.TryParse(options.TenantId, out _))
        {
            return ValidateOptionsResult.Fail($"{nameof(TenantAzureSettings)}.{nameof(TenantAzureSettings.TenantId)} must be a valid GUID.");
        }

        return ValidateOptionsResult.Success;
    }
}
