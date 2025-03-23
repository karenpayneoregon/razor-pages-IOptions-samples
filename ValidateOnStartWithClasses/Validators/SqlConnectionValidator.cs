using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using ValidateOnStartWithClasses.Models;

namespace ValidateOnStartWithClasses.Validators;

/// <summary>
/// Provides validation logic for <see cref="ConnectionStrings"/> to ensure that the
/// <c>MainConnection</c> string is properly configured and a connection to the SQL database
/// can be successfully established.
/// </summary>
/// <remarks>
/// This validator checks that the <c>MainConnection</c> string is not null, empty, or whitespace.
/// Additionally, it attempts to establish a connection to the SQL database using the provided
/// connection string to verify its validity.
/// </remarks>
public class SqlConnectionValidator : IValidateOptions<ConnectionStrings>
{
    public ValidateOptionsResult Validate(string? name, ConnectionStrings options)
    {

        if (options == null || IsUninitialized(options))
        {
            return ValidateOptionsResult.Fail($"The '{nameof(ConnectionStrings)}' section is missing or not configured.");
        }

        if (string.IsNullOrWhiteSpace(options.MainConnection))
        {
            return ValidateOptionsResult.Fail(
                $"{nameof(ConnectionStrings.MainConnection)} string cannot be empty.");
        }

        try
        {
            /*
             * We want a short timeout for the connection attempt to avoid blocking the application
             */
            var builder = new SqlConnectionStringBuilder(options.MainConnection)
            {
                ConnectTimeout = 2 
            };

            using var connection = new SqlConnection(builder.ConnectionString);

            connection.Open();
            connection.Close();

        }
        catch (Exception ex)
        {
            return ValidateOptionsResult.Fail($"Failed to open SQL connection: {ex.Message}");
        }

        return ValidateOptionsResult.Success;
    }

    /// <summary>
    /// Determines whether the specified <see cref="ConnectionStrings"/> instance is uninitialized.
    /// </summary>
    /// <param name="options">The <see cref="ConnectionStrings"/> instance to validate.</param>
    /// <returns>
    /// <c>true</c> if the <paramref name="options"/> instance is uninitialized, meaning its
    /// <see cref="ConnectionStrings.MainConnection"/> property is null, empty, or consists only of whitespace;
    /// otherwise, <c>false</c>.
    /// </returns>
    private static bool IsUninitialized(ConnectionStrings options) => string.IsNullOrWhiteSpace(options.MainConnection);
}
