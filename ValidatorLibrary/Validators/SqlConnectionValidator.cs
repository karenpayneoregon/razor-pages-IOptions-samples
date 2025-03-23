using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using ValidatorLibrary.Models;

namespace ValidatorLibrary.Validators;

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
    /// <summary>
    /// Validates the provided <see cref="ConnectionStrings"/> instance to ensure that the
    /// <c>MainConnection</c> string is properly configured and can establish a connection to the SQL database.
    /// </summary>
    /// <param name="name">
    /// The name of the options instance being validated. This parameter is optional and can be <c>null</c>.
    /// </param>
    /// <param name="options">
    /// The <see cref="ConnectionStrings"/> instance containing the connection string to validate.
    /// </param>
    /// <returns>
    /// A <see cref="ValidateOptionsResult"/> indicating whether the validation was successful or failed.
    /// If validation fails, the result contains an error message describing the issue.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if the <paramref name="options"/> parameter is <c>null</c>.
    /// </exception>
    /// <remarks>
    /// This method performs the following checks:
    /// <list type="bullet">
    /// <item>
    /// Ensures that the <c>MainConnection</c> string is not null, empty, or whitespace.
    /// </item>
    /// <item>
    /// Attempts to establish a connection to the SQL database using the provided connection string.
    /// If the connection cannot be established, the validation fails with an appropriate error message.
    /// </item>
    /// </list>
    /// </remarks>
    public ValidateOptionsResult Validate(string? name, ConnectionStrings options)
    {

        if (options == null || string.IsNullOrWhiteSpace(options.MainConnection))
        {
            return ValidateOptionsResult.Fail($"The '{nameof(ConnectionStrings)}' section is missing or not configured.");
        }

        if (string.IsNullOrWhiteSpace(options.MainConnection))
        {
            return ValidateOptionsResult.Fail($"{nameof(ConnectionStrings.MainConnection)} string cannot be empty.");
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
}
