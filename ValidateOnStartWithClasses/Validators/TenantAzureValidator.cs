using Microsoft.Extensions.Options;
using ValidateOnStartWithClasses.Models;

namespace ValidateOnStartWithClasses.Validators;

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
            return ValidateOptionsResult.Fail(
                $"{nameof(TenantAzureSettings)}.{nameof(TenantAzureSettings.TenantId)} must be a valid GUID.");
        }

        return ValidateOptionsResult.Success;
    }
}
