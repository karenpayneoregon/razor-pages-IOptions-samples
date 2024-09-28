#nullable disable
namespace ExcelConnectionApplication.Classes.Configuration;

/// <summary>
/// Provides a singleton instance to manage Excel connection strings.
/// </summary>
public sealed class ExcelConnections
{
    private static readonly Lazy<ExcelConnections> Lazy = new(() => new ExcelConnections());
    public static ExcelConnections Instance => Lazy.Value;

    public string MainConnection { get; set; }
}