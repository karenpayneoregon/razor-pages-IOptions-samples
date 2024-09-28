using ExcelConnectionApplication.Models.Configuration;
using Microsoft.Extensions.Options;

namespace ExcelConnectionApplication.Classes.Configuration;
internal class SetupServices
{
    private readonly ExcelConnectionStrings _excelOptions;
    private readonly EntityConfiguration _settings;
    private readonly ConnectionStrings _options;

    public SetupServices(
        IOptions<ConnectionStrings> options,
        IOptions<ExcelConnectionStrings> excelOptions,
        IOptions<EntityConfiguration> settings)
    {
        _excelOptions = excelOptions.Value;
        _options = options.Value;
        _settings = settings.Value;
    }
    /// <summary>
    /// Read connection strings from appsettings
    /// </summary>
    public void GetConnectionStrings()
    {
        DataConnections.Instance.MainConnection = _options.MainConnection;
    }

    public void GetExcelConnectionStrings()
    {
        ExcelConnections.Instance.MainConnection = _excelOptions.MainConnection;
    }

}
