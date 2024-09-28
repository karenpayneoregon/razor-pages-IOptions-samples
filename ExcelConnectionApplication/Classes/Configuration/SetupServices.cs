using ExcelConnectionApplication.Models.Configuration;
using Microsoft.Extensions.Options;

namespace ExcelConnectionApplication.Classes.Configuration;
internal class SetupServices
{
    private readonly ExcelConnectionStrings _excelOptions;
    private readonly ConnectionStrings _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="SetupServices"/> class.
    /// </summary>
    /// <param name="options">The application database connection strings.</param>
    /// <param name="excelOptions">The Excel connection strings.</param>
    public SetupServices(IOptions<ConnectionStrings> options, IOptions<ExcelConnectionStrings> excelOptions)
    {
        _excelOptions = excelOptions.Value;
        _options = options.Value;
    }
    /// <summary>
    /// Reads connection strings from the application settings for the database.
    /// </summary>
    /// <remarks>
    /// This method retrieves the main connection string for the database from the application settings
    /// and assigns it to the singleton instance of <see cref="DataConnections"/>.
    /// </remarks>
    public void GetConnectionStrings()
    {
        DataConnections.Instance.MainConnection = _options.MainConnection;
    }

    /// <summary>
    /// Reads connection strings from appsettings for Excel files.
    /// </summary>
    /// <remarks>
    /// This method retrieves the main connection string for Excel files from the application settings
    /// and assigns it to the singleton instance of <see cref="ExcelConnections"/>.
    /// </remarks>
    public void GetExcelConnectionStrings()
    {
        ExcelConnections.Instance.MainConnection = _excelOptions.MainConnection;
    }

}
