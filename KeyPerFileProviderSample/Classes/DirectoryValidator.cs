using KeyPerFileProviderSample.Models;
using Microsoft.Extensions.Options;

namespace KeyPerFileProviderSample.Classes;

/// <summary>
/// Provides validation logic for <see cref="DirectoryOptions"/>.
/// </summary>
/// <remarks>
/// This class ensures that the <see cref="DirectoryOptions.DirectoryPath"/> 
/// is not null or empty and that the specified directory exists.
/// </remarks>
public class DirectoryValidator : IValidateOptions<DirectoryOptions>
{
    /// <summary>
    /// Validates the specified <see cref="DirectoryOptions"/> instance.
    /// </summary>
    /// <param name="name">
    /// The name of the options instance being validated. 
    /// </param>
    /// <param name="options">
    /// The <see cref="DirectoryOptions"/> instance to validate.
    /// </param>
    /// <returns>
    /// A <see cref="ValidateOptionsResult"/> indicating the success or failure of the validation.
    /// Returns <see cref="ValidateOptionsResult.Fail(string)"/> if the <see cref="DirectoryOptions.DirectoryPath"/> 
    /// is null, empty, or if the specified directory does not exist.
    /// Otherwise, returns <see cref="ValidateOptionsResult.Success"/>.
    /// </returns>
    public ValidateOptionsResult Validate(string? name, DirectoryOptions options)
    {
        if (string.IsNullOrEmpty(options.DirectoryPath))
        {
            return ValidateOptionsResult.Fail("Directory path cannot be empty.");
        }

        return !Directory.Exists(options.DirectoryPath) ? 
            ValidateOptionsResult.Fail($"Directory does not exist: {options.DirectoryPath}") : 
            ValidateOptionsResult.Success;
    }
}
