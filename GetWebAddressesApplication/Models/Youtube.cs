#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace GetWebAddressesApplication.Models;

public class Youtube
{
    public const string Location = "YouTube";
    public string Key { get; set; }
    public string PlayListId { get; set; }
    public string AppName { get; set; }
}