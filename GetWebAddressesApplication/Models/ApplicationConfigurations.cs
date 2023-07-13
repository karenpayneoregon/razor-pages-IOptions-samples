#pragma warning disable CS8618
namespace GetWebAddressesApplication.Models;

public class ApplicationConfigurations
{
    public const string Key = "ApplicationConfigurations";
    public string ApplicationHostUrl { get; set; }

    public string RestService { get; set; }
}
