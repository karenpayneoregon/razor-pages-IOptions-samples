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
public class DirectoryOptionsValidator : IValidateOptions<DirectoryOptions>
{
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
