namespace EnvironmentApplication.Models;

public class ApplicationSettings
{
    public const string Key = "ConnectionStrings";
    public string? NorthWindConnection { get; set; }
}